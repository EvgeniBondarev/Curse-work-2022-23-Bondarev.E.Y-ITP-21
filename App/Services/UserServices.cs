using System;
using System.Collections.Generic;
using System.Linq;


namespace App.Services
{
    internal class UserServices : IUserServices<UserModel>
    {
        private UserManager _userManager;

        public UserServices(string xmlFile, string xsdFile)
        {
            _userManager = new UserManager(xmlFile, xsdFile);
        }
        

        public IEnumerable<UserModel> GetUser()
        {
            return _userManager.GetAll();
        }

        public UserModel GetUser(string userLogin)
        {
            UserModel user = _userManager.GetAll().FirstOrDefault(x => x.Login == userLogin);
            if (user == null)
            {
                throw new ArgumentException($"Пользователь {userLogin} не найден.");
            }
            return user;
        }
        public void AddUser(string login, string password, string role)
        {
            _userManager.Add(CreateUserElement(login, password, role));
        }
        public void UpdateUserByName(string name, string newPassword, string newRole)
        {
            UserModel thisUser = _userManager.GetAll().FirstOrDefault(x => x.Login == name);
            if (thisUser != null)
            {

                _userManager.Update(CreateUserElement(name, newPassword, newRole));
            }
            else throw new ArgumentException($"Пользователь с логином {thisUser.Login} не найден.");
        }

        public void DeleteUser(string name)
        {
            UserModel userToDelete = _userManager.GetAll().FirstOrDefault(x => x.Login == name);
            if (userToDelete != null)
            {
                _userManager.Delete(userToDelete);
            }
            else throw new ArgumentException($"Пользователь с логином {userToDelete.Login} не найден.");
        }

        private UserModel CreateUserElement(string login, string password, string role)
        {
            return new UserModel
            {
                Login = login, 
                Password = password, 
                Role = role
            };
        }

        
    }
}
