using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services
{
    public class TicketServices : ITicketServices<TicketModel>
    {
        private static SpectacleServices _spectacleServices;
        public TicketServices()
        {   
            _spectacleServices = new SpectacleServices();
        }
        public void AddTicket(string userName, SpectacleModel spectacleModel, Categorias category)
        {

            if (spectacleModel.FreePlace > 0)
            {
                spectacleModel.FreePlace -= 1;
                SpectacleManager.Update(spectacleModel);
                TicketManager.Add(CreateTicketElement(userName, spectacleModel, category));
            }
            else throw new ArgumentException($"На спектакль {spectacleModel.Title} нет свободных мест.");
            
        }

        public void DeletTicket(int id)
        {
            SpectacleModel spectacle = _spectacleServices.ShowSpectacle(GetTicket(id).Date);
            spectacle.FreePlace += 1;
            SpectacleManager.Update(spectacle);

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
