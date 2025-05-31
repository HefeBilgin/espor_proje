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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            kayitEkrani kayitEkrani = new kayitEkrani();
            kayitEkrani.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connStr = "Host=localhost;Port=5432;Username=postgres;Password=052527;Database=dbespor";
            using (var conn = new NpgsqlConnection(connStr))
            {
                conn.Open();

                string email = txtEmail.Text;
                string password = txtPassword.Text;

                string query = "SELECT id, full_name, email FROM users WHERE email = @email AND password_hash = @password";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", password); // Artık hash yok

                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        int userId = reader.GetInt32(reader.GetOrdinal("id"));
                        string userAd = reader.GetString(reader.GetOrdinal("full_name"));
                        string userEmail = reader.GetString(reader.GetOrdinal("email"));

                        KullaniciBilgisi.Id = userId;
                        KullaniciBilgisi.Ad = userAd;
                        KullaniciBilgisi.Email = userEmail;

                        KullaniciGiris.KullaniciId = userId;
                        KullaniciGiris.KullaniciAd = userAd;

                        AnaForm anaForm = new AnaForm();
                        anaForm.Show();
                        this.Hide();
                        MessageBox.Show("Giriş başarılı! Hoşgeldiniz.");
                    }
                    else
                    {
                        MessageBox.Show("E-posta veya şifre yanlış!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
