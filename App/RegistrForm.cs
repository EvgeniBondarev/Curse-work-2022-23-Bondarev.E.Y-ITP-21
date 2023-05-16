using App.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class RegistrForm : Form
    {
        private UserServices userServices;
        public RegistrForm()
        {
            InitializeComponent();
            userServices = new UserServices();

        }

        private void logInButtog_Click(object sender, EventArgs e)
        {
            if(UserDataValid(newUserNameForm.Text, newUserPasswordForm.Text))
            {
                Registr();
            }
              
        }

        private void RegistrForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            exptRegisterLable.Text = "";
            newUserNameForm.Text = "";
            newUserPasswordForm.PasswordChar = '*';
            newUserPasswordForm.Text = "";
        }
        private void Registr()
        {
            try
            {
               userServices.AddUser(newUserNameForm.Text, newUserPasswordForm.Text, Role.registered);
               this.Close();

            }
            catch (ArgumentException exp)
            {
                    exptRegisterLable.Text = exp.Message;
                    newUserNameForm.Text = newUserPasswordForm.Text = "";
            }
            
        }
        public bool UserDataValid(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                exptRegisterLable.Text = "Заполните поле логина и пароля";
                return false;
            }

            string usernameRegex = @"^.{4,}$";
            string passwordRegex = @"^.{4,}$";
            if (!Regex.IsMatch(username, usernameRegex) || !Regex.IsMatch(password, passwordRegex))
            {
                exptRegisterLable.Text = "Длина логина и пароля должна быть не менее 4 символов";
                return false;
            }

            if (username.Contains(" ") || password.Contains(" "))
            {
                exptRegisterLable.Text = "Логин и пароль не должны содержать пробелов";
                return false;
            }

            string invalidCharsRegex = @"[;']";
            if (Regex.IsMatch(username, invalidCharsRegex) || Regex.IsMatch(password, invalidCharsRegex))
            {
                exptRegisterLable.Text = "Логин и пароль содержат недопустимые символы `;'`";
                return false;
            }
            exptRegisterLable.Text = "";
            return true;
        }

    }
}
