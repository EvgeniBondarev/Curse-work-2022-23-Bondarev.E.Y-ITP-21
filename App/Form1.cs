using App.Services;
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
            /*
            var xmlFilePath = "C:\\Users\\Evgeni\\Desktop\\CourseWork\\App\\XMLData\\users.xml";
            var xsdFilePath = "C:\\Users\\Evgeni\\Desktop\\CourseWork\\App\\XMLData\\users.xsd";

            UserServices userServices = new UserServices(xmlFilePath, xsdFilePath);

            var allUser = userServices.GetUser();

            foreach (var user in allUser)
            {
                label1.Text += $"Название: {user.Login}\n";
                label1.Text += $"Автор: {user.Password}\n";
                label1.Text += $"Жанр: {user.Role} \n";
            }
            userServices.DeleteUser("Абоба");

            userServices.AddUser("Абоба", "32323223", "admin");

            label1.Text += userServices.GetUser("Абоба").Password;

            userServices.UpdateUserByName("Абоба", "Hello World", "register");

            label1.Text += userServices.GetUser("Абоба").Password;
            */

            /*
            
            SpectacleServices spectacleServices = new SpectacleServices("C:\\Users\\Evgeni\\Desktop\\CourseWork\\App\\XMLData\\spectacle.xml",
                                                                        "C:\\Users\\Evgeni\\Desktop\\CourseWork\\App\\XMLData\\spectacle.xsd");

            Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();

            spectacleServices.AddNewSpectacle("Горе от ума", "Пушкин", "Жанр", new DateTime(2020, 01, 23), 100, 50, 25);
            
            spectacleServices.UpdateSpectacle("Горе от ума", "Пушкин - Пелеметов", "Жанр", new DateTime(2020, 01, 23), 200, 250, 25);

            IEnumerable<SpectacleModel> spectacles = spectacleServices.ShowAllSpectacles();

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
            

            //spectacleServices.DeleteSpectacle(new DateTime(2020, 01, 23));
            /*
            label1.Text += spectacleServices.ShowSpectacle("Горе от ума").Genre;
            label1.Text += spectacleServices.ShowSpectacle(new DateTime(2020, 01, 23)).Genre;
            //spectacleServices.DeleteSpectacle(DateTime.Parse("2015-07-20 18:30:25"));
            */
            SpectacleServices spectacleServices = new SpectacleServices("C:\\Users\\Evgeni\\Desktop\\CourseWork\\App\\XMLData\\spectacle.xml",
                                                                        "C:\\Users\\Evgeni\\Desktop\\CourseWork\\App\\XMLData\\spectacle.xsd");
            UserServices userServices = new UserServices("C:\\Users\\Evgeni\\Desktop\\CourseWork\\App\\XMLData\\users.xml",
                                                         "C:\\Users\\Evgeni\\Desktop\\CourseWork\\App\\XMLData\\users.xsd");
            TicketServices ticketServices = new TicketServices("C:\\Users\\Evgeni\\Desktop\\CourseWork\\App\\XMLData\\tickets.xml",
                                                         "C:\\Users\\Evgeni\\Desktop\\CourseWork\\App\\XMLData\\tickets.xsd");

            UserFactory userFactary = new UserFactory(userServices, spectacleServices, ticketServices);

            User newUser = UserFactory.CreateUser("admin");
            User user = null;
            if(newUser is Administrator) {
                 user = newUser as Administrator;
            }
            else if(newUser is Registered)
            {
                user = newUser as Registered;
            }
            else
            {
                user = newUser as Guest;
            }




            label1.Text += $"{user.GetType()}";


            IEnumerable<SpectacleModel> spectacles = user.ViewSpectacle();

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

            var allUser = user.GetUser(); ;

            foreach (var userw in allUser)
            {
                label1.Text += $"Название: {userw.Login}\n";
                label1.Text += $"Автор: {userw.Password}\n";
                label1.Text += $"Жанр: {userw.Role} \n";
            }

        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
