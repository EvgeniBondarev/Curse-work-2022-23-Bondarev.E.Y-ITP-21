using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services
{
    internal class SpectacleServices : ISpectacleServices
    {
        private readonly SpectacleManager _spectacleManager;

        public SpectacleServices(string xmlFile, string xsdFile)
        {
            _spectacleManager = new SpectacleManager(xmlFile, xsdFile);
        }
       
        public IEnumerable<SpectacleModel> ShowAllSpectacles()
        {
            IEnumerable<SpectacleModel> spectacles = _spectacleManager.GetAll();
            return spectacles;
        }
        public SpectacleModel ShowSpectacle(DateTime date)
        {
            IEnumerable<SpectacleModel> spectacles = _spectacleManager.GetAll();
            SpectacleModel spectacle = spectacles.FirstOrDefault(x => x.Date.Equals(date));
            if (spectacle == null)
            {
                return spectacle;
            } 
            else throw new ArgumentException($"Спектакль на дату {date} не найден.");
        }
        public SpectacleModel ShowSpectacle(string title)
        {
            IEnumerable<SpectacleModel> spectacles = _spectacleManager.GetAll();
            SpectacleModel spectacle = spectacles.FirstOrDefault(x => x.Title == title);
            if (spectacle != null)
            {
                
                return spectacle;
            }
            else throw new ArgumentException($"Спектакль c названием {title} не найден.");
        }

        public void AddNewSpectacle(string title, string author, string genre, DateTime date, Dictionary<string, int> categories)
        {
            _spectacleManager.Add(CreateSpectacleElement(title, author, genre, date, categories));
        }

        public void UpdateSpectacle(string newTitle, string newAuthor, string newGenre, DateTime date, Dictionary<string, int> newCategories)
        {
            _spectacleManager.Update(CreateSpectacleElement(newTitle, newAuthor, newGenre, date, newCategories));
        }
        public void DeleteSpectacle(DateTime date)
        {
            SpectacleModel spectacleToDelete = _spectacleManager.GetAll().FirstOrDefault(x => x.Date.Equals(date));
            if (spectacleToDelete != null)
            {
                _spectacleManager.Delete(spectacleToDelete);
            }
            else throw new ArgumentException($"Спектакль на дату {date.ToShortDateString()} не найден.");
        }
        private SpectacleModel CreateSpectacleElement(string title, string author, string genre, DateTime date, Dictionary<string, int> categories)
        {
            return new SpectacleModel
            {
                Title = title,
                Author = author,
                Genre = genre,
                Date = date,
                Categories = categories,
            };
        }
    }
}
