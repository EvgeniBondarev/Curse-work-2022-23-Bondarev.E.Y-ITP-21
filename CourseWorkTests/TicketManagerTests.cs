using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWorkTests
{
    [TestClass]
    internal class TicketManagerTests
    {
        private static readonly SpectacleModel _validSpectacle = new SpectacleModel
        {
            Title = "Valid Spectacle",
            Author = "Valid Author",
            Genre = "Valid Genre",
            Date = DateTime.Now,
            Categories = new Dictionary<Categorias, decimal>()
            {
                { Categorias.VIP, 100 },
                { Categorias.Medium, 50 },
                { Categorias.Standart, 25 }
            },
            FreePlace = 10
        };
        private static readonly SpectacleModel _invalidSpectacle = new SpectacleModel
        {
            Title = null,
            Author = null,
            Genre = null,
            Date = DateTime.Now,
            Categories = new Dictionary<Categorias, decimal>()
            {
                { Categorias.VIP, 100 },
                { Categorias.Medium, 50 },
                { Categorias.Standart, 25 }
            },
            FreePlace = 10
        };

        [TestMethod]
        public void GetAll_ReturnsTicketModels()
        {
            // Arrange

            // Act
            var result = TicketManager.GetAll();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IEnumerable<TicketModel>));
        }

        [TestMethod]
        public void Add_ValidTicketModel_AddsTicketToXml()
        {
            // Arrange
            int initialCount = TicketManager.GetAll().Count();
            var validTicket = new TicketModel
            {
                Owner = "Valid Owner",
                Date = DateTime.Now,
                Category = Categorias.Medium,
                Price = 100
            };

            // Act
            TicketManager.Add(validTicket);

            // Assert
            Assert.AreEqual(initialCount + 1, TicketManager.GetAll().Count());
            Assert.IsNotNull(TicketManager.GetAll().SingleOrDefault(t => t.Owner == validTicket.Owner &&
                t.Date == validTicket.Date &&
                t.Category == validTicket.Category &&
                t.Price == validTicket.Price));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Add_InvalidTicketModel_ThrowsArgumentException()
        {
            // Arrange
            var invalidTicket = new TicketModel
            {
                Owner = null,
                Date = DateTime.Now,
                Category = Categorias.VIP,
                Price = -1
            };

            // Act
            TicketManager.Add(invalidTicket);

            // Assert
            // ExpectedException
        }

        [TestMethod]
        public void Delete_ExistingTicketId_RemovesTicketFromXml()
        {
            // Arrange
            int ticketIdToDelete = TicketManager.GetAll().First().Id;
            int initialCount = TicketManager.GetAll().Count();

            // Act
            TicketManager.Delete(ticketIdToDelete);

            // Assert
            Assert.AreEqual(initialCount - 1, TicketManager.GetAll().Count());
            Assert.IsNull(TicketManager.GetAll().SingleOrDefault(t => t.Id == ticketIdToDelete));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Delete_NonExistingTicketId_ThrowsArgumentException()
        {
            // Arrange
            int nonExistingTicketId = -1;

            // Act
            TicketManager.Delete(nonExistingTicketId);

            // Assert
            // ExpectedException
        }
    }
}
