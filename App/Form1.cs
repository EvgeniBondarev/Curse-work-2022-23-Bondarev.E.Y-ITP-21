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

            Administrator administrator = new Administrator(spectacleServices, userServices, ticketServices);

            //administrator.AddTicket("Абоба1", new DateTime(2020, 01, 23), Categorias.Medium);

            var tickers = administrator.GetTicket();

            dataGridView1.Columns.Add("Name", "Имя");
            dataGridView1.Columns.Add("Author", "Автор");
            dataGridView1.Columns.Add("Ganre", "Жанр");
            dataGridView1.Columns.Add("Price", "Цена");
            dataGridView1.Columns.Add("Date", "Дата");
            

            foreach (TicketModel ticket in tickers)
            {
                dataGridView1.Rows.Add(ticket.Owner, ticket.Title,  ticket.Category, ticket.Price, ticket.Date);
            }

            foreach (var tiket in tickers)
            {
                label1.Text += $"Название: {tiket.Owner}\n";
                label1.Text += $"Автор: {tiket.Price}\n";
                label1.Text += $"Жанр: {tiket.Category} \n";
                label1.Text += $"Дата: {tiket.Date} \n";       
            }
        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
