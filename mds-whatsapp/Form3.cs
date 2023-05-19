using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mds_whatsapp
{
    public partial class Form3 : Form
    {
        SqlConnection c = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\OneDrive\Documente\GitHub\mds-whatsapp\mds-whatsapp\Database1.mdf;Integrated Security=True");
        public Form3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
        public bool verificare()
        {
            c.Open();
            string select = @"select username from Logare where username = @a";
            SqlCommand cmd = new SqlCommand(select, c);
            cmd.Parameters.AddWithValue("a", textBox6.Text);
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                c.Close();
                return false;
            }
            c.Close();
            return true;
            //c.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (verificare())
            {
               
                try
                {
                    if (checkBox2.Checked == true)
                    {
                        c.Open();
                        string insert = "insert into logare (username, password) values (@a,@b)";
                        SqlCommand cmd = new SqlCommand(insert, c);
                        cmd.Parameters.AddWithValue("a", textBox6.Text);
                        cmd.Parameters.AddWithValue("b", textBox4.Text);
                        cmd.ExecuteNonQuery();
                        c.Close();
                        MessageBox.Show("Inregistrare realizata cu succes!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Trebuie sa accepti termenii si conditile!!");
                    }
                }
                catch
                {
                    MessageBox.Show("A aparut o eroare neprevazuta! Incearca din nou!");
                    c.Close();
                }
            }else
            {
                MessageBox.Show("Utilizatorul este inregistrat deja!");
            }
        }
    }
}
