using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System;
using System.Xml.Schema;
using System.Collections.ObjectModel;

public static  class SpectacleManager
{
    private static readonly string _xmlFilePath;
    private static readonly string _xmlGanrePath;

    private static readonly XDocument _xmlDoc;
    private static readonly XmlSchemaSet _schemas;
    private static readonly XDocument _genreDoc;
    static SpectacleManager()
    {
        _xmlFilePath = "C:\\Users\\Evgeni\\Desktop\\CourseWork\\App\\XMLData\\spectacle.xml";
        _xmlGanrePath = "C:\\Users\\Evgeni\\Desktop\\CourseWork\\App\\XMLData\\genres.xml";

        _xmlDoc = XDocument.Load(_xmlFilePath);
        _schemas = new XmlSchemaSet();
        _schemas.Add(null, "C:\\Users\\Evgeni\\Desktop\\CourseWork\\App\\XMLData\\spectacle.xsd");
        _genreDoc = XDocument.Load(_xmlGanrePath);
    }
    public static IEnumerable<SpectacleModel> GetAll()
    {

        return _xmlDoc.Root.Elements("spectacle").Select(x => new SpectacleModel
        {
            Title = x.Element("title").Value,
            Author = x.Element("author").Value,
            Genre = GetGenreNameById(Int32.Parse(x.Element("genre").Value)),
            Date = DateTime.Parse(x.Element("date").Value),
            Categories = x.Elements("category").ToDictionary(y => (Categorias)Enum.Parse(typeof(Categorias), y.Attribute("name").Value), y => decimal.Parse(y.Value))

        });
    }

    public static void Add(SpectacleModel item)
    {
        if (DataValidate(item))
        {
            DateTime date = item.Date.Date;
            if (GetAll().Any(x => x.Date.Date == date))
            {
                throw new ArgumentException($"Спектакль на дату {date.ToShortDateString()} уже существует.");
            }

            int genreId = GetGenreIdByName(item.Genre);

            XElement newSpectacle = new XElement("spectacle",
                new XElement("title", item.Title),
                new XElement("author", item.Author),
                new XElement("genre", genreId),
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

    private static int GetGenreIdByName(string name)
    {
        var genreElement = _genreDoc.Descendants("genre")
                                    .FirstOrDefault(x => x.Value == name);
        if (genreElement != null && int.TryParse(genreElement.Attribute("id").Value, out int genreId))
        {
            return genreId;
        }
        throw new Exception($"Жанр {name} не найден в базе данных.");
    }

    private static string GetGenreNameById(int id)
    {
        var genreElement = _genreDoc.Descendants("genre")
                                    .FirstOrDefault(x => x.Attribute("id")?.Value == id.ToString());
        if (genreElement != null)
        {
            return genreElement.Value;
        }
        throw new Exception($"Жанр с id {id} не найден в базе данных.");
    }

    public static void AddGenre(string name)
    {
        int maxId = _genreDoc.Root.Elements("genre").Select(g => (int)g.Attribute("id")).Max();
        XElement newGenre = new XElement("genre", new XAttribute("id", maxId + 1), name);
        _genreDoc.Root.Add(newGenre);
        _genreDoc.Save(_xmlGanrePath);
    }
    public static List<string> GetAllGenres()
    {
        return _genreDoc.Root.Elements("genre").Select(x => x.Value).ToList();
    }
    public static void Update(SpectacleModel item)
    {
        if (DataValidate(item))
        {
            XElement spectacleToUpdate = GetElement(item);

            spectacleToUpdate.SetElementValue("author", item.Author);
            spectacleToUpdate.SetElementValue("genre", GetGenreIdByName(item.Genre).ToString());
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
    public static void Delete(SpectacleModel item)
    {
        XElement spectacleToDelete = GetElement(item);
        spectacleToDelete.Remove();
        _xmlDoc.Save(_xmlFilePath);
    }
    public static XElement GetElement(SpectacleModel item)
    {
        DateTime date = item.Date.Date;
        XElement element = _xmlDoc.Root.Elements("spectacle").FirstOrDefault(x => DateTime.Parse(x.Element("date").Value).Date == date);
        if (element != null)
        {
            return element;
        }
        else throw new ArgumentException("Элемент не найден.");
    }
    private static bool DataValidate(SpectacleModel item)
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