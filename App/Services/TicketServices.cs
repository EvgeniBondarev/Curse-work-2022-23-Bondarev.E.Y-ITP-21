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
        public void AddTicket(UserModel userModel, SpectacleModel spectacleModel, Categorias category)
        {
            TicketManager.Add(CreateTicketElement(userModel, spectacleModel, category));
        }

        public void DeletTicket(UserModel userModel, SpectacleModel spectacleModel, Categorias category)
        {
            TicketManager.Delete(CreateTicketElement(userModel, spectacleModel, category));
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

        public TicketModel GetTicket(DateTime date)
        {
            IEnumerable<TicketModel> tickets = TicketManager.GetAll();
            TicketModel ticket = tickets.FirstOrDefault(x => x.Date.Equals(date));
            if (ticket != null)
            {
                return ticket;
            }
            else throw new ArgumentException($"Билет на {date} не найден.");
        }
        private TicketModel CreateTicketElement(UserModel userModel, SpectacleModel spectacleModel, Categorias category)
        {
            return new TicketModel
            {
                Owner = userModel.Login,
                Date = spectacleModel.Date,
                Title = spectacleModel.Title,
                Category = category,
                Price = spectacleModel.Categories[category]
            };
        }
    }
}
