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
    public partial class RegistrForm : Form
    {
        private string xmlFilePath = "C:\\Users\\Evgeni\\Desktop\\CourseWork\\App\\XMLData\\users.xml";
        private string xsdFilePath = "C:\\Users\\Evgeni\\Desktop\\CourseWork\\App\\XMLData\\users.xsd";
        private UserServices userServices;
        public RegistrForm()
        {
            InitializeComponent();
            userServices = new UserServices();

        }

        private void logInButtog_Click(object sender, EventArgs e)
        {
            
            Registr();     
        }

        private void RegistrForm_Load(object sender, EventArgs e)
        {
            exptRegisterLable.Text = "";
            newUserNameForm.Text = "";
            newUserPasswordForm.Text = "";
        }
        private void Registr()
        {
            string newUserName = newUserNameForm.Text;
            string newUserPassword = newUserPasswordForm.Text;

            if (newUserName == "" || newUserPassword == "")
            {
                exptRegisterLable.Text = "Неправильно введен логин или пароль.";
                newUserNameForm.Text = newUserPasswordForm.Text = "";
            }
            else
            {
                try
                {
                    userServices.AddUser(newUserName, newUserPassword, "registered");
                    this.Close();

                }
                catch (ArgumentException exp)
                {
                    exptRegisterLable.Text = exp.Message;
                    newUserNameForm.Text = newUserPasswordForm.Text = "";
                }
            }
        }

    }
}
