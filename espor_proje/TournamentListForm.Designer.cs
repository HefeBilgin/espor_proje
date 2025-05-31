namespace espor_proje
{
    partial class TournamentListForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TournamentListForm));
            this.dgvTurnuvalar = new System.Windows.Forms.DataGridView();
            this.cmbOyun = new System.Windows.Forms.ComboBox();
            this.dtTarih = new System.Windows.Forms.DateTimePicker();
            this.txtOdulMin = new System.Windows.Forms.TextBox();
            this.btnFiltrele = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbTurnuvaTuru = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnuvalar)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTurnuvalar
            // 
            this.dgvTurnuvalar.AllowUserToAddRows = false;
            this.dgvTurnuvalar.AllowUserToDeleteRows = false;
            this.dgvTurnuvalar.BackgroundColor = System.Drawing.Color.White;
            this.dgvTurnuvalar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTurnuvalar.Location = new System.Drawing.Point(37, 54);
            this.dgvTurnuvalar.Name = "dgvTurnuvalar";
            this.dgvTurnuvalar.ReadOnly = true;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.dgvTurnuvalar.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTurnuvalar.Size = new System.Drawing.Size(757, 304);
            this.dgvTurnuvalar.TabIndex = 0;
            this.dgvTurnuvalar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTurnuvalar_CellContentClick);
            this.dgvTurnuvalar.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTurnuvalar_CellDoubleClick);
            // 
            // cmbOyun
            // 
            this.cmbOyun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOyun.ForeColor = System.Drawing.Color.Black;
            this.cmbOyun.FormattingEnabled = true;
            this.cmbOyun.Items.AddRange(new object[] {
            "Valorant",
            "League of Legends",
            "CS:GO"});
            this.cmbOyun.Location = new System.Drawing.Point(37, 474);
            this.cmbOyun.Name = "cmbOyun";
            this.cmbOyun.Size = new System.Drawing.Size(200, 28);
            this.cmbOyun.TabIndex = 1;
            // 
            // dtTarih
            // 
            this.dtTarih.CalendarForeColor = System.Drawing.Color.Black;
            this.dtTarih.Location = new System.Drawing.Point(37, 422);
            this.dtTarih.Name = "dtTarih";
            this.dtTarih.Size = new System.Drawing.Size(200, 26);
            this.dtTarih.TabIndex = 2;
            // 
            // txtOdulMin
            // 
            this.txtOdulMin.Location = new System.Drawing.Point(270, 476);
            this.txtOdulMin.Name = "txtOdulMin";
            this.txtOdulMin.Size = new System.Drawing.Size(200, 26);
            this.txtOdulMin.TabIndex = 3;
            // 
            // btnFiltrele
            // 
            this.btnFiltrele.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnFiltrele.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFiltrele.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnFiltrele.ForeColor = System.Drawing.Color.White;
            this.btnFiltrele.Location = new System.Drawing.Point(509, 422);
            this.btnFiltrele.Name = "btnFiltrele";
            this.btnFiltrele.Size = new System.Drawing.Size(97, 42);
            this.btnFiltrele.TabIndex = 4;
            this.btnFiltrele.Text = "Filtrele";
            this.btnFiltrele.UseVisualStyleBackColor = false;
            this.btnFiltrele.Click += new System.EventHandler(this.btnFiltrele_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(301, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 32);
            this.label1.TabIndex = 5;
            this.label1.Text = "TURNUVALAR";
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.DarkSlateGray;
            this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
            this.button5.Location = new System.Drawing.Point(791, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(35, 35);
            this.button5.TabIndex = 35;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.DarkSlateGray;
            this.button6.Image = ((System.Drawing.Image)(resources.GetObject("button6.Image")));
            this.button6.Location = new System.Drawing.Point(4, 3);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(35, 35);
            this.button6.TabIndex = 36;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(266, 453);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 20);
            this.label2.TabIndex = 37;
            this.label2.Text = "Minimum Ödül Miktarı";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(33, 451);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 20);
            this.label3.TabIndex = 38;
            this.label3.Text = "Turnuva Oyunu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(33, 399);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 20);
            this.label4.TabIndex = 39;
            this.label4.Text = "Turnuva Tarihi";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(266, 399);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 20);
            this.label5.TabIndex = 42;
            this.label5.Text = "Turnuva Türü";
            // 
            // cmbTurnuvaTuru
            // 
            this.cmbTurnuvaTuru.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTurnuvaTuru.ForeColor = System.Drawing.Color.Black;
            this.cmbTurnuvaTuru.FormattingEnabled = true;
            this.cmbTurnuvaTuru.Location = new System.Drawing.Point(270, 422);
            this.cmbTurnuvaTuru.Name = "cmbTurnuvaTuru";
            this.cmbTurnuvaTuru.Size = new System.Drawing.Size(200, 28);
            this.cmbTurnuvaTuru.TabIndex = 43;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.DarkSlateGray;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(623, 422);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(97, 42);
            this.button3.TabIndex = 44;
            this.button3.Text = "Reset";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Teal;
            this.label6.Location = new System.Drawing.Point(96, 361);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(636, 20);
            this.label6.TabIndex = 45;
            this.label6.Text = "Katılmak İstediğiniz Turnuvanın Detaylarını Görmek İçin Turnuvanın Üzerine Çift T" +
    "ıklayınız.";
            // 
            // TournamentListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(829, 551);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.cmbTurnuvaTuru);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFiltrele);
            this.Controls.Add(this.txtOdulMin);
            this.Controls.Add(this.dtTarih);
            this.Controls.Add(this.cmbOyun);
            this.Controls.Add(this.dgvTurnuvalar);
            this.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TournamentListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TournamentListForm";
            this.Load += new System.EventHandler(this.TournamentListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnuvalar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbOyun;
        private System.Windows.Forms.DateTimePicker dtTarih;
        private System.Windows.Forms.TextBox txtOdulMin;
        private System.Windows.Forms.Button btnFiltrele;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbTurnuvaTuru;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.DataGridView dgvTurnuvalar;
    }
}