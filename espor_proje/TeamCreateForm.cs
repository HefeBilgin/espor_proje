using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace espor_proje
{
    public partial class TeamCreateForm : Form
    {
        public TeamCreateForm()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnTakimOlustur_Click(object sender, EventArgs e)
        {
            int kullaniciId = KullaniciGiris.KullaniciId;
            string takimAdi = txtTeamName.Text.Trim(); // takım adını girdiğin TextBox
            string oyun = cmbOyun.SelectedItem?.ToString(); // takımın ait olduğu oyun
            DateTime kurulusTarihi = dtKurulusTarihi.Value.Date;

            if (string.IsNullOrWhiteSpace(takimAdi) || string.IsNullOrWhiteSpace(oyun))
            {
                MessageBox.Show("Lütfen takım adı ve oyun seçiniz.");
                return;
            }

            using (var conn = new NpgsqlConnection("Host=localhost;Port=5432;Username=postgres;Password=052527;Database=dbespor;"))
            {
                conn.Open();

                string query = "INSERT INTO teams (name, captain_id, game, created_at) VALUES (@name, @captain, @game, @created)";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", takimAdi);
                    cmd.Parameters.AddWithValue("@captain", kullaniciId);
                    cmd.Parameters.AddWithValue("@game", oyun);
                    cmd.Parameters.AddWithValue("@created", kurulusTarihi);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Takım başarıyla oluşturuldu.");

            txtTeamName.Clear();
            cmbOyun.SelectedIndex = -1; // Seçimi temizle
            dtKurulusTarihi.Value = DateTime.Now; // Bugüne sıfırla
            this.Hide();
        }
    }
}
