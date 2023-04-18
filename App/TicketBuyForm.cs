using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace App
{
    
    public partial class TicketBuyForm : Form
    {
        private SpectacleModel _spectacleModel;
        private dynamic _owner;
      
        public TicketBuyForm()
        {
            InitializeComponent();
        }

        private void SpectacleTitle_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void TicketBuyForm_Load(object sender, EventArgs e)
        {
            this.ClientSize = new Size(311, 334);
            AdminBuyPanel.Location = new Point(0, 0);
            RegisterBuyPanel.Location = new Point(0, 0);
        }
        // TODO: Если другая дата, то создать новый спектакль
        public new DialogResult ShowDialog(SpectacleModel thisSpectacle, Administrator user)
        {
            AdminBuyPanel.Visible = true;
            RegisterBuyPanel.Visible = false;

            _spectacleModel = thisSpectacle;
            _owner = user;

            newSpectacleName.Text = _spectacleModel.Title;
            newAuthorName.Text = _spectacleModel.Author;
            newGenreName.Text = _spectacleModel.Genre;
            newDateName.Value = _spectacleModel.Date;

            newVIPPrice.Value = _spectacleModel.Categories[Categorias.VIP];
            newMediumPrice.Value = _spectacleModel.Categories[Categorias.Medium];
            newStandartPrice.Value = _spectacleModel.Categories[Categorias.Standart];

            return base.ShowDialog();
        }
        public new DialogResult ShowDialog(SpectacleModel thisSpectacle, Registered user)
        {

            AdminBuyPanel.Visible = false;
            RegisterBuyPanel.Visible = true;

            _spectacleModel = thisSpectacle;
            _owner = user;

            SpectacleTitle.Text = _spectacleModel.Title;
            SpectacleAuthor.Text = $"Автор: {_spectacleModel.Author}";
            SpectacleGenre.Text = $"Жанр: {_spectacleModel.Genre}";
            SpectacleDate.Text = $"Дата: {_spectacleModel.Date.ToString("d")}";

            CategoriesRadio1.Text = $"VIP - {_spectacleModel.Categories[Categorias.VIP]}";
            CategoriesRadio2.Text = $"Ложа - {_spectacleModel.Categories[Categorias.Medium]}";
            CategoriesRadio3.Text = $"Галерея - {_spectacleModel.Categories[Categorias.Standart]}";

            return base.ShowDialog();
        }
        public new void ShowDialog(SpectacleModel thisSpectacle, Guest user)
        {

        }
        private void BuyTicket_Click(object sender, EventArgs e)
        {
            try{
                Categorias category = new Categorias();
                if (CategoriesRadio1.Checked) category = Categorias.VIP;
                
                else if (CategoriesRadio2.Checked) category = Categorias.Medium;

                else if (CategoriesRadio3.Checked) category = Categorias.Medium;
                
                else throw new ArgumentException("Ни одина категория не выбрана");
    

                _owner.AddTicket(_owner.Login, _spectacleModel.Date, category);
                this.Close();
            }
            catch(ArgumentException exp)
            {
                MessageBox.Show(exp.Message);
            }
            
        }
        private void changeTiket_Click(object sender, EventArgs e)
        {
            try
            {
                _owner.UpdateSpectacle(newSpectacleName.Text, newAuthorName.Text, newGenreName.Text, newDateName.Value,
                                   newVIPPrice.Value, newMediumPrice.Value, newStandartPrice.Value);
                this.Close();
            }
            catch (ArgumentException exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
        private void delSpectacle_Click(object sender, EventArgs e)
        {
            try
            {
                _owner.DeleteSpectacle(newDateName.Value);
                this.Close();
            }
            catch (ArgumentException exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void newDateName_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                _owner.ViewSpectacle(newDateName.Value);
                changeTiket.Text = "Изменить";
                changeTiket.Location = new Point(7, 297);
                delSpectacle.Visible = true;
            }
            catch
            {
                changeTiket.Text = "Добавить";
                changeTiket.Location = new Point((this.ClientSize.Width - changeTiket.Width) / 2, 297);
                delSpectacle.Visible = false;
            }
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void AdminBuyPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RegisterBuyPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        
    }
}
