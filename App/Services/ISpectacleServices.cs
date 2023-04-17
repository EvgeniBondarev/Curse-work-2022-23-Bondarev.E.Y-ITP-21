using System;
using System.Collections.Generic;


namespace App.Services
{
    internal interface ISpectacleServices<T>
    {
        // Вывод всех спектаклей
        IEnumerable<T> ShowAllSpectacles();
        T ShowSpectacle(DateTime dateTime);
        IEnumerable<T> ShowSpectacle(string spectacleTitle);

        // Добавление спектакля
        void AddNewSpectacle(string title, string author, string genre, DateTime date, decimal vipPrise, decimal mediumPrice, decimal standartPrice);

        // Изменение спектакля
        void UpdateSpectacle(string title, string author, string genre, DateTime date, decimal vipPrise, decimal mediumPrice, decimal standartPrice);

        // Удаление спектакля
        void DeleteSpectacle(DateTime date);
    }
}
