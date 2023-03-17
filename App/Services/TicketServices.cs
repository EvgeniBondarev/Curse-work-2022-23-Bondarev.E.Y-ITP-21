using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services
{
    public class TicketServices : ITicketServices<TicketModel>
    {
        private readonly TicketManager _ticketManager;

        public TicketServices(string xmlFile, string xsdFile)
        {   
            _ticketManager = new TicketManager(xmlFile, xsdFile);
        }
        public void AddTicket(UserModel userModel, SpectacleModel spectacleModel)
        {
            throw new NotImplementedException();
        }

        public void DeletTicket(UserModel userModel, SpectacleModel spectacleModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TicketModel> GetTicket()
        {
            return _ticketManager.GetAll();
        }

        public IEnumerable<TicketModel> GetTicket(string owner)
        {
            IEnumerable<TicketModel> tickets = _ticketManager.GetAll().Where(x => x.Owner == owner); ;
            if (tickets != null)
            {
                return tickets;
            }
            else throw new ArgumentException($"Билет пользователя {owner} не найден.");
        }

        public TicketModel GetTicket(DateTime date)
        {
            IEnumerable<TicketModel> tickets = _ticketManager.GetAll();
            TicketModel ticket = tickets.FirstOrDefault(x => x.Date.Equals(date));
            if (ticket != null)
            {
                return ticket;
            }
            else throw new ArgumentException($"Билет на {date} не найден.");
        }
        private TicketModel CreateTicketElement(UserModel userModel, SpectacleModel spectacleModel)
        {/*
            return new TicketModel
            {
                Owner = userModel.Login,
                Date = spectacleModel.Date,
                Category = "WEERD",
                Price = spectacleModel.Categories["VIP"]


            };
        */
            return null;
        }
    }
}
