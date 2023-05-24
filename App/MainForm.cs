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
using App.Logs;
using Microsoft.Office.Interop.Excel;

namespace App
{
    public partial class MainForm : Form
    {
        public SpectacleServices spectacleServices = new SpectacleServices();
        public UserServices userServices = new UserServices();
        public TicketServices ticketServices = new TicketServices();

        public LoginForm loginForm;
        public TicketBuyForm ticketBuyForm;
        public UserTicketsForm userTicketsForm;

        public dynamic _user;


        public MainForm()
        {
            InitializeComponent();

            loginForm = new LoginForm(this);
            ticketBuyForm = new TicketBuyForm();
            userTicketsForm = new UserTicketsForm();

            spectacleGridView.ReadOnly = true;
            spectacleGridView.Columns.Add("Название", "Название");
            spectacleGridView.Columns.Add("Свободных мест", "Свободных мест");
            spectacleGridView.Columns.Add("Жанр", "Жанр");
            spectacleGridView.Columns.Add("Автор", "Автор");
            spectacleGridView.Columns.Add("Дата", "Дата");
            spectacleGridView.Columns.Add("VIP", "VIP");
            spectacleGridView.Columns.Add("Ложа", "Ложа");
            spectacleGridView.Columns.Add("Галерея", "Галерея");

            userGridView.ReadOnly = true;
            userGridView.Columns.Add("Имя", "Имя");
            userGridView.Columns.Add("Пароль", "Пароль");
            userGridView.Columns.Add("Роль", "Роль");

            userTicketsListBox.ReadOnly = true;

            RemoveAdminPanel();

        }


        private void Form1_Load(object sender, EventArgs e)
        {

            loginForm.ShowDialog();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            spectacleGridView.CellClick += dataGridView1_CellClick;
            spectacleGridView.ColumnHeaderMouseClick += dataGridView_ColumnHeaderMouseClick;

            spectacleGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            spectacleGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;

            userInfo.MouseDown += new MouseEventHandler(InitializeContextMenu);
            userRolePictureBox.MouseDown += new MouseEventHandler(InitializeContextMenu);

        }
        public void CreateUser(UserModel user)
        {
            UserFactory userFactary = new UserFactory(userServices, spectacleServices, ticketServices);

            _user = userFactary.CreateUser(user);

            ShowWindowToUser(_user);
            ShowSpectacle();


        }
        public void ShowWindowToUser(Administrator user)
        {
            userInfo.Visible = true;
            userInfo.Text = $"Пользователь: {_user.Login}";
            RegistrBut.Text = "Выйти";
            addSpectacle.Visible = true;
            permissionTabControl.TabPages[0].Text = "Управление спектаклями";
            userRolePictureBox.Image = Image.FromFile("C:\\Users\\Evgeni\\Desktop\\CourseWork\\App\\img\\icons\\admin.png");

            ShowUsers();
            ShowAdminPanel();
        }
        public void ShowWindowToUser(Registered user)
        {
            userInfo.Visible = true;
            userInfo.Text = $"Пользователь: {_user.Login}";
            RegistrBut.Text = "Выйти";
            addSpectacle.Visible = false;
            permissionTabControl.TabPages[0].Text = "Выбор спектаклей";
            RemoveAdminPanel();
            userRolePictureBox.Image = Image.FromFile("C:\\Users\\Evgeni\\Desktop\\CourseWork\\App\\img\\icons\\user.png");
        }


        public void ShowWindowToUser(Guest user)
        {
            userInfo.Visible = false;
            RegistrBut.Text = "Регистрация";
            addSpectacle.Visible = false;
            permissionTabControl.TabPages[0].Text = "Выбор спектаклей";
            RemoveAdminPanel();
            userRolePictureBox.Image = null;

        }

        private void InitializeContextMenu(object sender, MouseEventArgs e)
        {
            if (_user is Registered || _user is Administrator)
            {
                userInfoContextMenu.Items.Clear();

                userInfoContextMenu.Items.Add($"Имя: {_user.Login}");



                if (_user is Registered)
                {
                    userInfoContextMenu.Items.Add($"Роль: Пользователь");

                    ToolStripButton showUserTicketsButton = new ToolStripButton();
                    showUserTicketsButton.Text = "Мои билеты";
                    showUserTicketsButton.Click += new EventHandler(ticketMenuItem_Click);

                    showUserTicketsButton.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;

                    userInfoContextMenu.Items.Add(showUserTicketsButton);
                }
                else if (_user is Administrator)
                {
                    userInfoContextMenu.Items.Add($"Роль: Администратор");
                    ToolStripButton showUserTicketsButton = new ToolStripButton();
                    showUserTicketsButton.Text = "Сформировать отчет";
                    showUserTicketsButton.Click += new EventHandler(ticketLog_Click);

                    showUserTicketsButton.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;

                    userInfoContextMenu.Items.Add(showUserTicketsButton);
                }

                userInfoContextMenu.Name = "Информация о пользователе";

                userInfoContextMenu.Show(userInfo, e.Location);
            }
        }
        private void ticketMenuItem_Click(object sender, EventArgs e)
        {
            if (_user is Registered)
            {
                userTicketsForm.ShowDialog(_user);
                ShowSpectacle();
            }
        }
        private void ticketLog_Click(object sender, EventArgs e)
        {
            if (_user is Administrator)
            {
                DialogResult result = MessageBox.Show("Cформировать статистический отчёт о продажах билетов?", "Формирование отчета",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    XmlToExcel.CreateTable();
                }
                else if (result == DialogResult.No)
                {

                }
            }

        }

        public void ShowSpectacle()
        {
            if (_user is Administrator || _user is Registered || _user is Guest)
            {
                spectacleGridView.Rows.Clear();

                IEnumerable<SpectacleModel> spectacles = _user.ViewSpectacle();

                foreach (SpectacleModel spectacle in spectacles)
                {
                    spectacleGridView.Rows.Add(spectacle.Title, spectacle.FreePlace, spectacle.Genre, spectacle.Author, spectacle.Date.ToString("d"),
                                           $"{spectacle.Categories[Categorias.VIP]}", $"{spectacle.Categories[Categorias.Medium]}",
                                           $"{spectacle.Categories[Categorias.Standart]}");
                    mainExpString.Text = "";
                }
            }

        }
        public void ShowSpectacle(string ganre)
        {
            if (_user is Administrator || _user is Registered)
            {
                spectacleGridView.Rows.Clear();

                try
                {
                    IEnumerable<SpectacleModel> spectacles = _user.ViewSpectacle(ganre);


                    foreach (SpectacleModel spectacle in spectacles)
                    {

                        spectacleGridView.Rows.Add(spectacle.Title, spectacle.FreePlace, spectacle.Genre, spectacle.Author, spectacle.Date.ToString("d"),
                                               $"{spectacle.Categories[Categorias.VIP]}", $"{spectacle.Categories[Categorias.Medium]}",
                                               $"{spectacle.Categories[Categorias.Standart]}");

                        mainExpString.Text = "";
                    }
                }
                catch (ArgumentException e)
                {
                    mainExpString.Text = e.Message;
                }
            }


        }
        public void ShowSpectacle(DateTime date)
        {
            if (_user is Administrator || _user is Registered)
            {
                spectacleGridView.Rows.Clear();

                try
                {
                    SpectacleModel spectacle = _user.ViewSpectacle(date);

                    spectacleGridView.Rows.Add(spectacle.Title, spectacle.Genre, spectacle.Author, spectacle.Date.ToString("d"),
                                               $"{spectacle.Categories[Categorias.VIP]}", $"{spectacle.Categories[Categorias.Medium]}",
                                               $"{spectacle.Categories[Categorias.Standart]}");

                    mainExpString.Text = "";

                }
                catch (ArgumentException e)
                {
                    mainExpString.Text = e.Message;
                }
            }
        }
        private void dataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.ColumnIndex == 1) {
                DataGridViewColumn newColumn = spectacleGridView.Columns[1];
                DataGridViewColumn oldColumn = spectacleGridView.SortedColumn;
                ListSortDirection direction;

                direction = ListSortDirection.Descending;

                spectacleGridView.Sort(newColumn, direction);
            }
            
        }
        private void ShowUsers()
        {
            if (_user is Administrator)
            {
                userGridView.Rows.Clear();

                IEnumerable<UserModel> users = _user.GetUser();

                foreach (UserModel user in users)
                {
                    userGridView.Rows.Add(user.Login, user.Password, user.Role == Role.registered ? "Пользователь" : "Администратор");
                }
            }
        }
        private void RemoveAdminPanel()
        {
            if (permissionTabControl.TabPages.Count == 2) {
                permissionTabControl.TabPages.Remove(AdminTabPanel);
            }

        }
        private void ShowAdminPanel() {
            if (permissionTabControl.TabPages.Count == 1)
            {
                permissionTabControl.TabPages.Add(AdminTabPanel);
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
            if (_user is Registered || _user is Administrator)
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = spectacleGridView.Rows[e.RowIndex];

                    if (row.Cells[3].Value != null)
                    {
                        SpectacleModel thisSpectacle = _user.ViewSpectacle(DateTime.Parse(row.Cells[4].Value.ToString()));
                        ticketBuyForm.ShowDialog(thisSpectacle, _user);
                    }
                    else ticketBuyForm.ShowDialog(_user);

                }
                else if (_user is Administrator)
                {
                    ticketBuyForm.ShowDialog(_user);
                }
                ShowSpectacle();
            }
        }

        private void userGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_user is Administrator)
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = userGridView.Rows[e.RowIndex];

                    if (row.Cells[0].Value != null)
                    {
                        UserModel thisUser = _user.GetUser(row.Cells[0].Value.ToString());
                        userLoginBox.Text = thisUser.Login;
                        userPasswordBox.Text = thisUser.Password;
                        userRoleBox.Text = thisUser.Role == Role.registered ? "Пользователь" : "Администратор";
                        delUserButton.Visible = true;

                        ShowTicketsList(thisUser.Login);
                    }


                }
                else if (_user is Administrator)
                {
                    userLoginBox.Text = "";
                    userPasswordBox.Text = "";
                    userRoleBox.Text = "";
                    delUserButton.Visible = false;
                }
            }

        }

        private void addSpectacle_Click(object sender, EventArgs e)
        {
            if (_user is Administrator)
            {
                ticketBuyForm.ShowDialog(_user);
                ShowSpectacle();
            }
        }
        private void RegistrBut_Click(object sender, EventArgs e)
        {
            loginForm.ShowDialog();
        }
        private void userLoginBox_TextChanged(object sender, EventArgs e)
        {
            if (_user is Administrator)
            {
                try
                {
                    UserModel newUser = _user.GetUser(userLoginBox.Text);
                    userPasswordBox.Text = newUser.Password;
                    userRoleBox.Text = newUser.Role == Role.registered ? "Пользователь" : "Администратор";
                    addUserButton.Text = "Изменить";
                    delUserButton.Visible = true;

                    ShowTicketsList(newUser.Login);


                }
                catch (ArgumentException userNull)
                {
                    userPasswordBox.Text = "";
                    userRoleBox.Text = "";
                    addUserButton.Text = "Добавить";

                    delUserButton.Visible = false;
                    userTicketsLable.Visible = false;
                    userTicketsListBox.Clear();
                }
            }
        }
        private void ShowTicketsList(string userLogin)
        {
            if (_user is Administrator || _user is Registered)
            {
                userTicketsLable.Visible = true;
                userTicketsLable.Text = $"Билеты пользователя `{userLogin}`:";

                userTicketsListBox.Clear();

                IEnumerable<TicketModel> tickets = _user.GetTicket(userLogin);
                foreach (TicketModel ticket in tickets)
                {
                    userTicketsListBox.Text += ($"Название:{ticket.Title}\nДата: {ticket.Date.ToString("d")}\nКатегория: {ticket.Category}\nЦена: {ticket.Price} р.\n\n");
                }
            }

        }


        private void AddUserButton_Click(object sender, EventArgs e)
        {
            if (_user is Administrator)
            {
                if (addUserButton.Text == "Добавить")
                {
                    _user.AddeUser(userLoginBox.Text, userPasswordBox.Text, userRoleBox.Text == "Пользователь" ? Role.registered : Role.admin);
                    ShowUsers();
                }
                else if (addUserButton.Text == "Изменить")
                {
                    _user.UpdateUser(userLoginBox.Text, userPasswordBox.Text, userRoleBox.Text == "Пользователь" ? Role.registered : Role.admin);
                    ShowUsers();
                }
            }

        }
        private void delUserButton_Click(object sender, EventArgs e)
        {
            if (_user is Administrator)
            {
                try
                {
                    if (userLoginBox.Text != _user.Login)
                    {
                        _user.DeleteUser(userLoginBox.Text);
                        ShowUsers();
                    }
                    else MessageBox.Show("Невозможно удалить данного пользователя!");
                }
                catch (ArgumentException delUserExp)
                {
                    MessageBox.Show(delUserExp.Message);
                }
            }
        }
        private void changeTicketsButton_Click(object sender, EventArgs e)
        {
            if (_user is Administrator || _user is Registered)
            {
                userTicketsForm.ShowDialog(_user, userLoginBox.Text);
                ShowTicketsList(userLoginBox.Text);
                ShowSpectacle();
            }

        }
    }
}
