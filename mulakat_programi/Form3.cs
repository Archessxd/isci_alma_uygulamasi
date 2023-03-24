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
    public partial class Form3 : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=isci_data.accdb");
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try 
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("SELECT uname,pass FROM Admins WHERE uname=@name and pass = @pas ",baglanti);
                komut.Parameters.AddWithValue("@name", textBox1.Text);
                komut.Parameters.AddWithValue("@pass",textBox2.Text);
                OleDbDataReader dr;
                dr = komut.ExecuteReader();
                if (dr.Read()) 
                { 
                    Form2 f2 = new Form2();
                    f2.Show();
                }
                else
                {
                    MessageBox.Show("hatalı giriş");
                }
                baglanti.Close();
            } 
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                baglanti.Close();
            }

        }
    }
}
