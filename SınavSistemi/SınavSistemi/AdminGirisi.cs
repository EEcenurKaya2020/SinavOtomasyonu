using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SınavSistemi
{
    public partial class AdminGirisi : Form
    {
        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da;
        public AdminGirisi()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                string kayit = "insert into Soru (soru, a, b, c, d, dogruCevap) values(@soru, @a, @b, @c, @d, @dogruCevap)";
                SqlCommand komut = new SqlCommand(kayit, baglanti);

                komut.Parameters.AddWithValue("@soru", lbl_soru.Text);
                komut.Parameters.AddWithValue("@a", lbl_a.Text);
                komut.Parameters.AddWithValue("@b", lbl_b.Text);
                komut.Parameters.AddWithValue("@c", lbl_c.Text);
                komut.Parameters.AddWithValue("@d", lbl_d.Text);
                komut.Parameters.AddWithValue("@dogruCevap", lbl_dgr.Text);
                //komut.Parameters.Add("@resim", SqlDbType.Image, Picture.Length).Value = Picture;
                //komut.Parameters.AddWithValue("@resim", Picture.Image);

                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayıt Eklendi");
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata meydana geldi", hata.Message);
            }

            string sorgu = "DELETE FROM SoruEklee WHERE Soru=@Soru";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@Soru", Convert.ToString(lbl_soru.Text));
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string sorgu = "DELETE FROM SoruEklee WHERE Soru=@Soru";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@Soru", Convert.ToString(lbl_soru.Text));
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Soru silindi");
        }

        private void AdminGirisi_Load(object sender, EventArgs e)
        {
            baglanti = new SqlConnection("Data Source=DESKTOP-HVTB9LK;Integrated Security=SSPI;Initial Catalog=YazilimYapimi");
            baglanti.Open();
            da = new SqlDataAdapter("SELECT *FROM SoruEklee", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            guna2DataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            lbl_soru.Text = guna2DataGridView1.CurrentRow.Cells[0].Value.ToString();
            lbl_a.Text = guna2DataGridView1.CurrentRow.Cells[1].Value.ToString();
            lbl_b.Text = guna2DataGridView1.CurrentRow.Cells[2].Value.ToString();
            lbl_c.Text = guna2DataGridView1.CurrentRow.Cells[3].Value.ToString();
            lbl_d.Text = guna2DataGridView1.CurrentRow.Cells[4].Value.ToString();
            lbl_dgr.Text = guna2DataGridView1.CurrentRow.Cells[5].Value.ToString();
        }
    }
}
