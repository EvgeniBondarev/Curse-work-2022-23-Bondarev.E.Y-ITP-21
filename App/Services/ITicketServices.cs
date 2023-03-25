using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services
{
    internal interface ITicketServices<T>
    {
        // Метод для вывода всех пользователей
        IEnumerable<T> GetTicket();

        // Метод для вывода пользователя по имени
        IEnumerable<T> GetTicket(string owner);

        // Метод для вывода пользователя по дате
        T GetTicket(DateTime date);

        // Добавление нового пользователя
        void AddTicket(UserModel userModel, SpectacleModel spectacleModel, Categorias category);

        // Метод для удаления пользователя
        void DeletTicket(UserModel userModel, SpectacleModel spectacleModel, Categorias category);
    }
}
