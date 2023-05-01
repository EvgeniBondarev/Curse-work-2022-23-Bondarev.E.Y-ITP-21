using App.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;

namespace App
{
    public partial class MainForm : Form
    {
        public SpectacleServices spectacleServices = new SpectacleServices();
        public UserServices userServices = new UserServices();
        public TicketServices ticketServices = new TicketServices();
        public LoginForm loginForm;
        public TicketBuyForm ticketBuyForm;
        public dynamic _user;


        public MainForm()
        {
            InitializeComponent();
            loginForm = new LoginForm(this);
            ticketBuyForm = new TicketBuyForm();

            dataGridView1.Columns.Add("Название", "Название");
            dataGridView1.Columns.Add("Жанр", "Жанр");
            dataGridView1.Columns.Add("Автор", "Автор");
            dataGridView1.Columns.Add("Дата", "Дата");
            dataGridView1.Columns.Add("VIP", "VIP");
            dataGridView1.Columns.Add("Ложа", "Ложа");
            dataGridView1.Columns.Add("Галерея", "Галерея");
        }
       

        private void Form1_Load(object sender, EventArgs e)
        {       
            loginForm.ShowDialog();
            dataGridView1.CellClick += dataGridView1_CellClick;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;

        }
        public void CreateUser(UserModel user)
        {
            UserFactory userFactary = new UserFactory(userServices, spectacleServices, ticketServices);

            _user = userFactary.CreateUser(user);

            ShowWindowToUser(_user);
            ShowSpectacle();
            userInfo.Text = $"Пользователь: {_user.Login}";

        }
        public void ShowWindowToUser(Administrator user)
        {
            userInfo.Text += $"\nСтатус: {user.Role}";
            RegistrBut.Text = "Выйти";
            addSpectacle.Visible = true;
        }
        public void ShowWindowToUser(Registered user)
        {
            userInfo.Text += $"\nСтатус: {user.Role}";
            RegistrBut.Text = "Выйти";
            addSpectacle.Visible= false;
        }
        public void ShowWindowToUser(Guest user)
        {
            userInfo.Text += $"\nСтатус: {user.Role}";
            RegistrBut.Text = "Регистрация";
            addSpectacle.Visible = false;
        }



        public void ShowSpectacle()
        {
            dataGridView1.Rows.Clear();

            IEnumerable<SpectacleModel> spectacles = _user.ViewSpectacle();
 
            foreach (SpectacleModel spectacle in spectacles)
            {
  
                    dataGridView1.Rows.Add(spectacle.Title, spectacle.Genre, spectacle.Author, spectacle.Date.ToString("d"),
                                           $"{spectacle.Categories[Categorias.VIP]}", $"{spectacle.Categories[Categorias.Medium]}",
                                           $"{spectacle.Categories[Categorias.Standart]}");

                mainExpString.Text = "";
            }
           
        }
        public void ShowSpectacle(string ganre)
        {
            dataGridView1.Rows.Clear();

            try {
                IEnumerable<SpectacleModel> spectacles = _user.ViewSpectacle(ganre);


                foreach (SpectacleModel spectacle in spectacles)
                {

                    dataGridView1.Rows.Add(spectacle.Title, spectacle.Genre, spectacle.Author, spectacle.Date.ToString("d"),
                                           $"{spectacle.Categories[Categorias.VIP]}", $"{spectacle.Categories[Categorias.Medium]}",
                                           $"{spectacle.Categories[Categorias.Standart]}");

                    mainExpString.Text = "";
                }
            }
            catch(ArgumentException e) { 
                mainExpString.Text = e.Message;
            }
                
            
        }
        public void ShowSpectacle(DateTime date)
        {
            dataGridView1.Rows.Clear();

            try
            {
                SpectacleModel spectacle = _user.ViewSpectacle(date);

                dataGridView1.Rows.Add(spectacle.Title, spectacle.Genre, spectacle.Author, spectacle.Date.ToString("d"),
                                           $"{spectacle.Categories[Categorias.VIP]}", $"{spectacle.Categories[Categorias.Medium]}",
                                           $"{spectacle.Categories[Categorias.Standart]}");

                    mainExpString.Text = "";
                
            }
            catch (ArgumentException e)
            {
                mainExpString.Text = e.Message;
            }


        }


        private void searchSpectacleByGenre_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(searchSpectacleByGenre.Text))
            {
                ShowSpectacle(searchSpectacleByGenre.Text);
            }
            else ShowSpectacle();

        }
        private void searchSpectacleByDate_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = searchSpectacleByDate.Value;
            ShowSpectacle(selectedDate);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;

            if (rowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[rowIndex];

                if(row.Cells[0].Value != null) {
                    Dictionary<Categorias, decimal> thisCategories = new Dictionary<Categorias, decimal>()
                        {
                            { Categorias.VIP, Decimal.Parse(row.Cells[4].Value.ToString())},
                            { Categorias.Medium, Decimal.Parse(row.Cells[5].Value.ToString())},
                            { Categorias.Standart, Decimal.Parse(row.Cells[6].Value.ToString())}
                        };

                    SpectacleModel thisSpectacle = new SpectacleModel
                    {
                        Title = row.Cells[0].Value.ToString(),
                        Genre = row.Cells[1].Value.ToString(),
                        Author = row.Cells[2].Value.ToString(),
                        Date = DateTime.Parse(row.Cells[3].Value.ToString()),
                        Categories = thisCategories
                    };
                    ticketBuyForm.ShowDialog(thisSpectacle, _user);
                    ShowSpectacle();
                }
                else if(_user is Administrator)
                {
                    ticketBuyForm.ShowDialog(_user);
                    ShowSpectacle();
                }

                
            }
        }

        private void addSpectacle_Click(object sender, EventArgs e)
        {
            ticketBuyForm.ShowDialog(_user);
            ShowSpectacle();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
        }
   

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            loginForm.ShowDialog();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void testCheck_Click(object sender, EventArgs e)
        {

        }

        private void ControlPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
