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

namespace Otomasyon
{
    public partial class SekreterGiris : Form
    {
        public SekreterGiris()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl = new sqlbaglanti();
        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand komut1 = new SqlCommand("Select * From Tbl_Sekreter where SekreterTC=@p1 and SekreterSifre=@p2", bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1", MskTC.Text);
            komut1.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader dr = komut1.ExecuteReader();
            if (dr.Read()) 
            {
                FrmSekreterDetay frs = new FrmSekreterDetay();
                frs.tc = MskTC.Text;
                frs.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("TC veya Şifre Yanlış", "Bilgilendirme", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                MskTC.Clear();
                TxtSifre.Clear();
                MskTC.Focus();
            }
            bgl.baglanti().Close();
        }
    }
}
