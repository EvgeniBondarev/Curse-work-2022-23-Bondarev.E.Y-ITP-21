using System;
using System.Collections.Generic;


namespace App.Services
{
    internal interface ISpectacleServices
    {
        // Вывод всех спектаклей
        IEnumerable<SpectacleModel> ShowAllSpectacles();
        SpectacleModel ShowSpectacle(DateTime dateTime);
        SpectacleModel ShowSpectacle(string spectacleTitle);

        // Добавление спектакля
        void AddNewSpectacle(string title, string author, string genre, DateTime date, Dictionary<string, int> categories);

        // Изменение спектакля
        void UpdateSpectacle(string title, string author, string genre, DateTime date, Dictionary<string, int> categories);

        // Удаление спектакля
        void DeleteSpectacle(DateTime date);




    }
}
