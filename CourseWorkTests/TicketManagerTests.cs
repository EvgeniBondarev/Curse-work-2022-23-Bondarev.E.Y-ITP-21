using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWorkTests
{
    [TestClass]
    public class TicketManagerTests
    {
        private readonly SpectacleModel _testSpectacle = new SpectacleModel
        {
            Title = "Test Spectacle",
            Author = "Test Author",
            Genre = "Драма",
            Date = DateTime.Now,
            Categories = new Dictionary<Categorias, decimal>()
                            {
                                { Categorias.VIP,100},
                                { Categorias.Medium, 50 },
                                { Categorias.Standart, 25 }
                            },
            FreePlace = 25
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
            SpectacleManager.Add(_testSpectacle);
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
            SpectacleManager.Delete(_testSpectacle);
        }


        [TestMethod]
        public void Delete_ExistingTicketId_RemovesTicketFromXml()
        {
            // Arrange
            SpectacleManager.Add(_testSpectacle);
            int ticketIdToDelete = TicketManager.GetAll().First().Id;
            int initialCount = TicketManager.GetAll().Count();

            // Act
            TicketManager.Delete(ticketIdToDelete);

            // Assert
            Assert.AreEqual(initialCount - 1, TicketManager.GetAll().Count());
            Assert.IsNull(TicketManager.GetAll().SingleOrDefault(t => t.Id == ticketIdToDelete));
            SpectacleManager.Delete(_testSpectacle);
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
