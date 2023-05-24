using App.Services;
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

namespace App
{
    public partial class LoginForm : Form
    {
        private MainForm _maiForm;
        private RegistrForm _regForm;
        private UserServices _userServices;

        public LoginForm(MainForm mainForm)
        {
            InitializeComponent();
            _userServices = new UserServices();
            _maiForm = mainForm;
            _regForm = new RegistrForm();
        }
        private void RegisterForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
           

            userPasswordForm.PasswordChar = '*';
            exptLable.Text = "";

            

        }
        private void button1_Click(object sender, EventArgs e)
        {
            LogIn();
        }
        private void registerButton_Click(object sender, EventArgs e)
        {
            _regForm.ShowDialog();
        }
        private void skipButton_Click(object sender, EventArgs e)
        {
            UserModel nullUser = new UserModel() { Login = null, Password = null, Role = Role.guest};
            _maiForm.CreateUser(nullUser);
            this.Close();
        }
        
        private void LogIn()
        {
            string userName = userNameForm.Text;
            string userPassword = userPasswordForm.Text;

            if (userName == "" || userPassword == "")
            {
                exptLable.Text = "Неправильно введен логин или пароль.";
                userNameForm.Text = userPasswordForm.Text = "";
            }
            else
            {
                try
                {
                    UserModel user = _userServices.GetUser(userName);

                    if (user.Password == userPassword)
                    {
                        _maiForm.CreateUser(user);
                        userNameForm.Text = userPasswordForm.Text = "";
                        this.Close();
                    }
                    else
                    {
                        exptLable.Text = "Неверный пароль.";
                        userPasswordForm.Text = "";
                    }
                }
                catch (ArgumentException exp)
                {
                    exptLable.Text = exp.Message;
                    userNameForm.Text = userPasswordForm.Text = "";
                }
            }
        }
    }
}
