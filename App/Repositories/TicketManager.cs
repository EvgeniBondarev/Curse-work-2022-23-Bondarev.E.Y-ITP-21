using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Schema;
using App.Services;

/// <summary>
/// Предоставляет методы для управления билетами в документе XML.
/// </summary>
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
    /// <summary>
    /// Получает все билеты.
    /// </summary>
    /// <returns>Список всех билетов.</returns>
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
    /// <summary>
    /// Добавляет новый билет.
    /// </summary>
    /// <param name="ticket">Новый билет для добавления.</param>
    /// <exception cref="ArgumentException">Выдается, когда данные недействительны.</exception>
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
    /// <summary>
    /// Удаляет билет.
    /// </summary>
    /// <param name="ticketId">Идентификатор удаляемого билета.</param>
    /// <exception cref="ArgumentException">Выдается, когда билет с указанным идентификатором не существует.</exception>
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
    /// <summary>
    /// Проверяет, что данные билета проходят валидацию.
    /// </summary>
    /// <param name="ticket">Спектакль, данные которого нужно проверить.</param>
    /// <returns>true, если данные проходят валидацию, false в противном случае.</returns>
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