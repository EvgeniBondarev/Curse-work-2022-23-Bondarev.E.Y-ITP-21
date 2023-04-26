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
            this.RegistrBut = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.userInfo = new System.Windows.Forms.Label();
            this.searchSpectacleByGenre = new System.Windows.Forms.TextBox();
            this.mainExpString = new System.Windows.Forms.Label();
            this.searchSpectacleByDate = new System.Windows.Forms.DateTimePicker();
            this.addSpectacle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // RegistrBut
            // 
            this.RegistrBut.Location = new System.Drawing.Point(725, 12);
            this.RegistrBut.Name = "RegistrBut";
            this.RegistrBut.Size = new System.Drawing.Size(85, 23);
            this.RegistrBut.TabIndex = 2;
            this.RegistrBut.Text = "Регистрация";
            this.RegistrBut.UseVisualStyleBackColor = true;
            this.RegistrBut.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 57);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(797, 288);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // userInfo
            // 
            this.userInfo.AutoSize = true;
            this.userInfo.Location = new System.Drawing.Point(638, 22);
            this.userInfo.Name = "userInfo";
            this.userInfo.Size = new System.Drawing.Size(60, 13);
            this.userInfo.TabIndex = 4;
            this.userInfo.Text = "User Name";
            this.userInfo.Click += new System.EventHandler(this.testCheck_Click);
            // 
            // searchSpectacleByGenre
            // 
            this.searchSpectacleByGenre.Location = new System.Drawing.Point(13, 31);
            this.searchSpectacleByGenre.Name = "searchSpectacleByGenre";
            this.searchSpectacleByGenre.Size = new System.Drawing.Size(100, 20);
            this.searchSpectacleByGenre.TabIndex = 5;
            this.searchSpectacleByGenre.TextChanged += new System.EventHandler(this.searchSpectacleByGenre_TextChanged);
            // 
            // mainExpString
            // 
            this.mainExpString.AutoSize = true;
            this.mainExpString.ForeColor = System.Drawing.Color.Brown;
            this.mainExpString.Location = new System.Drawing.Point(12, 12);
            this.mainExpString.Name = "mainExpString";
            this.mainExpString.Size = new System.Drawing.Size(46, 13);
            this.mainExpString.TabIndex = 6;
            this.mainExpString.Text = "ERROR";
            // 
            // searchSpectacleByDate
            // 
            this.searchSpectacleByDate.Location = new System.Drawing.Point(120, 31);
            this.searchSpectacleByDate.Name = "searchSpectacleByDate";
            this.searchSpectacleByDate.Size = new System.Drawing.Size(200, 20);
            this.searchSpectacleByDate.TabIndex = 7;
            this.searchSpectacleByDate.ValueChanged += new System.EventHandler(this.searchSpectacleByDate_ValueChanged);
            // 
            // addSpectacle
            // 
            this.addSpectacle.Location = new System.Drawing.Point(326, 29);
            this.addSpectacle.Name = "addSpectacle";
            this.addSpectacle.Size = new System.Drawing.Size(75, 23);
            this.addSpectacle.TabIndex = 8;
            this.addSpectacle.Text = "Добавить";
            this.addSpectacle.UseVisualStyleBackColor = true;
            this.addSpectacle.Click += new System.EventHandler(this.addSpectacle_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 450);
            this.Controls.Add(this.addSpectacle);
            this.Controls.Add(this.searchSpectacleByDate);
            this.Controls.Add(this.mainExpString);
            this.Controls.Add(this.searchSpectacleByGenre);
            this.Controls.Add(this.userInfo);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.RegistrBut);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button RegistrBut;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label userInfo;
        private System.Windows.Forms.TextBox searchSpectacleByGenre;
        private System.Windows.Forms.Label mainExpString;
        private System.Windows.Forms.DateTimePicker searchSpectacleByDate;
        private System.Windows.Forms.Button addSpectacle;
    }
}

