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
            this.ControlPanel = new System.Windows.Forms.Panel();
            this.DataPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.ControlPanel.SuspendLayout();
            this.DataPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // RegistrBut
            // 
            this.RegistrBut.Location = new System.Drawing.Point(709, 3);
            this.RegistrBut.Name = "RegistrBut";
            this.RegistrBut.Size = new System.Drawing.Size(85, 37);
            this.RegistrBut.TabIndex = 2;
            this.RegistrBut.Text = "Регистрация";
            this.RegistrBut.UseVisualStyleBackColor = true;
            this.RegistrBut.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(788, 371);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // userInfo
            // 
            this.userInfo.AutoSize = true;
            this.userInfo.Location = new System.Drawing.Point(561, 15);
            this.userInfo.Name = "userInfo";
            this.userInfo.Size = new System.Drawing.Size(60, 13);
            this.userInfo.TabIndex = 4;
            this.userInfo.Text = "User Name";
            this.userInfo.Click += new System.EventHandler(this.testCheck_Click);
            // 
            // searchSpectacleByGenre
            // 
            this.searchSpectacleByGenre.Location = new System.Drawing.Point(6, 19);
            this.searchSpectacleByGenre.Name = "searchSpectacleByGenre";
            this.searchSpectacleByGenre.Size = new System.Drawing.Size(126, 20);
            this.searchSpectacleByGenre.TabIndex = 5;
            this.searchSpectacleByGenre.TextChanged += new System.EventHandler(this.searchSpectacleByGenre_TextChanged);
            // 
            // mainExpString
            // 
            this.mainExpString.AutoSize = true;
            this.mainExpString.ForeColor = System.Drawing.Color.Brown;
            this.mainExpString.Location = new System.Drawing.Point(3, 3);
            this.mainExpString.Name = "mainExpString";
            this.mainExpString.Size = new System.Drawing.Size(46, 13);
            this.mainExpString.TabIndex = 6;
            this.mainExpString.Text = "ERROR";
            // 
            // searchSpectacleByDate
            // 
            this.searchSpectacleByDate.Location = new System.Drawing.Point(138, 19);
            this.searchSpectacleByDate.Name = "searchSpectacleByDate";
            this.searchSpectacleByDate.Size = new System.Drawing.Size(139, 20);
            this.searchSpectacleByDate.TabIndex = 7;
            this.searchSpectacleByDate.ValueChanged += new System.EventHandler(this.searchSpectacleByDate_ValueChanged);
            // 
            // addSpectacle
            // 
            this.addSpectacle.Location = new System.Drawing.Point(283, 16);
            this.addSpectacle.Name = "addSpectacle";
            this.addSpectacle.Size = new System.Drawing.Size(75, 23);
            this.addSpectacle.TabIndex = 8;
            this.addSpectacle.Text = "Добавить";
            this.addSpectacle.UseVisualStyleBackColor = true;
            this.addSpectacle.Click += new System.EventHandler(this.addSpectacle_Click);
            // 
            // ControlPanel
            // 
            this.ControlPanel.Controls.Add(this.RegistrBut);
            this.ControlPanel.Controls.Add(this.userInfo);
            this.ControlPanel.Controls.Add(this.addSpectacle);
            this.ControlPanel.Controls.Add(this.searchSpectacleByGenre);
            this.ControlPanel.Controls.Add(this.searchSpectacleByDate);
            this.ControlPanel.Controls.Add(this.mainExpString);
            this.ControlPanel.Location = new System.Drawing.Point(13, 12);
            this.ControlPanel.Name = "ControlPanel";
            this.ControlPanel.Size = new System.Drawing.Size(797, 43);
            this.ControlPanel.TabIndex = 9;
            this.ControlPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.ControlPanel_Paint);
            // 
            // DataPanel
            // 
            this.DataPanel.Controls.Add(this.dataGridView1);
            this.DataPanel.Location = new System.Drawing.Point(13, 61);
            this.DataPanel.Name = "DataPanel";
            this.DataPanel.Size = new System.Drawing.Size(794, 377);
            this.DataPanel.TabIndex = 10;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 450);
            this.Controls.Add(this.DataPanel);
            this.Controls.Add(this.ControlPanel);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ControlPanel.ResumeLayout(false);
            this.ControlPanel.PerformLayout();
            this.DataPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button RegistrBut;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label userInfo;
        private System.Windows.Forms.TextBox searchSpectacleByGenre;
        private System.Windows.Forms.Label mainExpString;
        private System.Windows.Forms.DateTimePicker searchSpectacleByDate;
        private System.Windows.Forms.Button addSpectacle;
        private System.Windows.Forms.Panel ControlPanel;
        private System.Windows.Forms.Panel DataPanel;
    }
}

