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
    public partial class Form2 : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=isci_data.accdb");
        DataTable tablo = new DataTable();
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try 
            { 
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("DELETE * FROM Basvurular WHERE id=@id",baglanti);
                komut.Parameters.AddWithValue("@id", textBox1.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                GridGuncelle();
                MessageBox.Show("kayıt başarıyla silindi");
                textBox1.Text = null;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                baglanti.Close();
            }
        }
        void GridGuncelle()
        {
            baglanti.Open();
            tablo.Clear();
            OleDbDataAdapter uyarlayici = new OleDbDataAdapter("SELECT * FROM Basvurular",baglanti);
            uyarlayici.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            GridGuncelle();
        }
    }
}
