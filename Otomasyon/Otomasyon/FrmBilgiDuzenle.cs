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
    public partial class FrmBilgiDuzenle : Form
    {
        public FrmBilgiDuzenle()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl = new sqlbaglanti();
        public string TCno;
        private void FrmBilgiDuzenle_Load(object sender, EventArgs e)
        {
            MskTc.Text = TCno;
        }
        FrmHastaDetay fr = new FrmHastaDetay();
        private void BtnTm_Click(object sender, EventArgs e)
        {
            SqlCommand komut1 = new SqlCommand("update Tbl_Hastalar set HastaTelefon=@p1,HastaSifre=@p2 where HastaTC=@p3", bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1", MskTelefon.Text);
            komut1.Parameters.AddWithValue("@p2", textBox1.Text);
            komut1.Parameters.AddWithValue("@p3", MskTc.Text);
            komut1 .ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bilgileriniz güncellendi.");
        }
    }
}
