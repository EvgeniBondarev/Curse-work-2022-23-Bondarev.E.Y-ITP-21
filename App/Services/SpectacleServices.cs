using System;
using System.Collections.Generic;
using System.Linq;


namespace App.Services
{
    public class SpectacleServices : ISpectacleServices<SpectacleModel>
    {
        public SpectacleServices()
        {
        }
       
        public IEnumerable<SpectacleModel> ShowAllSpectacles()
        {
            IEnumerable<SpectacleModel> spectacles = SpectacleManager.GetAll();
            return spectacles;
        }
        public SpectacleModel ShowSpectacle(DateTime date)
        {
            IEnumerable<SpectacleModel> spectacles = SpectacleManager.GetAll();
            SpectacleModel spectacle = spectacles.FirstOrDefault(x=> x.Date.ToString("d") == date.ToString("d"));

            if (spectacle != null)
            {
                return spectacle;
            } 
            else throw new ArgumentException($"Спектакль на дату `{date.ToString("d")}` не найден.");
        }
        public IEnumerable<SpectacleModel> ShowSpectacle(string genre)
        {
            IEnumerable<SpectacleModel> spectacles = SpectacleManager.GetAll();
            IEnumerable<SpectacleModel> filteredSpectacles = spectacles.Where(x => x.Genre.ToLower() == genre.ToLower());
            if (filteredSpectacles.Any())
            {
                return filteredSpectacles;
            }
            else
            {
                throw new ArgumentException($"Спектакли c жанром `{genre}` не найдены.");
            }
        }


        public void AddNewSpectacle(string title, string author, string genre, DateTime date,   
                                    decimal vipPrise, decimal mediumPrice, decimal standartPrice)
        {
            SpectacleManager.Add(CreateSpectacleElement(title, author, genre, date, vipPrise, mediumPrice, standartPrice));
        }

        public void UpdateSpectacle(string newTitle, string newAuthor, string newGenre, DateTime date,
                                    decimal newVipPrise, decimal newMediumPrice, decimal newStandartPrice)
        {
            SpectacleManager.Update(CreateSpectacleElement(newTitle, newAuthor, newGenre, date,newVipPrise, newMediumPrice, newStandartPrice));
        }

        public void AddGanre(string ganreName)
        {
            SpectacleManager.AddGenre(ganreName);
        }
        public List<string> GetAllGenres()
        {
            return SpectacleManager.GetAllGenres();
        }
        public int GetGenreIdByName(string name)
        {
            return SpectacleManager.GetGenreIdByName(name);
        }
        public void DeleteSpectacle(DateTime date)
        {
            SpectacleModel spectacleToDelete =SpectacleManager.GetAll().FirstOrDefault(x => x.Date.Equals(date));
            if (spectacleToDelete != null)
            {
                SpectacleManager.Delete(spectacleToDelete);
            }
            else throw new ArgumentException($"Спектакль на дату `{date.ToString("d")}` не найден.");
        }
        private SpectacleModel CreateSpectacleElement(string title, string author, string genre, DateTime date,     
                                                      decimal vipPrise, decimal mediumPrice, decimal standartPrice)
        {
            Dictionary<Categorias, decimal> thisCategories = new Dictionary<Categorias, decimal>()
            {
                { Categorias.VIP, vipPrise},
                { Categorias.Medium, mediumPrice},
                { Categorias.Standart, standartPrice}
            };

            return new SpectacleModel
            {
                Title = title,
                Author = author,
                Genre = genre,
                Date = date,
                Categories = thisCategories,

            };
        }
    }
}
