namespace espor_proje
{
    partial class TeamCreateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeamCreateForm));
            this.txtTeamName = new System.Windows.Forms.TextBox();
            this.btnTakimOlustur = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbOyun = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtKurulusTarihi = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTeamName
            // 
            this.txtTeamName.Location = new System.Drawing.Point(112, 146);
            this.txtTeamName.Name = "txtTeamName";
            this.txtTeamName.Size = new System.Drawing.Size(179, 26);
            this.txtTeamName.TabIndex = 0;
            // 
            // btnTakimOlustur
            // 
            this.btnTakimOlustur.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnTakimOlustur.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTakimOlustur.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTakimOlustur.ForeColor = System.Drawing.Color.White;
            this.btnTakimOlustur.Location = new System.Drawing.Point(129, 322);
            this.btnTakimOlustur.Name = "btnTakimOlustur";
            this.btnTakimOlustur.Size = new System.Drawing.Size(105, 45);
            this.btnTakimOlustur.TabIndex = 12;
            this.btnTakimOlustur.Text = "Oluştur";
            this.btnTakimOlustur.UseVisualStyleBackColor = false;
            this.btnTakimOlustur.Click += new System.EventHandler(this.btnTakimOlustur_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(27, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Takım İsmi";
            // 
            // cmbOyun
            // 
            this.cmbOyun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOyun.FormattingEnabled = true;
            this.cmbOyun.Items.AddRange(new object[] {
            "Valorant",
            "League of Legends",
            "CS:GO"});
            this.cmbOyun.Location = new System.Drawing.Point(112, 205);
            this.cmbOyun.Name = "cmbOyun";
            this.cmbOyun.Size = new System.Drawing.Size(179, 28);
            this.cmbOyun.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(58, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Oyun";
            // 
            // dtKurulusTarihi
            // 
            this.dtKurulusTarihi.Location = new System.Drawing.Point(112, 265);
            this.dtKurulusTarihi.Name = "dtKurulusTarihi";
            this.dtKurulusTarihi.Size = new System.Drawing.Size(179, 26);
            this.dtKurulusTarihi.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(8, 265);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "Kuruluş Tarihi";
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.DarkSlateGray;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
            this.button5.Location = new System.Drawing.Point(314, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(35, 35);
            this.button5.TabIndex = 35;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(117, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(130, 130);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            // 
            // TeamCreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(353, 392);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtKurulusTarihi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbOyun);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTakimOlustur);
            this.Controls.Add(this.txtTeamName);
            this.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TeamCreateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TeamCreateForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTeamName;
        private System.Windows.Forms.Button btnTakimOlustur;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbOyun;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtKurulusTarihi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}