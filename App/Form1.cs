using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            var xmlFilePath = "C:\\Users\\Evgeni\\Desktop\\CourseWork\\App\\XMLData\\users.xml";
            var userManager = new UserManager(xmlFilePath);
            var allUsers = userManager.GetAll();

            // Добавляем нового пользователя
            var newUser = new User { Login = "asdasd", Password = "12345", Role = "registered" };
 
            // Обновляем информацию о пользователе
            userManager.Update(new User { Login = "asdasd", Password = "12345", Role = "registered" });

            // Удаляем пользователя
            userManager.Delete(new User { Login = "asdasd", Password = "12345", Role = "registered" });

            

            // Создаем экземпляр менеджера документа
            var xmlManager = new SpectacleManager("C:\\Users\\Evgeni\\Desktop\\CourseWork\\App\\XMLData\\spectacle.xml");

            // Получаем список всех спектаклей из документа
            var spectacles = xmlManager.GetAll();

            // Выводим на консоль информацию о каждом спектакле
            foreach (var spectacle in spectacles)
            {
                label1.Text += $"Название: {spectacle.Title}\n";
                label1.Text += $"Автор: {spectacle.Author}\n";
                label1.Text += $"Жанр: {spectacle.Genre} \n";
                label1.Text += $"Дата: {spectacle.Date} \n";
                label1.Text += $"Категории:";

                foreach (var category in spectacle.Categories)
                {
                    label1.Text += $"{category.Key}: {category.Value}\n";
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
    }
}
