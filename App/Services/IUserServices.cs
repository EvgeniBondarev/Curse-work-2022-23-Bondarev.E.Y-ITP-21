using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services
{
    internal interface IUserServices<T>
    {
        // Метод для вывода всех пользователей
        IEnumerable<T> GetUser();

        // Метод для вывода пользователя по имени
        UserModel GetUser(string name);

        // Добавление нового пользователя
        void AddUser(string login, string password, string role);

        // Метод для обновления пользователя по имени
        void UpdateUserByName(string name, string newPassword, string newRole);

        // Метод для удаления пользователя
        void DeleteUser(string name);
    }
}
