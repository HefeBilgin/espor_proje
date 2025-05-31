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
using System.Security.Cryptography;
using System.Net.Mail;

namespace espor_proje
{
    public partial class kayitEkrani : Form
    {
       

        public kayitEkrani()
        {
            InitializeComponent();
        }

        NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost; Port=5432; Database=dbespor; User Id=postgres; Password=052527");

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. E-posta format kontrolü
            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Geçerli bir e-posta adresi giriniz.");
                return;
            }

            // 2. E-posta daha önce kayıtlı mı?
            using (var conn = new NpgsqlConnection("Server=localhost;Port=5432;Username=postgres;Password=052527;Database=dbespor"))
            {
                conn.Open();

                var emailCmd = new NpgsqlCommand("SELECT COUNT(*) FROM users WHERE email = @mail", conn);
                emailCmd.Parameters.AddWithValue("@mail", txtEmail.Text);
                int emailCount = Convert.ToInt32(emailCmd.ExecuteScalar());

                if (emailCount > 0)
                {
                    MessageBox.Show("Bu e-posta adresi zaten kayıtlı.");
                    return;
                }

                // 3. Username kontrolü
                var usernameCmd = new NpgsqlCommand("SELECT COUNT(*) FROM users WHERE username = @username", conn);
                usernameCmd.Parameters.AddWithValue("@username", txtUsername.Text);
                int usernameCount = Convert.ToInt32(usernameCmd.ExecuteScalar());

                if (usernameCount > 0)
                {
                    MessageBox.Show("Bu kullanıcı adı zaten alınmış. Lütfen başka bir tane seçiniz.");
                    return;
                }

                // 4. Telefon numarası kontrolü
                var phoneCmd = new NpgsqlCommand("SELECT COUNT(*) FROM users WHERE phone_number = @phone", conn);
                phoneCmd.Parameters.AddWithValue("@phone", txtTelefon.Text);
                int phoneCount = Convert.ToInt32(phoneCmd.ExecuteScalar());

                if (phoneCount > 0)
                {
                    MessageBox.Show("Bu telefon numarası zaten kayıtlı.");
                    return;
                }

                // Yaş kontrolü (en az 16 olmalı)
                int yas = CalculateAge(dtpDogumTarihi.Value.Date);
                if (yas < 16)
                {
                    MessageBox.Show("Kayıt olabilmek için en az 16 yaşında olmalısınız.");
                    return;
                }

                // 5. Her şey uygunsa kayıt eklenir
                string sql = @"INSERT INTO users (username, full_name, email, phone_number, password_hash, gender, birth_date)
                       VALUES (@username, @full_name, @mail, @phone, @password, @gender, @birth_date)";

                var insertCmd = new NpgsqlCommand(sql, conn);
                insertCmd.Parameters.AddWithValue("@username", txtUsername.Text);
                insertCmd.Parameters.AddWithValue("@full_name", txtAd.Text);
                insertCmd.Parameters.AddWithValue("@mail", txtEmail.Text);
                insertCmd.Parameters.AddWithValue("@phone", txtTelefon.Text);
                insertCmd.Parameters.AddWithValue("@password", txtSifre.Text);
                insertCmd.Parameters.AddWithValue("@gender", cmbCinsiyet.SelectedItem.ToString());
                insertCmd.Parameters.AddWithValue("@birth_date", dtpDogumTarihi.Value.Date);

                insertCmd.ExecuteNonQuery();
            }

            MessageBox.Show("Kayıt başarıyla eklendi!");

            // Temizleme ve form geçişi
            txtUsername.Clear();
            txtAd.Clear();
            txtEmail.Clear();
            txtTelefon.Clear();
            txtSifre.Clear();
            cmbCinsiyet.SelectedIndex = -1;
            

            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void kayitEkrani_Load(object sender, EventArgs e)
        {
            dtpDogumTarihi.MaxDate = DateTime.Today;
        }

        private void label10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }
        private int CalculateAge(DateTime birthDate)
        {
            var today = DateTime.Today;
            int age = today.Year - birthDate.Year;
            if (birthDate > today.AddYears(-age)) age--;
            return age;
        }
    }
}