namespace App
{
    partial class UserTicketsForm
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
            this.userTicketGroupBox = new System.Windows.Forms.GroupBox();
            this.userTicketsGridView = new System.Windows.Forms.DataGridView();
            this.delUserTicketButton = new System.Windows.Forms.Button();
            this.userTicketGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userTicketsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // userTicketGroupBox
            // 
            this.userTicketGroupBox.Controls.Add(this.userTicketsGridView);
            this.userTicketGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userTicketGroupBox.Location = new System.Drawing.Point(12, 12);
            this.userTicketGroupBox.Name = "userTicketGroupBox";
            this.userTicketGroupBox.Size = new System.Drawing.Size(487, 311);
            this.userTicketGroupBox.TabIndex = 0;
            this.userTicketGroupBox.TabStop = false;
            this.userTicketGroupBox.Text = "Билеты пользователя ..";
            // 
            // userTicketsGridView
            // 
            this.userTicketsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userTicketsGridView.Location = new System.Drawing.Point(6, 21);
            this.userTicketsGridView.Name = "userTicketsGridView";
            this.userTicketsGridView.Size = new System.Drawing.Size(474, 278);
            this.userTicketsGridView.TabIndex = 0;
            this.userTicketsGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.userTicketsGridView_CellClick);
            // 
            // delUserTicketButton
            // 
            this.delUserTicketButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.delUserTicketButton.Location = new System.Drawing.Point(18, 323);
            this.delUserTicketButton.Name = "delUserTicketButton";
            this.delUserTicketButton.Size = new System.Drawing.Size(126, 36);
            this.delUserTicketButton.TabIndex = 1;
            this.delUserTicketButton.Text = "Возврат билета";
            this.delUserTicketButton.UseVisualStyleBackColor = true;
            this.delUserTicketButton.Click += new System.EventHandler(this.delUserTicketButton_Click);
            // 
            // UserTicketsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 371);
            this.Controls.Add(this.delUserTicketButton);
            this.Controls.Add(this.userTicketGroupBox);
            this.Name = "UserTicketsForm";
            this.Text = "UserTicketsForm";
            this.Load += new System.EventHandler(this.UserTicketsForm_Load);
            this.userTicketGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userTicketsGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox userTicketGroupBox;
        private System.Windows.Forms.DataGridView userTicketsGridView;
        private System.Windows.Forms.Button delUserTicketButton;
    }
}