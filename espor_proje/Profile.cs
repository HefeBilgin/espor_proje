using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace espor_proje
{
    public partial class Profile : Form
    {
        public Profile()
        {
            InitializeComponent();
        }

        private void YasGoster()
        {
            using (var conn = new NpgsqlConnection("Host=localhost;Port=5432;Username=postgres;Password=052527;Database=dbespor;"))
            {
                conn.Open();
                string query = "SELECT get_user_age(@id)";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", KullaniciGiris.KullaniciId);

                    var result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        label13.Text = result.ToString() + " yaşında";
                    }
                    else
                    {
                        label13.Text = "Yaş bilgisi yok.";
                    }
                }
            }
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            dtpBirthDate.MaxDate = DateTime.Today;
            int userId = KullaniciGiris.KullaniciId;

            using (var conn = new NpgsqlConnection("Host=localhost;Port=5432;Username=postgres;Password=052527;Database=dbespor"))
            {
                conn.Open();
                string query = "SELECT username, full_name, email, phone_number, password_hash, birth_date, fav_game FROM users WHERE id = @id";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("id", userId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtUsername.Text = reader["username"].ToString();
                            txtFullName.Text = reader["full_name"].ToString();
                            txtEmail.Text = reader["email"].ToString();
                            txtPhone.Text = reader["phone_number"].ToString();
                            txtPassword.Text = reader["password_hash"].ToString();
                            dtpBirthDate.Value = Convert.ToDateTime(reader["birth_date"]);

                            string favGame = reader["fav_game"]?.ToString();
                            if (!string.IsNullOrEmpty(favGame))
                                cmbFavGame.SelectedItem = favGame;
                        }
                    }
                }
            }
            YasGoster();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int userId = KullaniciGiris.KullaniciId;

            using (var conn = new NpgsqlConnection("Host=localhost;Port=5432;Username=postgres;Password=052527;Database=dbespor"))
            {
                conn.Open();
                string query = @"UPDATE users SET 
                         username = @username,
                         full_name = @fullName,
                         email = @mail,
                         phone_number = @phone,
                         password_hash = @password,
                         birth_date = @birthDate,
                         fav_game = @favGame
                         WHERE id = @id";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("username", txtUsername.Text);
                    cmd.Parameters.AddWithValue("fullName", txtFullName.Text);
                    cmd.Parameters.AddWithValue("mail", txtEmail.Text);
                    cmd.Parameters.AddWithValue("phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("password", txtPassword.Text);
                    cmd.Parameters.AddWithValue("birthDate", dtpBirthDate.Value);
                    cmd.Parameters.AddWithValue("favGame", cmbFavGame.SelectedItem?.ToString() ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("id", userId);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Bilgiler başarıyla güncellendi.");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int userId = KullaniciGiris.KullaniciId;

            var confirm = MessageBox.Show("Hesabınızı silmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                using (var conn = new NpgsqlConnection("Host=localhost;Port=5432;Username=postgres;Password=052527;Database=dbespor"))
                {
                    conn.Open();

                    string query = "DELETE FROM users WHERE id = @id";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("id", userId);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Hesabınız silindi.");
                Application.Exit(); 

            }
        }

        private void dtpBirthDate_ValueChanged(object sender, EventArgs e)
        {
            YasGoster();
        }
    }
}
