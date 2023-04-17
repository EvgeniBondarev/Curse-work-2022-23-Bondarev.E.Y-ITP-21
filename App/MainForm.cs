using App.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;



namespace App
{
    public partial class MainForm : Form
    {
        public SpectacleServices spectacleServices = new SpectacleServices();
        public UserServices userServices = new UserServices();
        public TicketServices ticketServices = new TicketServices();
        public LoginForm loginForm;
        public dynamic _user;


        public MainForm()
        {
            InitializeComponent();
            loginForm = new LoginForm(this);

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

        }
        public void CreateUser(UserModel user)
        {
            UserFactory userFactary = new UserFactory(userServices, spectacleServices, ticketServices);

            this._user = userFactary.CreateUser(user);

            ShowWindowToUser(this._user);
            ShowSpectacle();
            userInfo.Text = $"{this._user.Login}";

        }
        public void ShowWindowToUser(Administrator user)
        {
            RegistrBut.Text = "Выйти";
        }
        public void ShowWindowToUser(Registered user)
        {
            RegistrBut.Text = "Выйти";
        }
        public void ShowWindowToUser(Guest user)
        {
            RegistrBut.Text = "Регистрация";
        }



        public void ShowSpectacle()
        {
            dataGridView1.Rows.Clear();

            IEnumerable<SpectacleModel> spectacles = this._user.ViewSpectacle();
 
            foreach (SpectacleModel spectacle in spectacles)
            {
  
                    dataGridView1.Rows.Add(spectacle.Title, spectacle.Genre, spectacle.Author, spectacle.Date.ToString("d"),
                                           $"{spectacle.Categories[Categorias.VIP]} p.", $"{spectacle.Categories[Categorias.Medium]} p.",
                                           $"{spectacle.Categories[Categorias.Standart]} p.");

                mainExpString.Text = "";
            }
        }
        // TODO: переделать под пустое поле
        public void ShowSpectacle(string ganre)
        {
            dataGridView1.Rows.Clear();

            try {
                IEnumerable<SpectacleModel> spectacles = this._user.ViewSpectacle(ganre);


                foreach (SpectacleModel spectacle in spectacles)
                {

                    dataGridView1.Rows.Add(spectacle.Title, spectacle.Genre, spectacle.Author, spectacle.Date.ToString("d"),
                                           $"{spectacle.Categories[Categorias.VIP]} p.", $"{spectacle.Categories[Categorias.Medium]} p.",
                                           $"{spectacle.Categories[Categorias.Standart]} p.");

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
                SpectacleModel spectacle = this._user.ViewSpectacle(date);

                dataGridView1.Rows.Add(spectacle.Title, spectacle.Genre, spectacle.Author, spectacle.Date.ToString("d"),
                                           $"{spectacle.Categories[Categorias.VIP]} p.", $"{spectacle.Categories[Categorias.Medium]} p.",
                                           $"{spectacle.Categories[Categorias.Standart]} p.");

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

            MessageBox.Show(selectedDate.ToString("d"));
            ShowSpectacle(selectedDate);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

       
    }
}
