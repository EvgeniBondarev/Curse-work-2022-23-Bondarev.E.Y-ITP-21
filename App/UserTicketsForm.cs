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
    public partial class UserTicketsForm : Form
    {
        private TicketServices _ticketServices;
        private TicketServicesXmlLoggingDecorator _ticketServicesLog;
        private string _userName;

        private TicketModel _activeTicket;
        public UserTicketsForm()
        {
            InitializeComponent();
            _ticketServices = new TicketServices();
            _ticketServicesLog = new TicketServicesXmlLoggingDecorator(_ticketServices);

            userTicketsGridView.ReadOnly = true;
            
            userTicketsGridView.Columns.Add("№", "№");
            userTicketsGridView.Columns.Add("Название", "Название");
            userTicketsGridView.Columns.Add("Дата", "Дата");
            userTicketsGridView.Columns.Add("Категория", "Категория");
            userTicketsGridView.Columns.Add("Цена", "Цена");

            userTicketsGridView.Columns[0].Width = 30;
        }


        private void UserTicketsForm_Load(object sender, EventArgs e)
        {

        }
        public new DialogResult ShowDialog(Administrator user, string userName)
        {
            _userName = userName;
            userTicketGroupBox.Text = $"Билеты пользователя {_userName}";

            ShowTickets();
            return base.ShowDialog();
        }
        public new DialogResult ShowDialog(Registered user)
        {
            _userName = user.Login;

            userTicketGroupBox.Text = $"Билеты пользователя {_userName}";

            ShowTickets();
            return base.ShowDialog();
        }
        public new DialogResult ShowDialog(User user)
        {
            return base.ShowDialog();
        }

        public new void ShowTickets()
        {
            userTicketsGridView.Rows.Clear();

            IEnumerable<TicketModel> tickets = _ticketServicesLog.GetTicket(_userName);

            foreach (TicketModel ticket in tickets)
            {

                userTicketsGridView.Rows.Add(ticket.Id, ticket.Title, ticket.Date.ToString("d"), ticket.Category, ticket.Price);

            }
            
        }
        private void userTicketsGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = userTicketsGridView.Rows[e.RowIndex];

                _activeTicket = _ticketServicesLog.GetTicket(Int32.Parse(row.Cells[0].Value.ToString()));  
            }
        }

        private void delUserTicketButton_Click(object sender, EventArgs e)
        {
            if (_activeTicket != null)
            {
                DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить билет на спектакль \"" + _activeTicket.Title + "\"?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _ticketServicesLog.DeletTicket(_activeTicket.Id);

                    ShowTickets();
                    
                }
            }
            else
            {
                MessageBox.Show("Выберите спектакль для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
