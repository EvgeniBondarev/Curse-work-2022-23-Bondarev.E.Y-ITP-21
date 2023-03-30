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
        private MaiForm maiForm;
        private RegistrForm regForm;
        private UserServices userServices;

        public LoginForm()
        {
            InitializeComponent();
            userServices = new UserServices();
            maiForm = new MaiForm();
            regForm = new RegistrForm();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            LogIn();
        }
        private void registerButton_Click(object sender, EventArgs e)
        {
            regForm.Show();
        }
        private void skipButton_Click(object sender, EventArgs e)
        {
            UserModel nullUser = new UserModel() { Login = null, Password = null, Role = null };
            maiForm.CreateUser(nullUser);
        }
        private void RegisterForm_Load(object sender, EventArgs e)
        {
            exptLable.Text = "";
            this.Show();
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
                    UserModel user = userServices.GetUser(userName);

                    if (user.Password == userPassword)
                    {
                        maiForm.CreateUser(user);
                        maiForm.Show(); 
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
