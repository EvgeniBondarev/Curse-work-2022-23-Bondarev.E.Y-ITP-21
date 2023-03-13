using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System;
using System.Xml.Schema;

public class SpectacleManager : IXmlDocumentManager<Spectacle>
{
    private readonly string _xmlFilePath;
    private readonly XDocument _xmlDoc;
    private readonly XmlSchemaSet _schemas;
    public SpectacleManager(string xmlFilePath, string xsdFilePath)
    {
        _xmlFilePath = xmlFilePath;
        _xmlDoc = XDocument.Load(_xmlFilePath);
        _schemas = new XmlSchemaSet();
        _schemas.Add(null, xsdFilePath);
    }

    public IEnumerable<Spectacle> GetAll()
    {
        return _xmlDoc.Root.Elements("spectacle").Select(x => new Spectacle
        {
            Title = x.Element("title").Value,
            Author = x.Element("author").Value,
            Genre = x.Element("genre").Value,
            Date = DateTime.Parse(x.Element("date").Value),
            Categories = x.Elements("category").ToDictionary(y => y.Attribute("name").Value, y => int.Parse(y.Value))
        });
    }

    public void Add(Spectacle item)
    {
        if (!DataValidate(item))
        {
            throw new ArgumentException($"Данные не валидны.");
        }

        DateTime date = item.Date.Date;
        if (GetAll().Any(x => x.Date.Date == date))
        {
            throw new ArgumentException($"Спектакль на дату {date.ToShortDateString()} уже существует.");
        }

        var newSpectacle = new XElement("spectacle",
            new XElement("title", item.Title),
            new XElement("author", item.Author),
            new XElement("genre", item.Genre),
            new XElement("date", item.Date.ToString("yyyy-MM-ddTHH:mm:ss"))
        );

        foreach (var category in item.Categories)
        {
            newSpectacle.Add(new XElement("category", category.Value,
                new XAttribute("name", category.Key)));
        }

        _xmlDoc.Root.Add(newSpectacle);
        _xmlDoc.Save(_xmlFilePath);
    }

    public void Update(Spectacle item)
    {
        XElement spectacleToUpdate = GetElement(item);

        if (spectacleToUpdate != null)
        {
            spectacleToUpdate.SetElementValue("author", item.Author);
            spectacleToUpdate.SetElementValue("genre", item.Genre);
            spectacleToUpdate.SetElementValue("date", item.Date.ToString("yyyy-MM-ddTHH:mm:ss"));

            foreach (var category in item.Categories)
            {
                var categoryToUpdate = spectacleToUpdate.Elements("category").FirstOrDefault(x => x.Attribute("name").Value == category.Key);

                if (categoryToUpdate != null)
                {
                    categoryToUpdate.SetValue(category.Value);
                }
            }

            _xmlDoc.Save(_xmlFilePath);
        }
        else throw new ArgumentException("Элемент для обновления не найден.");
    }

    public void Delete(Spectacle item)
    {
        XElement spectacleToUpdate = GetElement(item);

        if (spectacleToUpdate != null)
        {
            spectacleToUpdate.Remove();
            _xmlDoc.Save(_xmlFilePath);
        }
        else throw new ArgumentException("Элемент для удаления не найден.");
    }

    public XElement GetElement(Spectacle item)
    {
        return _xmlDoc.Root.Elements("spectacle").FirstOrDefault(x => x.Element("title").Value == item.Title);
    }

    public bool DataValidate(Spectacle item)
    {
        bool isValid = true;

        var tmpSpectacle = new XElement("spectacles",
            new XElement("spectacle",
                new XElement("title", item.Title),
                new XElement("author", item.Author),
                new XElement("genre", item.Genre),
                new XElement("date", item.Date.ToString("yyyy-MM-ddTHH:mm:ss")))
        );

        foreach (var category in item.Categories)
        {
            tmpSpectacle.Element("spectacle").Add(new XElement("category", category.Value,
                new XAttribute("name", category.Key)));
        }
        var xdoc = new XDocument(tmpSpectacle);
        xdoc.Validate(_schemas, (o, e) =>
        {
            throw new ArgumentException(e.Message);
            isValid = false;
        });
        return isValid;
    }
}