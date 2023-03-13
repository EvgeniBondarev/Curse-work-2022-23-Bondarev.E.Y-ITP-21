using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services
{
    internal interface IUserServices
    {
        // Метод для вывода всех пользователей
        void GetAllUsers();

        // Метод для вывода пользователя по имени
        void GetUserByName(string name);

        // Метод для обновления пользователя по имени
        void UpdateUserByName(string name);

        // Метод для вывода статуса пользователя 
        void GetUserRoleByName(string name);

        // Метод для удаления пользователя
        void DeleteUser(string name);
    }
}
