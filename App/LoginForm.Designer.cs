namespace App
{
    partial class LoginForm
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
            this.logInButtog = new System.Windows.Forms.Button();
            this.userNameForm = new System.Windows.Forms.TextBox();
            this.userPasswordForm = new System.Windows.Forms.TextBox();
            this.exptLable = new System.Windows.Forms.Label();
            this.skipButton = new System.Windows.Forms.Button();
            this.registerButton = new System.Windows.Forms.Button();
            this.userNameLable = new System.Windows.Forms.Label();
            this.userPasswordLable = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // logInButtog
            // 
            this.logInButtog.Location = new System.Drawing.Point(89, 220);
            this.logInButtog.Name = "logInButtog";
            this.logInButtog.Size = new System.Drawing.Size(178, 23);
            this.logInButtog.TabIndex = 0;
            this.logInButtog.Text = "Войти";
            this.logInButtog.UseVisualStyleBackColor = true;
            this.logInButtog.Click += new System.EventHandler(this.button1_Click);
            // 
            // userNameForm
            // 
            this.userNameForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userNameForm.Location = new System.Drawing.Point(89, 107);
            this.userNameForm.Name = "userNameForm";
            this.userNameForm.Size = new System.Drawing.Size(178, 29);
            this.userNameForm.TabIndex = 1;
            // 
            // userPasswordForm
            // 
            this.userPasswordForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userPasswordForm.Location = new System.Drawing.Point(89, 166);
            this.userPasswordForm.Name = "userPasswordForm";
            this.userPasswordForm.Size = new System.Drawing.Size(178, 29);
            this.userPasswordForm.TabIndex = 2;
            // 
            // exptLable
            // 
            this.exptLable.AutoSize = true;
            this.exptLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exptLable.ForeColor = System.Drawing.Color.Red;
            this.exptLable.Location = new System.Drawing.Point(12, 9);
            this.exptLable.Name = "exptLable";
            this.exptLable.Size = new System.Drawing.Size(68, 20);
            this.exptLable.TabIndex = 3;
            this.exptLable.Text = "ERROR";
            this.exptLable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // skipButton
            // 
            this.skipButton.Location = new System.Drawing.Point(89, 249);
            this.skipButton.Name = "skipButton";
            this.skipButton.Size = new System.Drawing.Size(178, 23);
            this.skipButton.TabIndex = 4;
            this.skipButton.Text = "Войти как гость";
            this.skipButton.UseVisualStyleBackColor = true;
            this.skipButton.Click += new System.EventHandler(this.skipButton_Click);
            // 
            // registerButton
            // 
            this.registerButton.Location = new System.Drawing.Point(89, 278);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(178, 23);
            this.registerButton.TabIndex = 5;
            this.registerButton.Text = "Регистрация";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // userNameLable
            // 
            this.userNameLable.AutoSize = true;
            this.userNameLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userNameLable.Location = new System.Drawing.Point(85, 80);
            this.userNameLable.Name = "userNameLable";
            this.userNameLable.Size = new System.Drawing.Size(132, 24);
            this.userNameLable.TabIndex = 6;
            this.userNameLable.Text = "Введите имя:";
            // 
            // userPasswordLable
            // 
            this.userPasswordLable.AutoSize = true;
            this.userPasswordLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userPasswordLable.Location = new System.Drawing.Point(85, 139);
            this.userPasswordLable.Name = "userPasswordLable";
            this.userPasswordLable.Size = new System.Drawing.Size(162, 24);
            this.userPasswordLable.TabIndex = 7;
            this.userPasswordLable.Text = "Введите пароль:";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 351);
            this.Controls.Add(this.userPasswordLable);
            this.Controls.Add(this.userNameLable);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.skipButton);
            this.Controls.Add(this.exptLable);
            this.Controls.Add(this.userPasswordForm);
            this.Controls.Add(this.userNameForm);
            this.Controls.Add(this.logInButtog);
            this.Name = "LoginForm";
            this.Text = "Авторизация";
            this.Load += new System.EventHandler(this.RegisterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button logInButtog;
        private System.Windows.Forms.TextBox userNameForm;
        private System.Windows.Forms.TextBox userPasswordForm;
        private System.Windows.Forms.Label exptLable;
        private System.Windows.Forms.Button skipButton;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.Label userNameLable;
        private System.Windows.Forms.Label userPasswordLable;
    }
}