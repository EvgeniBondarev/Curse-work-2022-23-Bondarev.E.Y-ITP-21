
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CourseWorkTests
{
    [TestClass]
    public class UserManagerTests
    {
        XDocument xmlDoc = XDocument.Load("C:\\Users\\Evgeni\\Desktop\\CourseWork\\App\\XMLData\\users.xml");
        [TestMethod]
        public void GetAll_ReturnsAllUsers()
        {
            // Arrange
            var expectedUsers = new List<UserModel>
        {
            new UserModel { Login = "user1", Password = "password1", Role = Role.admin },
            new UserModel { Login = "user2", Password = "password2", Role = Role.registered },
            new UserModel { Login = "user3", Password = "password3", Role = Role.guest }
        };
            var xmlDoc = new XDocument(new XElement("users",
                expectedUsers.Select(u => new XElement("user",
                    new XElement("login", u.Login),
                    new XElement("password", u.Password),
                    new XElement("role", u.Role)
                ))));
            // Act
            var actualUsers = UserManager.GetAll();

            // Assert
            Assert.IsTrue(actualUsers.ToList().Count() > 0);
        }

        [TestMethod]
        public void Add_ValidUser_AddsUserToXmlDoc()
        {
            // Arrange
            var newUser = new UserModel { Login = "user4", Password = "password4", Role = Role.admin };

            // Act
            UserManager.Add(newUser);

            // Assert
            var actualUser = UserManager.GetAll().FirstOrDefault(x => x.Login == newUser.Login);
            Assert.IsNotNull(actualUser);

            UserManager.Delete(newUser);
        }

        

        [TestMethod]
        public void Update_ValidUser_UpdatesUserInXmlDoc()
        {
            // Arrange
            var existingUser = new UserModel { Login = "user1", Password = "password1", Role = Role.admin };

            var updatedUser = new UserModel { Login = "user1", Password = "newPassword", Role = Role.registered };
            UserManager.Add(updatedUser);
            // Act
            UserManager.Update(updatedUser);

            // Assert
            var actualUser = UserManager.GetAll().FirstOrDefault(x => x.Login == updatedUser.Login);
            Assert.IsNotNull(actualUser);

            UserManager.Delete(updatedUser);
        }
        [TestMethod]
        public void Delete_UserExists_RemovesUser()
        {
            // Arrange
            var user = new UserModel
            {
                Login = "existinguser",
                Password = "password",
                Role = Role.admin
            };
            UserManager.Add(user);

            // Act
            UserManager.Delete(user);

            // Assert
            Assert.IsFalse(UserManager.GetAll().Any(u => u.Login == user.Login));
        }
    }

}