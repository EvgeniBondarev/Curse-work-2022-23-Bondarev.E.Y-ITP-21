using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWorkTests
{
    [TestClass]
    public class SpectacleManagerTests
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
        public void Add_AddsNewSpectacle()
        {
            // Arrange
            int initialCount = SpectacleManager.GetAll().Count();

            // Act
            SpectacleManager.Add(_testSpectacle);
            var result = SpectacleManager.GetAll();

            // Assert
            Assert.AreEqual(initialCount + 1, result.Count());
            Assert.IsTrue(result.Any(x => x.Title == _testSpectacle.Title));

            SpectacleManager.Delete(_testSpectacle);
        }

        [TestMethod]
        public void Update_UpdatesSpectacle()
        {
            // Arrange
            var updatedSpectacle = _testSpectacle;
            updatedSpectacle.Author = "Updated Author";
            SpectacleManager.Add(_testSpectacle);

            // Act
            SpectacleManager.Update(updatedSpectacle);
            var result = SpectacleManager.GetAll();

            // Assert
            Assert.IsTrue(result.Any(x => x.Title == _testSpectacle.Title && x.Author == updatedSpectacle.Author));

            SpectacleManager.Delete(_testSpectacle);
        }

        [TestMethod]
        public void Delete_DeletesSpectacle()
        {
            // Arrange
            SpectacleManager.Add(_testSpectacle);
            var initialCount = SpectacleManager.GetAll().Count();

            // Act
            SpectacleManager.Delete(_testSpectacle);
            var result = SpectacleManager.GetAll();

            // Assert
            Assert.AreEqual(initialCount - 1, result.Count());
            Assert.IsFalse(result.Any(x => x.Title == _testSpectacle.Title));
        }
        [TestMethod]
        public void TestDataValidate_ValidData_ReturnsTrue()
        {
            // Arrange
            var item = new SpectacleModel()
            {
                Title = "Title",
                Author = "Author",
                Genre = "Genre",
                Date = DateTime.Now,
                Categories = new Dictionary<Categorias, decimal>()
                            {
                                { Categorias.VIP,100},
                                { Categorias.Medium, 50 },
                                { Categorias.Standart, 25 }
                            },
            };

            // Act
            var result = SpectacleManager.DataValidate(item);

            // Assert
            Assert.IsTrue(result);
        }

    }

}
