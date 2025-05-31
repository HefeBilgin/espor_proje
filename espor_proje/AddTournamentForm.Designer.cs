namespace espor_proje
{
    partial class AddTournamentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddTournamentForm));
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTname = new System.Windows.Forms.TextBox();
            this.cmbGame = new System.Windows.Forms.ComboBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.txtPrizePool = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.btnEkle = new System.Windows.Forms.Button();
            this.dgvTurnuvalar = new System.Windows.Forms.DataGridView();
            this.cmbTurnuvaTuru = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtOdulMin = new System.Windows.Forms.TextBox();
            this.dtTarih = new System.Windows.Forms.DateTimePicker();
            this.cmbOyun = new System.Windows.Forms.ComboBox();
            this.btnFiltrele = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.cmbParticipantLimit = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnuvalar)).BeginInit();
            this.SuspendLayout();
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.DarkSlateGray;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
            this.button5.Location = new System.Drawing.Point(951, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(35, 35);
            this.button5.TabIndex = 35;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.DarkSlateGray;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button6.Image = ((System.Drawing.Image)(resources.GetObject("button6.Image")));
            this.button6.Location = new System.Drawing.Point(3, 3);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(35, 35);
            this.button6.TabIndex = 36;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(378, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 36);
            this.label1.TabIndex = 37;
            this.label1.Text = "-TURNUVALAR-";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(989, 68);
            this.panel1.TabIndex = 38;
            // 
            // txtTname
            // 
            this.txtTname.Location = new System.Drawing.Point(124, 100);
            this.txtTname.Multiline = true;
            this.txtTname.Name = "txtTname";
            this.txtTname.Size = new System.Drawing.Size(200, 28);
            this.txtTname.TabIndex = 39;
            // 
            // cmbGame
            // 
            this.cmbGame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGame.FormattingEnabled = true;
            this.cmbGame.Items.AddRange(new object[] {
            "Valorant",
            "CS:GO",
            "League of Legends"});
            this.cmbGame.Location = new System.Drawing.Point(124, 148);
            this.cmbGame.Name = "cmbGame";
            this.cmbGame.Size = new System.Drawing.Size(200, 28);
            this.cmbGame.TabIndex = 40;
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "bireysel",
            "takım"});
            this.cmbType.Location = new System.Drawing.Point(124, 194);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(200, 28);
            this.cmbType.TabIndex = 41;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(124, 356);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(200, 26);
            this.dtpStartDate.TabIndex = 42;
            // 
            // txtPrizePool
            // 
            this.txtPrizePool.Location = new System.Drawing.Point(124, 248);
            this.txtPrizePool.Multiline = true;
            this.txtPrizePool.Name = "txtPrizePool";
            this.txtPrizePool.Size = new System.Drawing.Size(200, 28);
            this.txtPrizePool.TabIndex = 43;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(124, 299);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(200, 28);
            this.txtDescription.TabIndex = 44;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 45;
            this.label2.Text = "Turnuva İsmi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 20);
            this.label3.TabIndex = 46;
            this.label3.Text = "Oyun Türü";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 20);
            this.label4.TabIndex = 47;
            this.label4.Text = "Turnuva Türü";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 248);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 20);
            this.label5.TabIndex = 48;
            this.label5.Text = "Ödül Havuzu";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(47, 299);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 20);
            this.label6.TabIndex = 49;
            this.label6.Text = "Açıklama";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 356);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 20);
            this.label7.TabIndex = 50;
            this.label7.Text = "Başlangıç Tarihi";
            // 
            // btnTemizle
            // 
            this.btnTemizle.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnTemizle.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTemizle.ForeColor = System.Drawing.Color.White;
            this.btnTemizle.Location = new System.Drawing.Point(223, 444);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(93, 43);
            this.btnTemizle.TabIndex = 51;
            this.btnTemizle.Text = "TEMİZLE";
            this.btnTemizle.UseVisualStyleBackColor = false;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // btnEkle
            // 
            this.btnEkle.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnEkle.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnEkle.ForeColor = System.Drawing.Color.White;
            this.btnEkle.Location = new System.Drawing.Point(124, 444);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(93, 43);
            this.btnEkle.TabIndex = 52;
            this.btnEkle.Text = "EKLE";
            this.btnEkle.UseVisualStyleBackColor = false;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // dgvTurnuvalar
            // 
            this.dgvTurnuvalar.AllowUserToAddRows = false;
            this.dgvTurnuvalar.AllowUserToDeleteRows = false;
            this.dgvTurnuvalar.BackgroundColor = System.Drawing.Color.White;
            this.dgvTurnuvalar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTurnuvalar.Location = new System.Drawing.Point(365, 100);
            this.dgvTurnuvalar.MultiSelect = false;
            this.dgvTurnuvalar.Name = "dgvTurnuvalar";
            this.dgvTurnuvalar.ReadOnly = true;
            this.dgvTurnuvalar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTurnuvalar.Size = new System.Drawing.Size(583, 288);
            this.dgvTurnuvalar.TabIndex = 53;
            this.dgvTurnuvalar.SelectionChanged += new System.EventHandler(this.dgvTurnuvalar_SelectionChanged);
            // 
            // cmbTurnuvaTuru
            // 
            this.cmbTurnuvaTuru.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTurnuvaTuru.ForeColor = System.Drawing.Color.Black;
            this.cmbTurnuvaTuru.FormattingEnabled = true;
            this.cmbTurnuvaTuru.Items.AddRange(new object[] {
            "bireysel",
            "takım"});
            this.cmbTurnuvaTuru.Location = new System.Drawing.Point(602, 429);
            this.cmbTurnuvaTuru.Name = "cmbTurnuvaTuru";
            this.cmbTurnuvaTuru.Size = new System.Drawing.Size(200, 28);
            this.cmbTurnuvaTuru.TabIndex = 61;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(598, 406);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 20);
            this.label8.TabIndex = 60;
            this.label8.Text = "Turnuva Türü";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(366, 406);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 20);
            this.label9.TabIndex = 59;
            this.label9.Text = "Turnuva Tarihi";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(366, 458);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(118, 20);
            this.label10.TabIndex = 58;
            this.label10.Text = "Turnuva Oyunu";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(598, 460);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(166, 20);
            this.label11.TabIndex = 57;
            this.label11.Text = "Minimum Ödül Miktarı";
            // 
            // txtOdulMin
            // 
            this.txtOdulMin.Location = new System.Drawing.Point(602, 483);
            this.txtOdulMin.Name = "txtOdulMin";
            this.txtOdulMin.Size = new System.Drawing.Size(200, 26);
            this.txtOdulMin.TabIndex = 56;
            // 
            // dtTarih
            // 
            this.dtTarih.CalendarForeColor = System.Drawing.Color.Black;
            this.dtTarih.Location = new System.Drawing.Point(370, 429);
            this.dtTarih.Name = "dtTarih";
            this.dtTarih.Size = new System.Drawing.Size(200, 26);
            this.dtTarih.TabIndex = 55;
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
            this.cmbOyun.Location = new System.Drawing.Point(370, 481);
            this.cmbOyun.Name = "cmbOyun";
            this.cmbOyun.Size = new System.Drawing.Size(200, 28);
            this.cmbOyun.TabIndex = 54;
            // 
            // btnFiltrele
            // 
            this.btnFiltrele.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnFiltrele.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFiltrele.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnFiltrele.ForeColor = System.Drawing.Color.White;
            this.btnFiltrele.Location = new System.Drawing.Point(875, 423);
            this.btnFiltrele.Name = "btnFiltrele";
            this.btnFiltrele.Size = new System.Drawing.Size(97, 42);
            this.btnFiltrele.TabIndex = 62;
            this.btnFiltrele.Text = "FİLTRELE";
            this.btnFiltrele.UseVisualStyleBackColor = false;
            this.btnFiltrele.Click += new System.EventHandler(this.btnFiltrele_Click);
            // 
            // btnSil
            // 
            this.btnSil.BackColor = System.Drawing.Color.White;
            this.btnSil.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSil.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSil.ForeColor = System.Drawing.Color.Black;
            this.btnSil.Location = new System.Drawing.Point(815, 423);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(54, 42);
            this.btnSil.TabIndex = 63;
            this.btnSil.Text = "SİL";
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label12.Location = new System.Drawing.Point(100, 71);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(188, 25);
            this.label12.TabIndex = 64;
            this.label12.Text = "TURNUVA EKLEME";
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReset.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(851, 471);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(97, 42);
            this.btnReset.TabIndex = 65;
            this.btnReset.Text = "RESET";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnGuncelle.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGuncelle.ForeColor = System.Drawing.Color.White;
            this.btnGuncelle.Location = new System.Drawing.Point(174, 493);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(114, 43);
            this.btnGuncelle.TabIndex = 66;
            this.btnGuncelle.Text = "GÜNCELLE";
            this.btnGuncelle.UseVisualStyleBackColor = false;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // cmbParticipantLimit
            // 
            this.cmbParticipantLimit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParticipantLimit.FormattingEnabled = true;
            this.cmbParticipantLimit.Items.AddRange(new object[] {
            "4",
            "8"});
            this.cmbParticipantLimit.Location = new System.Drawing.Point(124, 403);
            this.cmbParticipantLimit.Name = "cmbParticipantLimit";
            this.cmbParticipantLimit.Size = new System.Drawing.Size(200, 28);
            this.cmbParticipantLimit.TabIndex = 67;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(14, 403);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(109, 20);
            this.label13.TabIndex = 68;
            this.label13.Text = "Katılımcı Sayısı";
            // 
            // AddTournamentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(989, 548);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cmbParticipantLimit);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnFiltrele);
            this.Controls.Add(this.cmbTurnuvaTuru);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtOdulMin);
            this.Controls.Add(this.dtTarih);
            this.Controls.Add(this.cmbOyun);
            this.Controls.Add(this.dgvTurnuvalar);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.btnTemizle);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtPrizePool);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.cmbGame);
            this.Controls.Add(this.txtTname);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AddTournamentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddTournamentForm";
            this.Load += new System.EventHandler(this.AddTournamentForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnuvalar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtTname;
        private System.Windows.Forms.ComboBox cmbGame;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.TextBox txtPrizePool;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.DataGridView dgvTurnuvalar;
        private System.Windows.Forms.ComboBox cmbTurnuvaTuru;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtOdulMin;
        private System.Windows.Forms.DateTimePicker dtTarih;
        private System.Windows.Forms.ComboBox cmbOyun;
        private System.Windows.Forms.Button btnFiltrele;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.ComboBox cmbParticipantLimit;
        private System.Windows.Forms.Label label13;
    }
}