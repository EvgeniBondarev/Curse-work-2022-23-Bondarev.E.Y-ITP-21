using App.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace App
{
    public class TicketServicesXmlLoggingDecorator : TicketServices
    {
        private readonly TicketServices _ticketServices;
        private readonly XDocument _log;
        private readonly string _xmlFilePath = "C:\\Users\\Evgeni\\Desktop\\CourseWork\\App\\XMLData\\Log.xml";

        public TicketServicesXmlLoggingDecorator(TicketServices inner)
        {
            _ticketServices = inner;
            _log = XDocument.Load(_xmlFilePath);
        }

        public void AddTicket(string userName, SpectacleModel spectacleModel, Categorias category)
        {
            _ticketServices.AddTicket(userName, spectacleModel, category);

            LogOperation("Покупка билета", userName, spectacleModel, category);
        }

        public void DeletTicket(int id)
        {
            LogOperation("Возврат билета", _ticketServices.GetTicket(id));

            _ticketServices.DeletTicket(id);

            
        }

        public IEnumerable<TicketModel> GetTicket()
        {
            return _ticketServices.GetTicket();
        }

        public IEnumerable<TicketModel> GetTicket(string owner)
        {
            return _ticketServices.GetTicket(owner);
        }

        public TicketModel GetTicket(int id)
        {
            return _ticketServices.GetTicket(id);
        }

        private void LogOperation(string methodName, string userName, SpectacleModel spectacleModel, Categorias category)
        {
            var logEntry = new XElement("Operation",
                new XElement("Method", methodName),
                new XElement("Owner", userName),
                new XElement("SpectacleName", spectacleModel.Title),
                new XElement("SpectacleDate", spectacleModel.Date.ToString("d")),
                new XElement("Category", category),
                new XElement("Price", spectacleModel.Categories[category]),
                new XElement("Timestamp", DateTime.Now.ToString("o"))
                );
            _log.Root.Add(logEntry);
            _log.Save("C:\\Users\\Evgeni\\Desktop\\CourseWork\\App\\XMLData\\log.xml");
        }
        private void LogOperation(string methodName, TicketModel ticketModel)
        {
            var logEntry = new XElement("Operation",
                new XElement("Method", methodName),
                new XElement("Owner", ticketModel.Owner),
                new XElement("SpectacleName", ticketModel.Title),
                new XElement("SpectacleDate", ticketModel.Date.ToString("d")),
                new XElement("Category", ticketModel.Category),
                new XElement("Price", ticketModel.Price),
                new XElement("Timestamp", DateTime.Now.ToString("o"))
                );
            _log.Root.Add(logEntry);
            _log.Save("C:\\Users\\Evgeni\\Desktop\\CourseWork\\App\\XMLData\\log.xml");
        }
    }
}
