using System;
using System.Collections.Generic;
using System.Linq;


namespace App.Services
{
    public class UserServices : IUserServices<UserModel>
    {
        public UserServices()
        {
        }
        
        public IEnumerable<UserModel> GetUser()
        {
            return UserManager.GetAll();
        }

        public UserModel GetUser(string userLogin)
        {
            UserModel user = UserManager.GetAll().FirstOrDefault(x => x.Login == userLogin);
            if (user != null)
            {
                return user;
            }
            throw new ArgumentException($"Пользователь '{userLogin}' не найден.");
            
        }
        public void AddUser(string login, string password, string role)
        {
            UserManager.Add(CreateUserElement(login, password, role));
        }
        public void UpdateUserByName(string name, string newPassword, string newRole)
        {
            UserModel thisUser = UserManager.GetAll().FirstOrDefault(x => x.Login == name);
            if (thisUser != null)
            {

                UserManager.Update(CreateUserElement(name, newPassword, newRole));
            }
            else throw new ArgumentException($"Пользователь с логином '{thisUser.Login}' не найден.");
        }

        public void DeleteUser(string name)
        {
            UserModel userToDelete = UserManager.GetAll().FirstOrDefault(x => x.Login == name);
            if (userToDelete != null)
            {
                UserManager.Delete(userToDelete);
            }
            else throw new ArgumentException($"Пользователь с логином '{userToDelete.Login}' не найден.");
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
