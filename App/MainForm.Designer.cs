namespace App
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.permissionTabControl = new System.Windows.Forms.TabControl();
            this.AllUserTabPage = new System.Windows.Forms.TabPage();
            this.DataPanel = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.spectacleGridView = new System.Windows.Forms.DataGridView();
            this.ControlPanel = new System.Windows.Forms.Panel();
            this.userRolePictureBox = new System.Windows.Forms.PictureBox();
            this.RegistrBut = new System.Windows.Forms.Button();
            this.userInfo = new System.Windows.Forms.Label();
            this.addSpectacle = new System.Windows.Forms.Button();
            this.searchSpectacleByGenre = new System.Windows.Forms.TextBox();
            this.searchSpectacleByDate = new System.Windows.Forms.DateTimePicker();
            this.mainExpString = new System.Windows.Forms.Label();
            this.AdminTabPanel = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.changeTicketsButton = new System.Windows.Forms.Button();
            this.userTicketsListBox = new System.Windows.Forms.RichTextBox();
            this.userTicketsLable = new System.Windows.Forms.Label();
            this.delUserButton = new System.Windows.Forms.Button();
            this.userRoleBox = new System.Windows.Forms.ComboBox();
            this.addUserButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.userPasswordBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.userLoginBox = new System.Windows.Forms.TextBox();
            this.userGridView = new System.Windows.Forms.DataGridView();
            this.userInfoContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.permissionTabControl.SuspendLayout();
            this.AllUserTabPage.SuspendLayout();
            this.DataPanel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spectacleGridView)).BeginInit();
            this.ControlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userRolePictureBox)).BeginInit();
            this.AdminTabPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // permissionTabControl
            // 
            this.permissionTabControl.Controls.Add(this.AllUserTabPage);
            this.permissionTabControl.Controls.Add(this.AdminTabPanel);
            this.permissionTabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.permissionTabControl.Location = new System.Drawing.Point(1, 0);
            this.permissionTabControl.Name = "permissionTabControl";
            this.permissionTabControl.SelectedIndex = 0;
            this.permissionTabControl.Size = new System.Drawing.Size(821, 451);
            this.permissionTabControl.TabIndex = 0;
            // 
            // AllUserTabPage
            // 
            this.AllUserTabPage.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.AllUserTabPage.Controls.Add(this.DataPanel);
            this.AllUserTabPage.Controls.Add(this.ControlPanel);
            this.AllUserTabPage.Location = new System.Drawing.Point(4, 25);
            this.AllUserTabPage.Name = "AllUserTabPage";
            this.AllUserTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.AllUserTabPage.Size = new System.Drawing.Size(813, 422);
            this.AllUserTabPage.TabIndex = 0;
            this.AllUserTabPage.Text = "Выбор Спектаклей";
            // 
            // DataPanel
            // 
            this.DataPanel.Controls.Add(this.groupBox2);
            this.DataPanel.Location = new System.Drawing.Point(8, 67);
            this.DataPanel.Name = "DataPanel";
            this.DataPanel.Size = new System.Drawing.Size(794, 358);
            this.DataPanel.TabIndex = 12;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.spectacleGridView);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(791, 374);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Спектакли";
            // 
            // spectacleGridView
            // 
            this.spectacleGridView.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.spectacleGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.spectacleGridView.Location = new System.Drawing.Point(3, 21);
            this.spectacleGridView.Name = "spectacleGridView";
            this.spectacleGridView.Size = new System.Drawing.Size(785, 325);
            this.spectacleGridView.TabIndex = 3;
            // 
            // ControlPanel
            // 
            this.ControlPanel.Controls.Add(this.label5);
            this.ControlPanel.Controls.Add(this.label4);
            this.ControlPanel.Controls.Add(this.userRolePictureBox);
            this.ControlPanel.Controls.Add(this.RegistrBut);
            this.ControlPanel.Controls.Add(this.userInfo);
            this.ControlPanel.Controls.Add(this.addSpectacle);
            this.ControlPanel.Controls.Add(this.searchSpectacleByGenre);
            this.ControlPanel.Controls.Add(this.searchSpectacleByDate);
            this.ControlPanel.Controls.Add(this.mainExpString);
            this.ControlPanel.Location = new System.Drawing.Point(8, -1);
            this.ControlPanel.Name = "ControlPanel";
            this.ControlPanel.Size = new System.Drawing.Size(797, 62);
            this.ControlPanel.TabIndex = 11;
            // 
            // userRolePictureBox
            // 
            this.userRolePictureBox.InitialImage = global::App.Properties.Resources.user_48;
            this.userRolePictureBox.Location = new System.Drawing.Point(586, 10);
            this.userRolePictureBox.Name = "userRolePictureBox";
            this.userRolePictureBox.Size = new System.Drawing.Size(58, 52);
            this.userRolePictureBox.TabIndex = 9;
            this.userRolePictureBox.TabStop = false;
            // 
            // RegistrBut
            // 
            this.RegistrBut.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RegistrBut.Location = new System.Drawing.Point(650, 3);
            this.RegistrBut.Name = "RegistrBut";
            this.RegistrBut.Size = new System.Drawing.Size(147, 29);
            this.RegistrBut.TabIndex = 2;
            this.RegistrBut.Text = "Регистрация";
            this.RegistrBut.UseVisualStyleBackColor = true;
            this.RegistrBut.Click += new System.EventHandler(this.RegistrBut_Click);
            // 
            // userInfo
            // 
            this.userInfo.AutoSize = true;
            this.userInfo.Location = new System.Drawing.Point(647, 35);
            this.userInfo.Name = "userInfo";
            this.userInfo.Size = new System.Drawing.Size(76, 16);
            this.userInfo.TabIndex = 4;
            this.userInfo.Text = "User Name";
            // 
            // addSpectacle
            // 
            this.addSpectacle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addSpectacle.Location = new System.Drawing.Point(280, 18);
            this.addSpectacle.Name = "addSpectacle";
            this.addSpectacle.Size = new System.Drawing.Size(136, 40);
            this.addSpectacle.TabIndex = 8;
            this.addSpectacle.Text = "Добавить";
            this.addSpectacle.UseVisualStyleBackColor = true;
            this.addSpectacle.Click += new System.EventHandler(this.addSpectacle_Click);
            // 
            // searchSpectacleByGenre
            // 
            this.searchSpectacleByGenre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.searchSpectacleByGenre.Location = new System.Drawing.Point(3, 37);
            this.searchSpectacleByGenre.Name = "searchSpectacleByGenre";
            this.searchSpectacleByGenre.Size = new System.Drawing.Size(126, 22);
            this.searchSpectacleByGenre.TabIndex = 5;
            this.searchSpectacleByGenre.TextChanged += new System.EventHandler(this.searchSpectacleByGenre_TextChanged);
            // 
            // searchSpectacleByDate
            // 
            this.searchSpectacleByDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.searchSpectacleByDate.Location = new System.Drawing.Point(135, 35);
            this.searchSpectacleByDate.Name = "searchSpectacleByDate";
            this.searchSpectacleByDate.Size = new System.Drawing.Size(139, 22);
            this.searchSpectacleByDate.TabIndex = 7;
            this.searchSpectacleByDate.ValueChanged += new System.EventHandler(this.searchSpectacleByDate_ValueChanged);
            // 
            // mainExpString
            // 
            this.mainExpString.AutoSize = true;
            this.mainExpString.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mainExpString.ForeColor = System.Drawing.Color.Brown;
            this.mainExpString.Location = new System.Drawing.Point(3, 2);
            this.mainExpString.Name = "mainExpString";
            this.mainExpString.Size = new System.Drawing.Size(56, 16);
            this.mainExpString.TabIndex = 6;
            this.mainExpString.Text = "ERROR";
            // 
            // AdminTabPanel
            // 
            this.AdminTabPanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.AdminTabPanel.Controls.Add(this.groupBox1);
            this.AdminTabPanel.Location = new System.Drawing.Point(4, 25);
            this.AdminTabPanel.Name = "AdminTabPanel";
            this.AdminTabPanel.Padding = new System.Windows.Forms.Padding(3);
            this.AdminTabPanel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.AdminTabPanel.Size = new System.Drawing.Size(813, 422);
            this.AdminTabPanel.TabIndex = 1;
            this.AdminTabPanel.Text = "Панел администрации";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.changeTicketsButton);
            this.groupBox1.Controls.Add(this.userTicketsListBox);
            this.groupBox1.Controls.Add(this.userTicketsLable);
            this.groupBox1.Controls.Add(this.delUserButton);
            this.groupBox1.Controls.Add(this.userRoleBox);
            this.groupBox1.Controls.Add(this.addUserButton);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.userPasswordBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.userLoginBox);
            this.groupBox1.Controls.Add(this.userGridView);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(7, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(798, 387);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Пользователи";
            // 
            // changeTicketsButton
            // 
            this.changeTicketsButton.Location = new System.Drawing.Point(364, 344);
            this.changeTicketsButton.Name = "changeTicketsButton";
            this.changeTicketsButton.Size = new System.Drawing.Size(231, 23);
            this.changeTicketsButton.TabIndex = 12;
            this.changeTicketsButton.Text = "Изменить ";
            this.changeTicketsButton.UseVisualStyleBackColor = true;
            this.changeTicketsButton.Click += new System.EventHandler(this.changeTicketsButton_Click);
            // 
            // userTicketsListBox
            // 
            this.userTicketsListBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.userTicketsListBox.Location = new System.Drawing.Point(361, 28);
            this.userTicketsListBox.Name = "userTicketsListBox";
            this.userTicketsListBox.Size = new System.Drawing.Size(234, 309);
            this.userTicketsListBox.TabIndex = 11;
            this.userTicketsListBox.Text = "";
            // 
            // userTicketsLable
            // 
            this.userTicketsLable.AutoSize = true;
            this.userTicketsLable.Location = new System.Drawing.Point(361, 9);
            this.userTicketsLable.Name = "userTicketsLable";
            this.userTicketsLable.Size = new System.Drawing.Size(161, 16);
            this.userTicketsLable.TabIndex = 10;
            this.userTicketsLable.Text = "Билеты пользователя...";
            // 
            // delUserButton
            // 
            this.delUserButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.delUserButton.Location = new System.Drawing.Point(631, 233);
            this.delUserButton.Name = "delUserButton";
            this.delUserButton.Size = new System.Drawing.Size(145, 35);
            this.delUserButton.TabIndex = 8;
            this.delUserButton.Text = "Удалить\r\n";
            this.delUserButton.UseVisualStyleBackColor = true;
            this.delUserButton.Visible = false;
            this.delUserButton.Click += new System.EventHandler(this.delUserButton_Click);
            // 
            // userRoleBox
            // 
            this.userRoleBox.FormattingEnabled = true;
            this.userRoleBox.Items.AddRange(new object[] {
            "Пользователь",
            "Администратор"});
            this.userRoleBox.Location = new System.Drawing.Point(631, 144);
            this.userRoleBox.Name = "userRoleBox";
            this.userRoleBox.Size = new System.Drawing.Size(145, 24);
            this.userRoleBox.TabIndex = 3;
            // 
            // addUserButton
            // 
            this.addUserButton.Location = new System.Drawing.Point(631, 190);
            this.addUserButton.Name = "addUserButton";
            this.addUserButton.Size = new System.Drawing.Size(145, 37);
            this.addUserButton.TabIndex = 7;
            this.addUserButton.Text = "Добавить";
            this.addUserButton.UseVisualStyleBackColor = true;
            this.addUserButton.Click += new System.EventHandler(this.AddUserButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(631, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Роль";
            // 
            // userPasswordBox
            // 
            this.userPasswordBox.Location = new System.Drawing.Point(631, 87);
            this.userPasswordBox.Name = "userPasswordBox";
            this.userPasswordBox.Size = new System.Drawing.Size(145, 22);
            this.userPasswordBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(631, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Пароль";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(631, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Логин";
            // 
            // userLoginBox
            // 
            this.userLoginBox.Location = new System.Drawing.Point(631, 28);
            this.userLoginBox.Name = "userLoginBox";
            this.userLoginBox.Size = new System.Drawing.Size(145, 22);
            this.userLoginBox.TabIndex = 1;
            this.userLoginBox.TextChanged += new System.EventHandler(this.userLoginBox_TextChanged);
            // 
            // userGridView
            // 
            this.userGridView.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.userGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userGridView.Location = new System.Drawing.Point(6, 28);
            this.userGridView.Name = "userGridView";
            this.userGridView.Size = new System.Drawing.Size(349, 340);
            this.userGridView.TabIndex = 0;
            this.userGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.userGridView_CellClick);
            // 
            // userInfoContextMenu
            // 
            this.userInfoContextMenu.Name = "userInfoContextMenu";
            this.userInfoContextMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Поиск по жанру:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(132, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Поиск по дате:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 450);
            this.Controls.Add(this.permissionTabControl);
            this.Name = "MainForm";
            this.Text = "Cистема распространения билетов в театре";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.permissionTabControl.ResumeLayout(false);
            this.AllUserTabPage.ResumeLayout(false);
            this.DataPanel.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spectacleGridView)).EndInit();
            this.ControlPanel.ResumeLayout(false);
            this.ControlPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userRolePictureBox)).EndInit();
            this.AdminTabPanel.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl permissionTabControl;
        private System.Windows.Forms.TabPage AllUserTabPage;
        private System.Windows.Forms.Panel DataPanel;
        private System.Windows.Forms.DataGridView spectacleGridView;
        private System.Windows.Forms.Panel ControlPanel;
        private System.Windows.Forms.Button RegistrBut;
        private System.Windows.Forms.Label userInfo;
        private System.Windows.Forms.Button addSpectacle;
        private System.Windows.Forms.TextBox searchSpectacleByGenre;
        private System.Windows.Forms.DateTimePicker searchSpectacleByDate;
        private System.Windows.Forms.Label mainExpString;
        private System.Windows.Forms.TabPage AdminTabPanel;
        private System.Windows.Forms.DataGridView userGridView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox userLoginBox;
        private System.Windows.Forms.Button addUserButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox userPasswordBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox userRoleBox;
        private System.Windows.Forms.Button delUserButton;
        private System.Windows.Forms.Label userTicketsLable;
        private System.Windows.Forms.RichTextBox userTicketsListBox;
        private System.Windows.Forms.PictureBox userRolePictureBox;
        private System.Windows.Forms.ContextMenuStrip userInfoContextMenu;
        private System.Windows.Forms.Button changeTicketsButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}

