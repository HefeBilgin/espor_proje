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
    public partial class AddTournamentForm : Form
    {
        public AddTournamentForm()
        {
            InitializeComponent();
        }

        private readonly string connStr = "Host=localhost;Port=5432;Username=postgres;Password=052527;Database=dbespor;";

        private void AddTournamentForm_Load(object sender, EventArgs e)
        {
            TurnuvalariListele();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            using (var conn = new NpgsqlConnection(connStr))
            {
                conn.Open();

                string query = @"INSERT INTO tournaments 
                         (tname, tgame, start_date, prize_pool, description, organizer_id, created_at, participation_type, participant_limit) 
                         VALUES 
                         (@tname, @tgame, @start_date, @prize_pool, @description, @organizer_id, @created_at, @participation_type, @participant_limit)";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tname", txtTname.Text);
                    cmd.Parameters.AddWithValue("@tgame", cmbGame.Text);
                    cmd.Parameters.AddWithValue("@start_date", dtpStartDate.Value);
                    cmd.Parameters.AddWithValue("@prize_pool", Decimal.Parse(txtPrizePool.Text));
                    cmd.Parameters.AddWithValue("@description", txtDescription.Text);
                    cmd.Parameters.AddWithValue("@organizer_id", KullaniciGiris.KullaniciId);
                    cmd.Parameters.AddWithValue("@created_at", DateTime.Now);
                    cmd.Parameters.AddWithValue("@participation_type", cmbType.Text);
                    cmd.Parameters.AddWithValue("@participant_limit", int.Parse(cmbParticipantLimit.Text));

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Turnuva başarıyla eklendi.");
                txtTname.Clear();
                cmbGame.SelectedIndex = -1;
                dtpStartDate.Value = DateTime.Now;
                txtPrizePool.Clear();
                txtDescription.Clear();
                cmbType.SelectedIndex = -1;
                cmbParticipantLimit.SelectedIndex = -1;

                TurnuvalariListele();
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtTname.Clear();
            cmbGame.SelectedIndex = -1;
            dtpStartDate.Value = DateTime.Now;
            txtPrizePool.Clear();
            txtDescription.Clear();
            cmbType.SelectedIndex = -1;
            cmbParticipantLimit.SelectedIndex = -1;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TurnuvalariListele()
        {
            using (var conn = new NpgsqlConnection(connStr))
            {
                conn.Open();
                string query = "select*from List_Tournament;";
                using (var da = new NpgsqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvTurnuvalar.DataSource = dt;

                    dgvTurnuvalar.Columns["id"].HeaderText = "ID";
                    dgvTurnuvalar.Columns["tname"].HeaderText = "Turnuva Adı";
                    dgvTurnuvalar.Columns["tgame"].HeaderText = "Oyun";
                    dgvTurnuvalar.Columns["start_date"].HeaderText = "Başlangıç Tarihi";
                    dgvTurnuvalar.Columns["prize_pool"].HeaderText = "Ödül Havuzu";
                    dgvTurnuvalar.Columns["description"].HeaderText = "Açıklama";
                    dgvTurnuvalar.Columns["participation_type"].HeaderText = "Katılım Türü";
                    dgvTurnuvalar.Columns["participant_limit"].HeaderText = "Katılımcı Limiti";

                    dgvTurnuvalar.Columns["id"].Visible = false;
                    dgvTurnuvalar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dgvTurnuvalar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvTurnuvalar.MultiSelect = false;
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            TurnuvalariListele();
            cmbOyun.SelectedIndex = -1;
            txtOdulMin.Clear();
            cmbTurnuvaTuru.SelectedIndex = -1;
        }

        private void btnFiltrele_Click(object sender, EventArgs e)
        {
            using (var conn = new NpgsqlConnection(connStr))
            {
                conn.Open();
                string query = @"SELECT id, tname, tgame, start_date, prize_pool, description, participation_type, participant_limit 
                                 FROM tournaments
                                 WHERE 
                                     (@date IS NULL OR start_date = @date) AND
                                     (@type IS NULL OR participation_type = @type) AND
                                     (@game IS NULL OR tgame = @game) AND
                                     (@minPrize IS NULL OR prize_pool >= @minPrize)";

                var cmd = new NpgsqlCommand(query, conn);

                cmd.Parameters.Add("@date", NpgsqlTypes.NpgsqlDbType.Date);
                cmd.Parameters["@date"].Value = dtTarih.Checked ? dtTarih.Value.Date : (object)DBNull.Value;

                cmd.Parameters.Add("@type", NpgsqlTypes.NpgsqlDbType.Varchar);
                cmd.Parameters["@type"].Value = string.IsNullOrEmpty(cmbTurnuvaTuru.Text) ? (object)DBNull.Value : cmbTurnuvaTuru.Text;

                cmd.Parameters.Add("@game", NpgsqlTypes.NpgsqlDbType.Varchar);
                cmd.Parameters["@game"].Value = string.IsNullOrEmpty(cmbOyun.Text) ? (object)DBNull.Value : cmbOyun.Text;

                cmd.Parameters.Add("@minPrize", NpgsqlTypes.NpgsqlDbType.Numeric);
                if (decimal.TryParse(txtOdulMin.Text, out decimal minPrize))
                    cmd.Parameters["@minPrize"].Value = minPrize;
                else
                    cmd.Parameters["@minPrize"].Value = DBNull.Value;

                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());

                dgvTurnuvalar.DataSource = dt;

                dgvTurnuvalar.Columns["id"].Visible = false;
                dgvTurnuvalar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvTurnuvalar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvTurnuvalar.MultiSelect = false;

                dgvTurnuvalar.Columns["tname"].HeaderText = "Turnuva Adı";
                dgvTurnuvalar.Columns["tgame"].HeaderText = "Oyun";
                dgvTurnuvalar.Columns["start_date"].HeaderText = "Başlangıç Tarihi";
                dgvTurnuvalar.Columns["prize_pool"].HeaderText = "Ödül Havuzu";
                dgvTurnuvalar.Columns["participation_type"].HeaderText = "Katılım Türü";
                dgvTurnuvalar.Columns["participant_limit"].HeaderText = "Katılımcı Limiti";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            AnaForm anaForm = new AnaForm();
            anaForm.Show();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvTurnuvalar.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek için bir turnuva seçin.");
                return;
            }

            DialogResult result = MessageBox.Show("Seçilen turnuvayı silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes) return;

            int selectedId = Convert.ToInt32(dgvTurnuvalar.SelectedRows[0].Cells["id"].Value);

            using (var conn = new NpgsqlConnection(connStr))
            {
                conn.Open();
                string deleteQuery = "DELETE FROM tournaments WHERE id = @id";

                using (var cmd = new NpgsqlCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@id", selectedId);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Turnuva başarıyla silindi.");
            TurnuvalariListele();
        }

        private void dgvTurnuvalar_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTurnuvalar.SelectedRows.Count > 0)
            {
                var row = dgvTurnuvalar.SelectedRows[0];
                txtTname.Text = row.Cells["tname"].Value.ToString();
                cmbGame.Text = row.Cells["tgame"].Value.ToString();
                dtpStartDate.Value = Convert.ToDateTime(row.Cells["start_date"].Value);
                txtPrizePool.Text = row.Cells["prize_pool"].Value.ToString();
                txtDescription.Text = row.Cells["description"].Value.ToString();
                cmbType.Text = row.Cells["participation_type"].Value.ToString();
                cmbParticipantLimit.Text = row.Cells["participant_limit"].Value.ToString();
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dgvTurnuvalar.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen güncellenecek bir turnuva seçin.");
                return;
            }

            int id = Convert.ToInt32(dgvTurnuvalar.SelectedRows[0].Cells["id"].Value);

            using (var conn = new NpgsqlConnection(connStr))
            {
                conn.Open();
                string query = @"UPDATE tournaments SET 
                            tname = @tname, 
                            tgame = @tgame, 
                            start_date = @start_date, 
                            prize_pool = @prize_pool, 
                            description = @description, 
                            participation_type = @participation_type,
                            participant_limit = @participant_limit
                         WHERE id = @id";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@tname", txtTname.Text);
                    cmd.Parameters.AddWithValue("@tgame", cmbGame.Text);
                    cmd.Parameters.AddWithValue("@start_date", dtpStartDate.Value);
                    cmd.Parameters.AddWithValue("@prize_pool", Decimal.Parse(txtPrizePool.Text));
                    cmd.Parameters.AddWithValue("@description", txtDescription.Text);
                    cmd.Parameters.AddWithValue("@participation_type", cmbType.Text);
                    cmd.Parameters.AddWithValue("@participant_limit", int.Parse(cmbParticipantLimit.Text));

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Turnuva bilgileri güncellendi.");
                TurnuvalariListele();
            }
        }
    }
}
