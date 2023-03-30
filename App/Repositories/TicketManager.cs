using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.Schema;
using System;
using System.Linq;

public static class TicketManager
{
    private static readonly string _xmlFilePath;
    private static readonly XDocument _xmlDoc;
    private static readonly XmlSchemaSet _schemas;

    static TicketManager()
    {
        _xmlFilePath = "C:\\Users\\Evgeni\\Desktop\\CourseWork\\App\\XMLData\\tickets.xml";
        _xmlDoc = XDocument.Load(_xmlFilePath);
        _schemas = new XmlSchemaSet();
        _schemas.Add(null, "C:\\Users\\Evgeni\\Desktop\\CourseWork\\App\\XMLData\\tickets.xsd");
    }
    public static IEnumerable<TicketModel> GetAll()
    {
        return _xmlDoc.Root.Elements("ticket").Select(t =>
            new TicketModel
            {
                Owner = t.Element("owner").Value,
                Date = DateTime.Parse(t.Element("date").Value),
                Category = (Categorias)Enum.Parse(typeof(Categorias), t.Element("category").Value),
                Price = int.Parse(t.Element("price").Value)
            }); 
    }

    public static void Add(TicketModel ticket)
    {
        if (!DataValidate(ticket))
        {
            throw new ArgumentException("Данные не валидны.");
        }

        _xmlDoc.Root.Add(new XElement("ticket",
            new XElement("owner", ticket.Owner),
            new XElement("date", ticket.Date.ToString("yyyy-MM-dd")),
            new XElement("category", ticket.Category),
            new XElement("price", ticket.Price)
        ));
        _xmlDoc.Save(_xmlFilePath);
    }

    public static void Update(TicketModel ticket)
    {
        if (!DataValidate(ticket))
        {
            throw new ArgumentException("Данные не валидны.");
        }

        XElement ticketToUpdate = _xmlDoc.Root.Elements("ticket")
            .SingleOrDefault(t => t.Element("owner").Value == ticket.Owner);

        if (ticketToUpdate != null)
        {
            ticketToUpdate.Element("date").Value = ticket.Date.ToString("yyyy-MM-dd");
            ticketToUpdate.Element("category").Value = ticket.Category.ToString();
            ticketToUpdate.Element("price").Value = ticket.Price.ToString();
            _xmlDoc.Save(_xmlFilePath);
        }
        else throw new ArgumentException("Такого билета не существует");
    }

    public static void Delete(TicketModel ticket)
    {
        XElement ticketToDelete = _xmlDoc.Root.Elements("ticket")
            .SingleOrDefault(t => t.Element("owner").Value == ticket.Owner);

        if (ticketToDelete != null)
        {
            ticketToDelete.Remove();
            _xmlDoc.Save(_xmlFilePath);
        }
        else throw new ArgumentException("Такого билета не существует");
    }

    private static bool DataValidate(TicketModel ticket)
    {
        bool isValid = true;

        var tmpTicket = new XElement("tickets",
            new XElement("ticket",
            new XElement("owner", ticket.Owner),
            new XElement("date", ticket.Date.ToString("yyyy-MM-dd")),
            new XElement("category", ticket.Category),
            new XElement("price", ticket.Price)
            ));

        var xdoc = new XDocument(tmpTicket);

        xdoc.Validate(_schemas, (o, e) =>
        {
            isValid = false;
        });

        return isValid;
    }
}
