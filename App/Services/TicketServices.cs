using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services
{
    public class TicketServices : ITicketServices<TicketModel>
    {
        public TicketServices()
        {   
        }
        public void AddTicket(string userName, SpectacleModel spectacleModel, Categorias category)
        {
            TicketManager.Add(CreateTicketElement(userName, spectacleModel, category));
        }

        public void DeletTicket(int id)
        {
            TicketManager.Delete(id);
        }
       

        public IEnumerable<TicketModel> GetTicket()
        {
            return TicketManager.GetAll();
        }

        public IEnumerable<TicketModel> GetTicket(string owner)
        {
            IEnumerable<TicketModel> tickets = TicketManager.GetAll().Where(x => x.Owner == owner); ;
            if (tickets != null)
            {
                return tickets;
            }
            else throw new ArgumentException($"Билет пользователя {owner} не найден.");
        }

        public TicketModel GetTicket(int id)
        {
            IEnumerable<TicketModel> tickets = TicketManager.GetAll();
            TicketModel ticket = tickets.FirstOrDefault(x => x.Id == id);
            if (ticket != null)
            {
                return ticket;
            }
            else throw new ArgumentException($"Билет на c id={id} не найден.");
        }
        private TicketModel CreateTicketElement(string userName, SpectacleModel spectacleModel, Categorias category)
        {
            return new TicketModel
            {
                Owner = userName,
                Date = spectacleModel.Date,
                Title = spectacleModel.Title,
                Category = category,
                Price = spectacleModel.Categories[category]
            };
        }
    }
}
