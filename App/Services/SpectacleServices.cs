using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services
{
    internal class SpectacleServices : ISpectacleServices
    {
        public IEnumerable<Spectacle> ShowAllSpectacles()
        {
            throw new NotImplementedException();
        }

        public Spectacle ShowSpectacleByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Spectacle ShowSpectacleByName(string name)
        {
            throw new NotImplementedException();
        }

        public void UpdateSpectacle(int spectacleId, string newName, DateTime newDate, string newDescription)
        {
            throw new NotImplementedException();
        }
        public void DeleteSpectacle(int spectacleId)
        {
            throw new NotImplementedException();
        }
    }
}
