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
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void AnaForm_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connStr = "Host=localhost;Port=5432;Username=postgres;Password=052527;Database=dbespor";

            using (var conn = new NpgsqlConnection(connStr))
            {
                conn.Open();

                // Kullanıcı ID'sini KullaniciBilgisi üzerinden alıyoruz
                int userId = KullaniciBilgisi.Id;

                if (userId == 0)
                {
                    MessageBox.Show("Hata: Kullanıcı ID geçersiz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kullanıcının rolünü doğrudan veritabanından çekiyoruz
                string query = "SELECT role FROM users WHERE id = @userId";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    var result = cmd.ExecuteScalar();

                    if (result == null)
                    {
                        MessageBox.Show("Hata: Kullanıcı veritabanında bulunamadı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string userRole = result.ToString(); // Kullanıcının rolü

                    // Kullanıcının rolüne göre yönlendirme yap
                    if (userRole == "admin")
                    {
                        AddTournamentForm addTournamentForm = new AddTournamentForm();
                        addTournamentForm.Show();
                    }
                    else if (userRole == "kullanici")
                    {
                        TournamentListForm tournamentListForm = new TournamentListForm();
                        tournamentListForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Hata: Geçersiz rol tanımı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }

            this.Hide(); // AnaForm'u gizle
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TeamCreateForm teamCreateForm = new TeamCreateForm();
            teamCreateForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string connStr = "Host=localhost;Port=5432;Username=postgres;Password=052527;Database=dbespor";

            using (var conn = new NpgsqlConnection(connStr))
            {
                conn.Open();

                // Kullanıcı ID'sini KullaniciBilgisi üzerinden alıyoruz
                int userId = KullaniciBilgisi.Id;

                if (userId == 0)
                {
                    MessageBox.Show("Hata: Kullanıcı ID geçersiz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kullanıcının rolünü doğrudan veritabanından çekiyoruz
                string query = "SELECT role FROM users WHERE id = @userId";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    var result = cmd.ExecuteScalar();

                    if (result == null)
                    {
                        MessageBox.Show("Hata: Kullanıcı veritabanında bulunamadı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string userRole = result.ToString(); // Kullanıcının rolü

                    // Kullanıcının rolüne göre yönlendirme yap
                    if (userRole == "admin")
                    {
                        ManageTournament manageTournamentForm = new ManageTournament();
                        manageTournamentForm.Show();
                    }
                    else if (userRole == "kullanici")
                    {
                        List_scores listScoresForm = new List_scores();
                        listScoresForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Hata: Geçersiz rol tanımı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }

            this.Hide(); // AnaForm'u gizle
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Profile profileForm = new Profile();
            profileForm.Show();
        }
    }
}
