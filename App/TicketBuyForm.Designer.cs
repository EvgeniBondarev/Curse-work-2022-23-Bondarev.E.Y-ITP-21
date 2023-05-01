namespace App
{
    partial class TicketBuyForm
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
            this.SpectacleTitle = new System.Windows.Forms.Label();
            this.SpectacleAuthor = new System.Windows.Forms.Label();
            this.SpectacleGenre = new System.Windows.Forms.Label();
            this.SpectacleDate = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CategoriesRadio3 = new System.Windows.Forms.RadioButton();
            this.CategoriesRadio2 = new System.Windows.Forms.RadioButton();
            this.CategoriesRadio1 = new System.Windows.Forms.RadioButton();
            this.BuyTicket = new System.Windows.Forms.Button();
            this.RegisterBuyPanel = new System.Windows.Forms.Panel();
            this.AdminBuyPanel = new System.Windows.Forms.Panel();
            this.delSpectacle = new System.Windows.Forms.Button();
            this.newDateName = new System.Windows.Forms.DateTimePicker();
            this.changeTiket = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.GanreBox = new System.Windows.Forms.ComboBox();
            this.newStandartPrice = new System.Windows.Forms.NumericUpDown();
            this.newMediumPrice = new System.Windows.Forms.NumericUpDown();
            this.newVIPPrice = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.newSpectacleName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.newAuthorName = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.RegisterBuyPanel.SuspendLayout();
            this.AdminBuyPanel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.newStandartPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newMediumPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newVIPPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // SpectacleTitle
            // 
            this.SpectacleTitle.AutoSize = true;
            this.SpectacleTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SpectacleTitle.Location = new System.Drawing.Point(122, 4);
            this.SpectacleTitle.Name = "SpectacleTitle";
            this.SpectacleTitle.Size = new System.Drawing.Size(60, 24);
            this.SpectacleTitle.TabIndex = 0;
            this.SpectacleTitle.Text = "label1";
            this.SpectacleTitle.Click += new System.EventHandler(this.SpectacleTitle_Click);
            // 
            // SpectacleAuthor
            // 
            this.SpectacleAuthor.AutoSize = true;
            this.SpectacleAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SpectacleAuthor.Location = new System.Drawing.Point(14, 33);
            this.SpectacleAuthor.Name = "SpectacleAuthor";
            this.SpectacleAuthor.Size = new System.Drawing.Size(76, 24);
            this.SpectacleAuthor.TabIndex = 1;
            this.SpectacleAuthor.Text = "Автор: ";
            // 
            // SpectacleGenre
            // 
            this.SpectacleGenre.AutoSize = true;
            this.SpectacleGenre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SpectacleGenre.Location = new System.Drawing.Point(8, 70);
            this.SpectacleGenre.Name = "SpectacleGenre";
            this.SpectacleGenre.Size = new System.Drawing.Size(68, 24);
            this.SpectacleGenre.TabIndex = 2;
            this.SpectacleGenre.Text = "Жанр: ";
            // 
            // SpectacleDate
            // 
            this.SpectacleDate.AutoSize = true;
            this.SpectacleDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SpectacleDate.Location = new System.Drawing.Point(8, 110);
            this.SpectacleDate.Name = "SpectacleDate";
            this.SpectacleDate.Size = new System.Drawing.Size(64, 24);
            this.SpectacleDate.TabIndex = 3;
            this.SpectacleDate.Text = "Дата: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CategoriesRadio3);
            this.groupBox1.Controls.Add(this.CategoriesRadio2);
            this.groupBox1.Controls.Add(this.CategoriesRadio1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(12, 149);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(241, 125);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Категория";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // CategoriesRadio3
            // 
            this.CategoriesRadio3.AutoSize = true;
            this.CategoriesRadio3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CategoriesRadio3.Location = new System.Drawing.Point(6, 95);
            this.CategoriesRadio3.Name = "CategoriesRadio3";
            this.CategoriesRadio3.Size = new System.Drawing.Size(104, 24);
            this.CategoriesRadio3.TabIndex = 7;
            this.CategoriesRadio3.TabStop = true;
            this.CategoriesRadio3.Text = "Галерея - ";
            this.CategoriesRadio3.UseVisualStyleBackColor = true;
            // 
            // CategoriesRadio2
            // 
            this.CategoriesRadio2.AutoSize = true;
            this.CategoriesRadio2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CategoriesRadio2.Location = new System.Drawing.Point(6, 58);
            this.CategoriesRadio2.Name = "CategoriesRadio2";
            this.CategoriesRadio2.Size = new System.Drawing.Size(81, 24);
            this.CategoriesRadio2.TabIndex = 6;
            this.CategoriesRadio2.TabStop = true;
            this.CategoriesRadio2.Text = "Ложа - ";
            this.CategoriesRadio2.UseVisualStyleBackColor = true;
            // 
            // CategoriesRadio1
            // 
            this.CategoriesRadio1.AutoSize = true;
            this.CategoriesRadio1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CategoriesRadio1.Location = new System.Drawing.Point(6, 28);
            this.CategoriesRadio1.Name = "CategoriesRadio1";
            this.CategoriesRadio1.Size = new System.Drawing.Size(62, 24);
            this.CategoriesRadio1.TabIndex = 5;
            this.CategoriesRadio1.TabStop = true;
            this.CategoriesRadio1.Text = "VIP -";
            this.CategoriesRadio1.UseVisualStyleBackColor = true;
            // 
            // BuyTicket
            // 
            this.BuyTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BuyTicket.Location = new System.Drawing.Point(117, 297);
            this.BuyTicket.Name = "BuyTicket";
            this.BuyTicket.Size = new System.Drawing.Size(89, 34);
            this.BuyTicket.TabIndex = 5;
            this.BuyTicket.Text = "Купить";
            this.BuyTicket.UseVisualStyleBackColor = true;
            this.BuyTicket.Click += new System.EventHandler(this.BuyTicket_Click);
            // 
            // RegisterBuyPanel
            // 
            this.RegisterBuyPanel.Controls.Add(this.SpectacleTitle);
            this.RegisterBuyPanel.Controls.Add(this.BuyTicket);
            this.RegisterBuyPanel.Controls.Add(this.SpectacleAuthor);
            this.RegisterBuyPanel.Controls.Add(this.groupBox1);
            this.RegisterBuyPanel.Controls.Add(this.SpectacleGenre);
            this.RegisterBuyPanel.Controls.Add(this.SpectacleDate);
            this.RegisterBuyPanel.Location = new System.Drawing.Point(12, 5);
            this.RegisterBuyPanel.Name = "RegisterBuyPanel";
            this.RegisterBuyPanel.Size = new System.Drawing.Size(311, 334);
            this.RegisterBuyPanel.TabIndex = 6;
            this.RegisterBuyPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.RegisterBuyPanel_Paint);
            // 
            // AdminBuyPanel
            // 
            this.AdminBuyPanel.Controls.Add(this.GanreBox);
            this.AdminBuyPanel.Controls.Add(this.delSpectacle);
            this.AdminBuyPanel.Controls.Add(this.newDateName);
            this.AdminBuyPanel.Controls.Add(this.changeTiket);
            this.AdminBuyPanel.Controls.Add(this.groupBox2);
            this.AdminBuyPanel.Controls.Add(this.label4);
            this.AdminBuyPanel.Controls.Add(this.label3);
            this.AdminBuyPanel.Controls.Add(this.newSpectacleName);
            this.AdminBuyPanel.Controls.Add(this.label2);
            this.AdminBuyPanel.Controls.Add(this.label1);
            this.AdminBuyPanel.Controls.Add(this.newAuthorName);
            this.AdminBuyPanel.Location = new System.Drawing.Point(329, 5);
            this.AdminBuyPanel.Name = "AdminBuyPanel";
            this.AdminBuyPanel.Size = new System.Drawing.Size(311, 334);
            this.AdminBuyPanel.TabIndex = 6;
            this.AdminBuyPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.AdminBuyPanel_Paint);
            // 
            // delSpectacle
            // 
            this.delSpectacle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.delSpectacle.Location = new System.Drawing.Point(167, 297);
            this.delSpectacle.Name = "delSpectacle";
            this.delSpectacle.Size = new System.Drawing.Size(134, 34);
            this.delSpectacle.TabIndex = 12;
            this.delSpectacle.Text = "Удалить";
            this.delSpectacle.UseVisualStyleBackColor = true;
            this.delSpectacle.Click += new System.EventHandler(this.delSpectacle_Click);
            // 
            // newDateName
            // 
            this.newDateName.Location = new System.Drawing.Point(85, 125);
            this.newDateName.Name = "newDateName";
            this.newDateName.Size = new System.Drawing.Size(192, 20);
            this.newDateName.TabIndex = 11;
            this.newDateName.ValueChanged += new System.EventHandler(this.newDateName_ValueChanged);
            // 
            // changeTiket
            // 
            this.changeTiket.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.changeTiket.Location = new System.Drawing.Point(7, 297);
            this.changeTiket.Name = "changeTiket";
            this.changeTiket.Size = new System.Drawing.Size(134, 34);
            this.changeTiket.TabIndex = 10;
            this.changeTiket.Text = "Изменить";
            this.changeTiket.UseVisualStyleBackColor = true;
            this.changeTiket.Click += new System.EventHandler(this.changeTiket_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.newStandartPrice);
            this.groupBox2.Controls.Add(this.newMediumPrice);
            this.groupBox2.Controls.Add(this.newVIPPrice);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(7, 152);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(245, 139);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Категория";
            // 
            // GanreBox
            // 
            this.GanreBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GanreBox.FormattingEnabled = true;
            this.GanreBox.Location = new System.Drawing.Point(85, 83);
            this.GanreBox.Name = "GanreBox";
            this.GanreBox.Size = new System.Drawing.Size(192, 32);
            this.GanreBox.TabIndex = 13;
            this.GanreBox.SelectedIndexChanged += new System.EventHandler(this.GanreBox_SelectedIndexChanged);
            // 
            // newStandartPrice
            // 
            this.newStandartPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.newStandartPrice.Location = new System.Drawing.Point(78, 96);
            this.newStandartPrice.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.newStandartPrice.Name = "newStandartPrice";
            this.newStandartPrice.Size = new System.Drawing.Size(87, 26);
            this.newStandartPrice.TabIndex = 9;
            // 
            // newMediumPrice
            // 
            this.newMediumPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.newMediumPrice.Location = new System.Drawing.Point(62, 60);
            this.newMediumPrice.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.newMediumPrice.Name = "newMediumPrice";
            this.newMediumPrice.Size = new System.Drawing.Size(87, 26);
            this.newMediumPrice.TabIndex = 8;
            // 
            // newVIPPrice
            // 
            this.newVIPPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.newVIPPrice.Location = new System.Drawing.Point(47, 27);
            this.newVIPPrice.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.newVIPPrice.Name = "newVIPPrice";
            this.newVIPPrice.Size = new System.Drawing.Size(87, 26);
            this.newVIPPrice.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(6, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Галерея";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(6, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Ложа";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(6, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "VIP";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(7, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = "Дата: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Жанр: ";
            // 
            // newSpectacleName
            // 
            this.newSpectacleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.newSpectacleName.Location = new System.Drawing.Point(106, 12);
            this.newSpectacleName.Name = "newSpectacleName";
            this.newSpectacleName.Size = new System.Drawing.Size(171, 29);
            this.newSpectacleName.TabIndex = 4;
            this.newSpectacleName.TextChanged += new System.EventHandler(this.newSpectacleName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Название:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Автор: ";
            // 
            // newAuthorName
            // 
            this.newAuthorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.newAuthorName.Location = new System.Drawing.Point(85, 48);
            this.newAuthorName.Name = "newAuthorName";
            this.newAuthorName.Size = new System.Drawing.Size(192, 29);
            this.newAuthorName.TabIndex = 0;
            // 
            // TicketBuyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 351);
            this.Controls.Add(this.AdminBuyPanel);
            this.Controls.Add(this.RegisterBuyPanel);
            this.Name = "TicketBuyForm";
            this.Text = "Покупка билета";
            this.Load += new System.EventHandler(this.TicketBuyForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.RegisterBuyPanel.ResumeLayout(false);
            this.RegisterBuyPanel.PerformLayout();
            this.AdminBuyPanel.ResumeLayout(false);
            this.AdminBuyPanel.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.newStandartPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newMediumPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newVIPPrice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label SpectacleTitle;
        private System.Windows.Forms.Label SpectacleAuthor;
        private System.Windows.Forms.Label SpectacleGenre;
        private System.Windows.Forms.Label SpectacleDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton CategoriesRadio1;
        private System.Windows.Forms.RadioButton CategoriesRadio2;
        private System.Windows.Forms.RadioButton CategoriesRadio3;
        private System.Windows.Forms.Button BuyTicket;
        private System.Windows.Forms.Panel RegisterBuyPanel;
        private System.Windows.Forms.Panel AdminBuyPanel;
        private System.Windows.Forms.TextBox newAuthorName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox newSpectacleName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button changeTiket;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown newStandartPrice;
        private System.Windows.Forms.NumericUpDown newMediumPrice;
        private System.Windows.Forms.NumericUpDown newVIPPrice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker newDateName;
        private System.Windows.Forms.Button delSpectacle;
        private System.Windows.Forms.ComboBox GanreBox;
    }
}