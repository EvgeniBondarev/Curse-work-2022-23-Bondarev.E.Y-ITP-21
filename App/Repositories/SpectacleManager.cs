using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System;
using System.Xml.Schema;

public class SpectacleManager : IXmlDocumentManager<SpectacleModel>
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

    public IEnumerable<SpectacleModel> GetAll()
    {

        return _xmlDoc.Root.Elements("spectacle").Select(x => new SpectacleModel
        {
            Title = x.Element("title").Value,
            Author = x.Element("author").Value,
            Genre = x.Element("genre").Value,
            Date = DateTime.Parse(x.Element("date").Value),
            Categories = x.Elements("category").ToDictionary(y => (Categorias)Enum.Parse(typeof(Categorias), y.Attribute("name").Value), y => decimal.Parse(y.Value))

        });
    }

    public void Add(SpectacleModel item)
    {
        if (DataValidate(item))
        {
            DateTime date = item.Date.Date;
            if (GetAll().Any(x => x.Date.Date == date))
            {
                throw new ArgumentException($"Спектакль на дату {date.ToShortDateString()} уже существует.");
            }

            var newSpectacle = new XElement("spectacle",
                new XElement("title", item.Title),
                new XElement("author", item.Author),
                new XElement("genre", item.Genre),
                new XElement("date", item.Date.ToString("yyyy-MM-dd"))
            );

            foreach (var category in item.Categories)
            {
                newSpectacle.Add(new XElement("category", category.Value.ToString(),
                    new XAttribute("name", category.Key)));
            }

            _xmlDoc.Root.Add(newSpectacle);
            _xmlDoc.Save(_xmlFilePath);
        }
    }

    public void Update(SpectacleModel item)
    {
        if (DataValidate(item))
        {
            XElement spectacleToUpdate = GetElement(item);

            spectacleToUpdate.SetElementValue("author", item.Author);
            spectacleToUpdate.SetElementValue("genre", item.Genre);
            spectacleToUpdate.SetElementValue("date", item.Date.ToString("yyyy-MM-dd"));

            foreach (var category in item.Categories)
            {
                var categoryToUpdate = spectacleToUpdate.Elements("category").FirstOrDefault(x => Enum.Parse(typeof(Categorias), x.Attribute("name").Value).ToString() == category.Key.ToString());

                if (categoryToUpdate != null)
                {
                    categoryToUpdate.SetValue(category.Value.ToString());
                }
                else throw new Exception(categoryToUpdate.ToString());
            }

            _xmlDoc.Save(_xmlFilePath);
        }

    }

    public void Delete(SpectacleModel item)
    {
        XElement spectacleToDelete = GetElement(item);
        spectacleToDelete.Remove();
        _xmlDoc.Save(_xmlFilePath);
    }

    public XElement GetElement(SpectacleModel item)
    {
        DateTime date = item.Date.Date;
        XElement element = _xmlDoc.Root.Elements("spectacle").FirstOrDefault(x => DateTime.Parse(x.Element("date").Value).Date == date);
        if (element != null)
        {
            return element;
        }
        else throw new ArgumentException("Элемент не найден.");
    }


    private bool DataValidate(SpectacleModel item)
    {

        XElement tmpSpectacle = new XElement("spectacles",
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
        });
        return true;
        
    }
}