using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace espor_proje
{
    public partial class List_scores : Form
    {
        public List_scores()
        {
            InitializeComponent();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AnaForm anaForm = new AnaForm();
            anaForm.Show();
            this.Hide();
        }

        private void List_scores_Load(object sender, EventArgs e)
        {

            listView1.View = View.Details;
            listView1.Columns.Add("Kazandığım Turnuvalar", 180);
            listView1.Columns.Add("Oyun", 100);
            listView1.Columns.Add("Ödül", 80);
            listView1.Columns.Add("Tarih", 100);
            listView1.FullRowSelect = true;

            LoadMyResults();
        }

        private void LoadMyResults()
        {
            listView1.Items.Clear(); // Temizle
            int userId = KullaniciGiris.KullaniciId;

            string connString = "Host=localhost;Port=5432;Username=postgres;Password=052527;Database=dbespor;";

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                string query = @"
            SELECT t.tname, t.tgame, t.prize_pool, t.start_date
            FROM participants p
            JOIN tournaments t ON p.tournament_id = t.id
            LEFT JOIN teams tm ON p.team_id = tm.id
            WHERE p.score = 100 AND (
                (t.participation_type = 'bireysel' AND p.user_id = @userId)
                OR
                (t.participation_type = 'takım' AND tm.captain_id = @userId)
            );
        ";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("userId", userId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string tname = reader["tname"].ToString();
                            string game = reader["tgame"].ToString();
                            string prize = reader["prize_pool"].ToString();
                            string date = Convert.ToDateTime(reader["start_date"]).ToShortDateString();

                            ListViewItem item = new ListViewItem(tname);
                            item.SubItems.Add(game);
                            item.SubItems.Add(prize + " ₺");
                            item.SubItems.Add(date);

                            listView1.Items.Add(item);
                        }
                    }
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
