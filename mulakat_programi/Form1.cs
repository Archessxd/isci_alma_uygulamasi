using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace mulakat_programi
{
    public partial class Form1 : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=isci_data.accdb");

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try { 
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("INSERT INTO Basvurular(isim,soyisim,ulke,Github_ismi) VALUES(@isim,@soyisim,@ulke,@github)",baglanti);
            komut.Parameters.AddWithValue("@isim", textBox1.Text);
            komut.Parameters.AddWithValue("@soyisim", textBox2.Text);
            komut.Parameters.AddWithValue("@ulke", textBox3.Text);
            komut.Parameters.AddWithValue("@github", textBox4.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            


            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
                baglanti.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f2 = new Form3();
            f2.Show();
        }
    }
}
