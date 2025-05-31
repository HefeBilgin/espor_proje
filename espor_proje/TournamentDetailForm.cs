using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace espor_proje
{
    public partial class TournamentDetailForm : Form
    {
        private int tournamentId;
        private int participantLimit = 0;
        string connStr = "Host=localhost;Port=5432;Username=postgres;Password=052527;Database=dbespor;";

        public TournamentDetailForm(int id)
        {
            InitializeComponent();
            tournamentId = id;
        }

        private void TournamentDetailForm_Load(object sender, EventArgs e)
        {
            using (var conn = new NpgsqlConnection(connStr))
            {
                conn.Open();
                string query = @"SELECT tname, tgame, prize_pool, start_date, participation_type, participant_limit 
                                 FROM tournaments 
                                 WHERE id = @id";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", tournamentId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblTname.Text = reader.GetString(0);
                            lblTgame.Text = reader.GetString(1);
                            lblPrize.Text = reader.GetDecimal(2).ToString("C");
                            lblDate.Text = reader.GetDateTime(3).ToShortDateString();
                            lblTurnuvaTuru.Text = reader.GetString(4); // bireysel veya takım
                            participantLimit = reader.GetInt32(5);
                            lblParticipantLimit.Text = participantLimit.ToString();
                        }
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnKatil_Click(object sender, EventArgs e)
        {
            int kullaniciId = KullaniciGiris.KullaniciId;
            string tur = lblTurnuvaTuru.Text;

            using (var conn = new NpgsqlConnection(connStr))
            {
                conn.Open();

                // Katılım sayısı kontrolü
                string countQuery = "SELECT COUNT(*) FROM participants WHERE tournament_id = @tid";
                int mevcutKatilimci = 0;
                using (var countCmd = new NpgsqlCommand(countQuery, conn))
                {
                    countCmd.Parameters.AddWithValue("@tid", tournamentId);
                    mevcutKatilimci = Convert.ToInt32(countCmd.ExecuteScalar());

                    if (mevcutKatilimci >= participantLimit)
                    {
                        MessageBox.Show("Turnuva katılımcı limiti dolmuştur. Katılım yapılamaz.");
                        return;
                    }
                }

                // Kullanıcının daha önce katılıp katılmadığını kontrol et
                string kontrolQuery = @"
                    SELECT COUNT(*) 
                    FROM participants 
                    WHERE tournament_id = @tid 
                    AND (user_id = @uid OR team_id IN (SELECT id FROM teams WHERE captain_id = @uid))
                ";
                using (var kontrolCmd = new NpgsqlCommand(kontrolQuery, conn))
                {
                    kontrolCmd.Parameters.AddWithValue("@tid", tournamentId);
                    kontrolCmd.Parameters.AddWithValue("@uid", kullaniciId);
                    int count = Convert.ToInt32(kontrolCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("Zaten bu turnuvaya katıldınız.");
                        return;
                    }
                }

                if (tur == "bireysel")
                {
                    string insertQuery = @"
                        INSERT INTO participants (tournament_id, user_id, participation_type) 
                        VALUES (@tid, @uid, 'bireysel')
                    ";
                    using (var cmd = new NpgsqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@tid", tournamentId);
                        cmd.Parameters.AddWithValue("@uid", kullaniciId);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Turnuvaya başarıyla katıldınız (Bireysel).");
                        this.Hide();
                    }
                }
                else if (tur == "takım")
                {
                    string teamQuery = "SELECT id FROM teams WHERE captain_id = @uid";
                    using (var teamCmd = new NpgsqlCommand(teamQuery, conn))
                    {
                        teamCmd.Parameters.AddWithValue("@uid", kullaniciId);
                        var teamId = teamCmd.ExecuteScalar();

                        if (teamId == null)
                        {
                            MessageBox.Show("Takımlı turnuvaya katılmak için önce takım oluşturmalısınız.");
                            return;
                        }

                        string insertQuery = @"
                            INSERT INTO participants (tournament_id, team_id, participation_type) 
                            VALUES (@tid, @teamid, 'takım')
                        ";
                        using (var cmd = new NpgsqlCommand(insertQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@tid", tournamentId);
                            cmd.Parameters.AddWithValue("@teamid", (int)teamId);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Turnuvaya başarıyla katıldınız (Takım).");
                            this.Hide();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Turnuva türü belirlenemedi.");
                }
            }
        }
    }
}
