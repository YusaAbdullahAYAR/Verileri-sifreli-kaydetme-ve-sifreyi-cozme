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

namespace Şifreli_Veriler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-RBCL1FM\SQLEXPRESS;Initial Catalog=KullaniciSifre;Integrated Security=True");

        void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from TBLVERILER",baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            string ad = TxtAd.Text;
            byte[] addizi =ASCIIEncoding.ASCII.GetBytes(ad);
            string adsifre = Convert.ToBase64String(addizi);

            string soyad = TxtSoyad.Text;
            byte[] soyaddizi = ASCIIEncoding.ASCII.GetBytes(soyad);
            string soyadsifre = Convert.ToBase64String(soyaddizi);

            string mail = TxtMail.Text;
            byte[] maildizi = ASCIIEncoding.ASCII.GetBytes(mail);
            string mailsifre = Convert.ToBase64String(maildizi);

            string sifre = TxtSifre.Text;
            byte[] sifredizi = ASCIIEncoding.ASCII.GetBytes(sifre);
            string sifresifre = Convert.ToBase64String(sifredizi);

            string hesapno = TxtHesapNo.Text;
            byte[] hesapnodizi = ASCIIEncoding.ASCII.GetBytes(hesapno);
            string hesapnosifre = Convert.ToBase64String(hesapnodizi);

            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLVERILER (AD,SOYAD,MAIL,SIFRE,HESAPNO) VALUES (@P1,@P2,@P3,@P4,@P5)",baglanti);
            komut.Parameters.AddWithValue("@P1", adsifre);
            komut.Parameters.AddWithValue("@P2", soyadsifre);
            komut.Parameters.AddWithValue("@P3", mailsifre);
            komut.Parameters.AddWithValue("@P4", sifresifre);
            komut.Parameters.AddWithValue("@P5", hesapnosifre);
            komut.ExecuteNonQuery();

            baglanti.Close();
            MessageBox.Show("Veriler Eklendi");




        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string adcozum = TxtAd.Text;
            byte[] adcozumdizi = Convert.FromBase64String(adcozum);
            string adverisi = ASCIIEncoding.ASCII.GetString(adcozumdizi);
            label6.Text = adverisi;

            string soyadcozum = TxtSoyad.Text;
            byte[] soyadcozumdizi = Convert.FromBase64String(soyadcozum);
            string soyadverisi = ASCIIEncoding.ASCII.GetString(soyadcozumdizi);
            label7.Text = soyadverisi;

            string mailcozum = TxtMail.Text;
            byte[] cozumdizi = Convert.FromBase64String(mailcozum);
            string mailverisi = ASCIIEncoding.ASCII.GetString(cozumdizi);
            label8.Text = mailverisi;

            string sifrecozum = TxtSifre.Text;
            byte[] sifredizi = Convert.FromBase64String(sifrecozum);
            string sifreverisi = ASCIIEncoding.ASCII.GetString(sifredizi);
            label9.Text = sifreverisi;

            string hesapnocozum = TxtHesapNo.Text;
            byte[] hesapnodizi = Convert.FromBase64String(hesapnocozum);
            string hesapnoverisi = ASCIIEncoding.ASCII.GetString(hesapnodizi);
            label10.Text = hesapnoverisi;




        }
    }
}
