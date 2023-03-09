using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System;

public class SpectacleManager : XmlDocumentManager<Spectacle>
{
    private readonly string _xmlFilePath;


    public SpectacleManager(string xmlFilePath) : base(xmlFilePath)
    {
        _xmlFilePath = xmlFilePath;
    }


    public override IEnumerable<Spectacle> GetAll()
    {
        return XmlDoc.Root.Elements("spectacle").Select(x => new Spectacle
        {
            Title = x.Element("title").Value,
            Author = x.Element("author").Value,
            Genre = x.Element("genre").Value,
            Date = DateTime.Parse(x.Element("date").Value),
            Categories = x.Elements("category").ToDictionary(y => y.Attribute("name").Value, y => int.Parse(y.Value))
        });
    }

    public override void Add(Spectacle item)
    {
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

        XmlDoc.Root.Add(newSpectacle);
        XmlDoc.Save(_xmlFilePath);
    }

    public override void Update(Spectacle item)
    {
        var spectacleToUpdate = XmlDoc.Root.Elements("spectacle").FirstOrDefault(x => x.Element("title").Value == item.Title);

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

            XmlDoc.Save(_xmlFilePath);
        }
    }

    public override void Delete(Spectacle item)
    {
        var spectacleToDelete = XmlDoc.Root.Elements("spectacle").FirstOrDefault(x => x.Element("title").Value == item.Title);

        if (spectacleToDelete != null)
        {
            spectacleToDelete.Remove();
            XmlDoc.Save(_xmlFilePath);
        }
    }
}
