using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace espor_proje
{
    public partial class TournamentListForm : Form
    {
        string connStr = "Host=localhost;Port=5432;Username=postgres;Password=052527;Database=dbespor;";

        public TournamentListForm()
        {
            InitializeComponent();
        }

        private void TournamentListForm_Load(object sender, EventArgs e)
        {
            TurnuvalariYukle();
            TemizleGecmisTurnuvalar();
            dgvTurnuvalar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            cmbTurnuvaTuru.Items.Clear();
            cmbTurnuvaTuru.Items.Add("bireysel");
            cmbTurnuvaTuru.Items.Add("takım");
            cmbTurnuvaTuru.SelectedIndex = -1;
        }

        private void TurnuvalariYukle(string oyun = "", decimal? minOdul = null, DateTime? tarih = null, string tur = "")
        {
            using (var conn = new NpgsqlConnection(connStr))
            {
                conn.Open();

                string query = @"SELECT 
                                    id, 
                                    tname AS ""Turnuva Adı"", 
                                    tgame AS ""Oyun"", 
                                    start_date AS ""Başlangıç Tarihi"", 
                                    prize_pool AS ""Ödül"", 
                                    participation_type AS ""Turnuva Türü"",
                                    participant_limit AS ""Katılımcı Limiti""
                                FROM tournaments 
                                WHERE 1=1";

                query += " AND NOT EXISTS (SELECT 1 FROM participants p WHERE p.tournament_id = tournaments.id AND p.score IS NOT NULL)";

                var cmd = new NpgsqlCommand();
                cmd.Connection = conn;

                if (!string.IsNullOrEmpty(oyun))
                {
                    query += " AND tgame = @oyun";
                    cmd.Parameters.AddWithValue("@oyun", oyun);
                }

                if (minOdul.HasValue)
                {
                    query += " AND prize_pool >= @minOdul";
                    cmd.Parameters.AddWithValue("@minOdul", minOdul.Value);
                }

                if (tarih.HasValue)
                {
                    query += " AND start_date = @tarih";
                    cmd.Parameters.AddWithValue("@tarih", tarih.Value.Date);
                }

                if (!string.IsNullOrEmpty(tur))
                {
                    query += " AND participation_type = @tur";
                    cmd.Parameters.AddWithValue("@tur", tur);
                }

                cmd.CommandText = query;

                var da = new NpgsqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dgvTurnuvalar.DataSource = dt;
                dgvTurnuvalar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvTurnuvalar.Columns["id"].Visible = false;
            }
        }

        private void btnFiltrele_Click(object sender, EventArgs e)
        {
            string oyun = cmbOyun.SelectedItem?.ToString() ?? "";
            decimal? minOdul = decimal.TryParse(txtOdulMin.Text, out decimal odul) ? odul : (decimal?)null;
            DateTime? tarih = dtTarih.Checked ? dtTarih.Value.Date : (DateTime?)null;
            string tur = cmbTurnuvaTuru.SelectedItem?.ToString() ?? "";

            TurnuvalariYukle(oyun, minOdul, tarih, tur);
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

        private void TemizleGecmisTurnuvalar()
        {
            using (var conn = new NpgsqlConnection(connStr))
            {
                conn.Open();
                string query = "DELETE FROM tournaments WHERE start_date < CURRENT_DATE";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void dgvTurnuvalar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int selectedId = Convert.ToInt32(dgvTurnuvalar.Rows[e.RowIndex].Cells["id"].Value);
                TournamentDetailForm detayForm = new TournamentDetailForm(selectedId);
                detayForm.Show();
            }
        }

        private void dgvTurnuvalar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TurnuvalariYukle();
        }
    }
}
