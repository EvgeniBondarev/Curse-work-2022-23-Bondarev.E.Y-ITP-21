
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Curse_work
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            /*
            var xmlFilePath = "C:\\Users\\Evgeni\\Desktop\\Course Work\\Project\\Curse work\\XMLData\\users.xml";
            var userManager = new UserManager(xmlFilePath);
            var allUsers = userManager.GetAll();

            // Добавляем нового пользователя
            var newUser = new User { Login = "alex", Password = "12345", Role = "registered" };
            userManager.Add(newUser);

            
            // Обновляем информацию о пользователе
            var userToUpdate = allUsers.FirstOrDefault(u => u.Login == "petr");
            if (userToUpdate != null)
            {
                userToUpdate.Password = "newPassword";
                userToUpdate.Role = "admin";
                userManager.Update(userToUpdate);
            }

            // Удаляем пользователя
            var userToDelete = allUsers.FirstOrDefault(u => u.Login == "guest");
            if (userToDelete != null)
            {
                userManager.Delete(userToDelete);
            }
            */

            // Создаем экземпляр менеджера документа
            var xmlManager = new SpectacleManager("C:\\Users\\Evgeni\\Desktop\\Course Work\\Project\\Curse work\\XMLData\\spectacle.xml");

            // Получаем список всех спектаклей из документа
            var spectacles = xmlManager.GetAll();

            // Выводим на консоль информацию о каждом спектакле
            foreach (var spectacle in spectacles)
            {
                NewText.Text += $"Название: {spectacle.Title}\n";
                NewText.Text += $"Автор: {spectacle.Author}\n";
                NewText.Text += $"Жанр: {spectacle.Genre} \n";
                NewText.Text += $"Дата: {spectacle.Date} \n";
                NewText.Text += $"Категории:";

                foreach (var category in spectacle.Categories)
                {
                    NewText.Text += $"{category.Key}: {category.Value}\n";
                }

   
            }

            // Добавляем новый спектакль в документ
            var newSpectacle = new Spectacle
            {
                Title = "Горе от ума",
                Author = "А.С. Грибоедов",
                Genre = "комедия",
                Date = DateTime.Parse("2022-02-15 19:00:00"),
                Categories = new Dictionary<string, int>
    {
        {"VIP", 20},
        {"Стандарт", 200},
        {"Бюджет", 400}
    }
            };

            xmlManager.Add(newSpectacle);

            // Обновляем информацию о существующем спектакле
            var spectacleToUpdate = new Spectacle
            {
                Title = "Гамлет",
                Author = "Уильям Шекспир",
                Genre = "трагедия",
                Date = DateTime.Parse("2021-09-01 19:30:00"),
                Categories = new Dictionary<string, int>
    {
        {"VIP", 10},
        {"Стандарт", 100},
        {"Бюджет", 200}
    }
            };

            xmlManager.Update(spectacleToUpdate);

            // Удаляем спектакль из документа
            var spectacleToDelete = new Spectacle
            {
                Title = "Мастер и Маргарита",
                Author = "Михаил Булгаков",
                Genre = "фантастика",
                Date = DateTime.Parse("2021-09-02 19:00:00"),
                Categories = new Dictionary<string, int>
    {
        {"VIP", 10},
        {"Стандарт", 100},
        {"Бюджет", 200}
    }
            };

            xmlManager.Delete(spectacleToDelete);


        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
