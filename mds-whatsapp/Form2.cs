using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace mds_whatsapp
{
    public partial class Form2 : Form
    {
        SqlConnection c = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\source\repos\mds-whatsapp\mds-whatsapp\Database1.mdf;Integrated Security=True");
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter the username,please");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Enter the password, please");
            }
            else
            {
                c.Open();
                string select = "select username, password from Logare where username = @a and password = @b";
                SqlCommand cmd = new SqlCommand(select, c);
                cmd.Parameters.AddWithValue("a", textBox1.Text);
                cmd.Parameters.AddWithValue("b", textBox2.Text);
                SqlDataReader r = cmd.ExecuteReader();
                if(r.Read())
                {
                    Form1.nume = r[0].ToString();
                    MessageBox.Show("Logare efectuata cu succes!");
                    Form1 f = new Form1();
                    f.Show();
                    textBox1.Hide();
                    textBox2.Hide();
                    button1.Hide();
                    button2.Hide();
                    label1.Text = "Bune ai revenit, " + Form1.nume + "!";
                    label2.Hide();
                    label3.Hide();
                }else
                {
                    MessageBox.Show("Utilizatorul nu exista in baza de date!");
                }
                c.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Show();
            
        }
    }
}
