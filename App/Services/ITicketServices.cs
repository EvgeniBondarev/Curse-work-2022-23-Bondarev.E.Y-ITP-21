using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace App.Services
{
    internal interface ITicketServices<T>
    {
        // Метод для вывода всех пользователей
        IEnumerable<T> GetTicket();

        // Метод для вывода пользователя по имени
        IEnumerable<T> GetTicket(string owner);

        // Метод для вывода пользователя по дате
        T GetTicket(int id);

        // Добавление нового пользователя
        void AddTicket(string userName, SpectacleModel spectacleModel, Categorias category);

        // Метод для удаления пользователя
        void DeletTicket(int id);
    }
}
