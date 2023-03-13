using System;
using System.Collections.Generic;


namespace App.Services
{
    internal interface ISpectacleServices
    {
        // Вывод всех спектаклей
        IEnumerable<Spectacle> ShowAllSpectacles();

        // Вывод спектакля по дате
        Spectacle ShowSpectacleByDate(DateTime date);

        // Вывод спектакля по названию
        Spectacle ShowSpectacleByName(string name);

        // Удаление спектакля
        void DeleteSpectacle(int spectacleId);

        // Изменение спектакля
        void UpdateSpectacle(int spectacleId, string newName, DateTime newDate, string newDescription);

    }
}
