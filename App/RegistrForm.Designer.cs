namespace App
{
    partial class RegistrForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.userPasswordLable = new System.Windows.Forms.Label();
            this.userNameLable = new System.Windows.Forms.Label();
            this.exptRegisterLable = new System.Windows.Forms.Label();
            this.newUserPasswordForm = new System.Windows.Forms.TextBox();
            this.newUserNameForm = new System.Windows.Forms.TextBox();
            this.registerButtog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // userPasswordLable
            // 
            this.userPasswordLable.AutoSize = true;
            this.userPasswordLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userPasswordLable.Location = new System.Drawing.Point(109, 159);
            this.userPasswordLable.Name = "userPasswordLable";
            this.userPasswordLable.Size = new System.Drawing.Size(162, 24);
            this.userPasswordLable.TabIndex = 13;
            this.userPasswordLable.Text = "Введите пароль:";
            // 
            // userNameLable
            // 
            this.userNameLable.AutoSize = true;
            this.userNameLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userNameLable.Location = new System.Drawing.Point(109, 100);
            this.userNameLable.Name = "userNameLable";
            this.userNameLable.Size = new System.Drawing.Size(132, 24);
            this.userNameLable.TabIndex = 12;
            this.userNameLable.Text = "Введите имя:";
            // 
            // exptRegisterLable
            // 
            this.exptRegisterLable.AutoSize = true;
            this.exptRegisterLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exptRegisterLable.ForeColor = System.Drawing.Color.Red;
            this.exptRegisterLable.Location = new System.Drawing.Point(1, 71);
            this.exptRegisterLable.Name = "exptRegisterLable";
            this.exptRegisterLable.Size = new System.Drawing.Size(56, 16);
            this.exptRegisterLable.TabIndex = 11;
            this.exptRegisterLable.Text = "ERROR";
            this.exptRegisterLable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // newUserPasswordForm
            // 
            this.newUserPasswordForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.newUserPasswordForm.Location = new System.Drawing.Point(113, 186);
            this.newUserPasswordForm.Name = "newUserPasswordForm";
            this.newUserPasswordForm.Size = new System.Drawing.Size(178, 29);
            this.newUserPasswordForm.TabIndex = 10;
            // 
            // newUserNameForm
            // 
            this.newUserNameForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.newUserNameForm.Location = new System.Drawing.Point(113, 127);
            this.newUserNameForm.Name = "newUserNameForm";
            this.newUserNameForm.Size = new System.Drawing.Size(178, 29);
            this.newUserNameForm.TabIndex = 9;
            // 
            // registerButtog
            // 
            this.registerButtog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.registerButtog.Location = new System.Drawing.Point(113, 221);
            this.registerButtog.Name = "registerButtog";
            this.registerButtog.Size = new System.Drawing.Size(178, 24);
            this.registerButtog.TabIndex = 8;
            this.registerButtog.Text = "Регистрация\r\n";
            this.registerButtog.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.registerButtog.UseVisualStyleBackColor = true;
            this.registerButtog.Click += new System.EventHandler(this.logInButtog_Click);
            // 
            // RegistrForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(397, 351);
            this.Controls.Add(this.userPasswordLable);
            this.Controls.Add(this.userNameLable);
            this.Controls.Add(this.exptRegisterLable);
            this.Controls.Add(this.newUserPasswordForm);
            this.Controls.Add(this.newUserNameForm);
            this.Controls.Add(this.registerButtog);
            this.Name = "RegistrForm";
            this.Text = "Регистрация";
            this.Load += new System.EventHandler(this.RegistrForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label userPasswordLable;
        private System.Windows.Forms.Label userNameLable;
        private System.Windows.Forms.Label exptRegisterLable;
        private System.Windows.Forms.TextBox newUserPasswordForm;
        private System.Windows.Forms.TextBox newUserNameForm;
        private System.Windows.Forms.Button registerButtog;
    }
}