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
    public partial class ManageTournament : Form
    {
        public ManageTournament()
        {
            InitializeComponent();
        }

        NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost; Port=5432; Database=dbespor; User Id=postgres; Password=052527");

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ManageTournament_Load(object sender, EventArgs e)
        {
            cmbTurnuvaSec.Items.Clear(); // önce temizle

            baglanti.Open();
            string sorgu = @"
        SELECT t.id, t.tname 
        FROM tournaments t
        WHERE NOT EXISTS (
            SELECT 1 FROM participants p 
            WHERE p.tournament_id = t.id AND p.score IS NOT NULL
        )";

            NpgsqlCommand komut = new NpgsqlCommand(sorgu, baglanti);
            NpgsqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                cmbTurnuvaSec.Items.Add(new KeyValuePair<int, string>((int)dr["id"], dr["tname"].ToString()));
            }

            cmbTurnuvaSec.DisplayMember = "Value";
            cmbTurnuvaSec.ValueMember = "Key";
            baglanti.Close();
        }

        private void cmbTurnuvaSec_SelectedIndexChanged(object sender, EventArgs e)
        {
            var secilen = (KeyValuePair<int, string>)cmbTurnuvaSec.SelectedItem;
            int turnuvaId = secilen.Key;

            baglanti.Open();
            string turnuvaSorgu = "SELECT participation_type, participant_limit FROM tournaments WHERE id = @id";
            NpgsqlCommand cmd = new NpgsqlCommand(turnuvaSorgu, baglanti);
            cmd.Parameters.AddWithValue("@id", turnuvaId);
            NpgsqlDataReader rdr = cmd.ExecuteReader();

            string tur = "";
            int limit = 0;

            if (rdr.Read())
            {
                tur = rdr["participation_type"].ToString();
                limit = Convert.ToInt32(rdr["participant_limit"]);
            }
            rdr.Close();

            // Katılımcı sorgusu
            string katilimciSorgu = "";
            if (tur == "bireysel")
            {
                katilimciSorgu = "SELECT u.id, u.username FROM participants p JOIN users u ON p.user_id = u.id WHERE p.tournament_id = @id AND p.participation_type = 'bireysel'";
            }
            else if (tur == "takım")
            {
                katilimciSorgu = "SELECT t.id, t.name FROM participants p JOIN teams t ON p.team_id = t.id WHERE p.tournament_id = @id AND p.participation_type = 'takım'";
            }

            NpgsqlCommand katilimciCmd = new NpgsqlCommand(katilimciSorgu, baglanti);
            katilimciCmd.Parameters.AddWithValue("@id", turnuvaId);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(katilimciCmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count < limit)
            {
                MessageBox.Show($"Seçtiğiniz turnuva henüz {limit} kişilik katılımcıya ulaşmamıştır. (Şu an: {dt.Rows.Count})");                
                comboboxlarıTemzile();
                baglanti.Close();
                return;
            }

            // Tüm ComboBox'ları sakla önce
            ComboBox[] cmbKatilimcilar = { comboBox1, comboBox2, comboBox3, comboBox4, comboBox5, comboBox6, comboBox7, comboBox8 };
            Label[] lblKatilimcilar = { label1, label2, label3, label4, label5, label6, label7, label8 };

            for (int i = 0; i < 8; i++)
            {
                cmbKatilimcilar[i].Visible = false;
                lblKatilimcilar[i].Visible = false;
            }

            // Gerekli olan kadarını göster ve doldur
            for (int i = 0; i < limit; i++)
            {
                cmbKatilimcilar[i].Visible = true;
                lblKatilimcilar[i].Visible = true;

                cmbKatilimcilar[i].DataSource = dt.Copy(); // her combobox'a ayrı DataTable kopyası
                cmbKatilimcilar[i].DisplayMember = (tur == "bireysel") ? "username" : "name";
                cmbKatilimcilar[i].ValueMember = "id";
                cmbKatilimcilar[i].SelectedIndex = -1; // boş başlasın
            }

            baglanti.Close();
        }
        private void comboboxlarıTemzile() 
        {
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
            comboBox5.SelectedIndex = -1;
            comboBox6.SelectedIndex = -1;
            comboBox7.SelectedIndex = -1;
            comboBox8.SelectedIndex = -1;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (cmbTurnuvaSec.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir turnuva seçin.");
                return;
            }

            var secilen = (KeyValuePair<int, string>)cmbTurnuvaSec.SelectedItem;
            int turnuvaId = secilen.Key;

            ComboBox[] cmbKatilimcilar = { comboBox1, comboBox2, comboBox3, comboBox4, comboBox5, comboBox6, comboBox7, comboBox8 };
            List<int> secilenKatilimciIdleri = new List<int>();

            // Boş kontrolü ve ID toplama
            foreach (var cb in cmbKatilimcilar.Where(c => c.Visible))
            {
                if (cb.SelectedItem == null)
                {
                    MessageBox.Show("Lütfen tüm sıraları doldurun.");
                    return;
                }

                int id = Convert.ToInt32(((DataRowView)cb.SelectedItem)["id"]);

                if (secilenKatilimciIdleri.Contains(id))
                {
                    MessageBox.Show("Aynı katılımcı birden fazla kez seçilemez.");
                    return;
                }

                secilenKatilimciIdleri.Add(id);
            }

            // Emin misiniz sorusu
            DialogResult result = MessageBox.Show("Sıralamayı kaydetmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo);
            if (result == DialogResult.No) return;

            // Puanlama mantığı (örnek: 1.→100, 2.→80, 3.→60, ...)
            int[] puanlar = { 100, 80, 60, 40, 20, 10, 5, 2 }; // max 8 kişilik
            baglanti.Open();

            for (int i = 0; i < secilenKatilimciIdleri.Count; i++)
            {
                int katilimciId = secilenKatilimciIdleri[i];
                int puan = puanlar[i];

                NpgsqlCommand guncelle = new NpgsqlCommand(
                    "UPDATE participants SET score = @score WHERE tournament_id = @tid AND (user_id = @id OR team_id = @id)", baglanti);
                guncelle.Parameters.AddWithValue("@score", puan);
                guncelle.Parameters.AddWithValue("@tid", turnuvaId);
                guncelle.Parameters.AddWithValue("@id", katilimciId);
                guncelle.ExecuteNonQuery();
            }

            baglanti.Close();

            MessageBox.Show("Puanlar başarıyla kaydedildi!");

            // Bu turnuvayı ComboBox'tan kaldır
            cmbTurnuvaSec.Items.Remove(cmbTurnuvaSec.SelectedItem);
            cmbTurnuvaSec.SelectedIndex = -1;


            // Temizle
            foreach (var cb in cmbKatilimcilar)
            {
                cb.Visible = false;
                cb.DataSource = null;
            }

            // İlgili labelleri de gizle
            Label[] lblKatilimcilar = { label1, label2, label3, label4, label5, label6, label7, label8 };
            foreach (var lbl in lblKatilimcilar) lbl.Visible = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            comboboxlarıTemzile();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AnaForm anaForm = new AnaForm();
            anaForm.Show();
            this.Hide();
        }
    }
}
