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
            CollectionAssert.AreEqual(expectedUsers, actualUsers.ToList());
        }

        [TestMethod]
        public void Add_ValidUser_AddsUserToXmlDoc()
        {
            // Arrange
            var newUser = new UserModel { Login = "user4", Password = "password4", Role = Role.User };
            var xmlDoc = new XDocument(new XElement("users"));

            // Act
            UserManager.Add(newUser);

            // Assert
            var actualUser = xmlDoc.Root.Elements("user")
                .SingleOrDefault(u => u.Element("login").Value == newUser.Login);
            Assert.IsNotNull(actualUser);
            Assert.AreEqual(newUser.Password, actualUser.Element("password").Value);
            Assert.AreEqual(newUser.Role.ToString(), actualUser.Element("role").Value);
        }

        [TestMethod]
        public void Add_InvalidUser_ThrowsArgumentException()
        {
            // Arrange
            var existingUser = new UserModel { Login = "user1", Password = "password1", Role = Role.admin };
            var xmlDoc = new XDocument(new XElement("users",
                new XElement("user",
                    new XElement("login", existingUser.Login),
                    new XElement("password", existingUser.Password),
                    new XElement("role", existingUser.Role)
                    )));

            var invalidUser = new UserModel { Login = "user1", Password = "password2", Role = Role.registered };

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => UserManager.Add(invalidUser));
        }

        [TestMethod]
        public void Update_ValidUser_UpdatesUserInXmlDoc()
        {
            // Arrange
            var existingUser = new UserModel { Login = "user1", Password = "password1", Role = Role.admin };
            var xmlDoc = new XDocument(new XElement("users",
                new XElement("user",
                    new XElement("login", existingUser.Login),
                    new XElement("password", existingUser.Password),
                    new XElement("role", existingUser.Role)
                )));

            var updatedUser = new UserModel { Login = "user1", Password = "newPassword", Role = Role.registered };

            // Act
            UserManager.Update(updatedUser);

            // Assert
            var actualUser = xmlDoc.Root.Elements("user")
                .SingleOrDefault(u => u.Element("login").Value == updatedUser.Login);
            Assert.IsNotNull(actualUser);
            Assert.AreEqual(updatedUser.Password, actualUser.Element("password").Value);
            Assert.AreEqual(updatedUser.Role.ToString(), actualUser.Element("role").Value);
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