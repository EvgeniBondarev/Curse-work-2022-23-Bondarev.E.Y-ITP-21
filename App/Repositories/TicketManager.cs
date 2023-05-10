using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Schema;
using App.Services;

public static class TicketManager
{
    private static readonly string _xmlFilePath;
    private static readonly XDocument _xmlDoc;
    private static readonly XmlSchemaSet _schemas;
    private static SpectacleServices _spectacleServices;

    static TicketManager()
    {
        _xmlFilePath = "C:\\Users\\Evgeni\\Desktop\\CourseWork\\App\\XMLData\\tickets.xml";
        _xmlDoc = XDocument.Load(_xmlFilePath);
        _schemas = new XmlSchemaSet();
        _schemas.Add(null, "C:\\Users\\Evgeni\\Desktop\\CourseWork\\App\\XMLData\\tickets.xsd");
        _spectacleServices = new SpectacleServices();
    }

    public static IEnumerable<TicketModel> GetAll()
    {
        return _xmlDoc.Root.Elements("ticket").Select(t =>
            new TicketModel
            {
                Id = int.Parse(t.Attribute("id").Value),
                Owner = t.Element("owner").Value,
                Date = DateTime.Parse(t.Element("date").Value),
                Title = _spectacleServices.ShowSpectacle(DateTime.Parse(t.Element("date").Value)).Title,
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

        int id = _xmlDoc.Root.Elements("ticket").Max(t => int.Parse(t.Attribute("id").Value)) + 1;
        XElement newTicket = new XElement("ticket",
            new XAttribute("id", id),
            new XElement("owner", ticket.Owner),
            new XElement("date", ticket.Date.ToString("yyyy-MM-dd")),
            new XElement("category", ticket.Category),
            new XElement("price", ticket.Price)
        );
        _xmlDoc.Root.Add(newTicket);
        _xmlDoc.Save(_xmlFilePath);
    }

    

    public static void Delete(int ticketId)
    {
        XElement ticketToDelete = _xmlDoc.Root.Elements("ticket")
            .SingleOrDefault(t => t.Attribute("id")?.Value == ticketId.ToString());

        if (ticketToDelete != null)
        {
            ticketToDelete.Remove();
            _xmlDoc.Save(_xmlFilePath);
        }
        else
        {
            throw new ArgumentException($"Ticket with id {ticketId} does not exist.");
        }
    }
    
    private static bool DataValidate(TicketModel ticket)
    {
        bool isValid = true;

        var tmpTicket = new XElement("tickets",
            new XElement("ticket",
            new XAttribute("id", int.MinValue),
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