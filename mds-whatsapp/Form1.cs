using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mds_whatsapp
{
    
    public partial class Form1 : Form
    {
        public static bool pornit = false;
        public string var, var1;
        public static string nume;
        SqlConnection c = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\OneDrive\Documente\GitHub\mds-whatsapp\mds-whatsapp\Database1.mdf;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"");

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {


                if (this.textBox.Text != "" && textBox.Text.Length < 50)
                {
                    c.Open();
                    string insert = "insert into mesaje (Sender,Receiver,Mesaj,Time) values (@a,@b,@c,@d)";
                    SqlCommand cmd = new SqlCommand(insert, c);
                    cmd.Parameters.AddWithValue("a", nume);
                    cmd.Parameters.AddWithValue("b", comboBox1.Text);
                    cmd.Parameters.AddWithValue("c", textBox.Text);
                    cmd.Parameters.AddWithValue("d", DateTime.Now);
                    cmd.ExecuteNonQuery();
                    c.Close();
                    RichTextBox message = new RichTextBox();
                    message.Text = nume + ": "+ this.textBox.Text;
                    int yPos = messageList.Count() > 0 ? messageList[messageList.Count() - 1].Location.Y + messageList[messageList.Count() - 1].Size.Height + 5 : 12;
                    message.Location = new System.Drawing.Point(350 - TextRenderer.MeasureText(message.Text, message.Font).Width, yPos);
                    message.Name = $"richTextBox{messageList.Count()}";
                    message.Size = new System.Drawing.Size(TextRenderer.MeasureText(message.Text, message.Font).Width, 28);
                    message.TabIndex = 2;
                    message.ReadOnly = true;
                 
                    messageList.Add(message);
                    panel1.Controls.Add(message);
                    this.textBox.Text = "";
                    //messageTableAdapter.Insert(message.Text, "", 0);
                    

                }
            }else
            {
                MessageBox.Show("Alege un destinatar!");
            }

            
        }

        private void empty_convo(object sender, EventArgs e)
        {
            var1 = "";
            ControlCollection temp = new ControlCollection(this);
            for (int i = 0; i < panel1.Controls.Count; i++)
            {
                if (messageList.Contains(panel1.Controls[i]))
                {
                    panel1.Controls.Remove(panel1.Controls[i]);
                    i--;
                }
            }
            messageList = new List<RichTextBox>();
           
        }
        void uploadcombo()
        {
            c.Open();
            string select = @"select username from logare";
            SqlCommand cmd = new SqlCommand(select, c);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                comboBox1.Items.Add(r[0].ToString());
            }
            c.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            uploadcombo();
            label2.Text = "Utilizator:" + nume;
            
            // TODO: This line of code loads data into the '_mds_whatsappDataSet.Message' table. You can move, or remove it, as needed.
           // this.messageTableAdapter.Fill(this._mds_whatsappDataSet.MESSAGES);
            //this.userTableAdapter.Fill(this._mds_whatsappDataSet.USERS);
        }

        private void messageBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.messageBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this._mds_whatsappDataSet);

        }

        void timerload(object sender, EventArgs e)
        {
            int i = 0;
      
            c.Open();
            string select1 = @"select Mesaj,Sender,Receiver from mesaje where (Sender = @a and Receiver = @b) or (Sender = @b and Receiver = @a)";
            SqlCommand cmd1 = new SqlCommand(select1, c);
            cmd1.Parameters.AddWithValue("a", nume);
            cmd1.Parameters.AddWithValue("b", comboBox1.Text);
            SqlDataReader r1 = cmd1.ExecuteReader();
            while (r1.Read())
            {
                var = r1[1].ToString() +": "+ r1[0].ToString();
            }
            c.Close();

            if (var != var1)
            {
                empty_convo(sender, e);
                c.Open();
                string select = @"select Mesaj,Sender,Receiver from mesaje where (Sender = @a and Receiver = @b) or (Sender = @b and Receiver = @a) order by Id_mesaj DESC";
                SqlCommand cmd = new SqlCommand(select, c);
                cmd.Parameters.AddWithValue("a", nume);
                cmd.Parameters.AddWithValue("b", comboBox1.Text);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read() && i < 9)
                {

                    i++;
                    RichTextBox message = new RichTextBox();
                    message.Text = r[1].ToString() + ": " + r[0].ToString();
                    int yPos = messageList.Count() > 0 ? messageList[messageList.Count() - 1].Location.Y + messageList[messageList.Count() - 1].Size.Height + 5 : 12;
                    message.Location = new System.Drawing.Point(350 - TextRenderer.MeasureText(message.Text, message.Font).Width, yPos);
                    message.Name = $"richTextBox{messageList.Count()}";
                    message.Size = new System.Drawing.Size(TextRenderer.MeasureText(message.Text, message.Font).Width, 28);
                    message.TabIndex = 2;
                    message.ReadOnly = true;
                    message.SelectionColor = Color.LightBlue;
                    messageList.Add(message);
                    panel1.Controls.Add(message);
                    /*RichTextBox message = new RichTextBox();
                    message.Text = r[1].ToString() + ": " + r[0].ToString();
                    int yPos = messageList.Count() > 0 ? messageList[messageList.Count() - 1].Location.Y + messageList[messageList.Count() - 1].Size.Height + 5 : 12;
                    message.Location = new System.Drawing.Point(350 - TextRenderer.MeasureText(message.Text, message.Font).Width, yPos);
                    message.Name = $"richTextBox{messageList.Count()}";
                    message.Size = new System.Drawing.Size(TextRenderer.MeasureText(message.Text, message.Font).Width, 28);
                    message.TabIndex = 2;
                    message.ReadOnly = true;
                    message.SelectionColor = Color.LightBlue;
                    messageList.Add(message);
                    panel1.Controls.Add(message);*/
                }

                c.Close();
                var1 = var;
            }
            /*
            ControlCollection temp = new ControlCollection(this);
            for (int j = 0; j < panel1.Controls.Count; j++)
            {
                if (messageList.Contains(panel1.Controls[j]))
                {
                    panel1.Controls.Remove(panel1.Controls[j]);
                    j--;
                }
            }
            messageList = new List<RichTextBox>();*/
        }
        private void load_conversation(object sender, EventArgs e)
        {
            timer1.Stop();
            pornit = false;
            button4.BackColor = Color.Red;
            /*foreach (DataRow row in messageTableAdapter.GetData().Rows)
            {
                RichTextBox message = new RichTextBox();
                message.Text = row.ItemArray[0].ToString();
                int yPos = messageList.Count() > 0 ? messageList[messageList.Count() - 1].Location.Y + messageList[messageList.Count() - 1].Size.Height + 5 : 12;
                message.Location = new System.Drawing.Point(350 - TextRenderer.MeasureText(message.Text, message.Font).Width, yPos);
                message.Name = $"richTextBox{messageList.Count()}";
                message.Size = new System.Drawing.Size(TextRenderer.MeasureText(message.Text, message.Font).Width, 28);
                message.TabIndex = 2;
                message.ReadOnly = true;
                messageList.Add(message);
                panel1.Controls.Add(message);
                this.textBox.Text = "";
            }*/
            empty_convo(sender, e);

            if (comboBox1.Text != "")
            {
                c.Open();
                string select = @"select Mesaj,Sender,Receiver from mesaje where (Sender = @a and Receiver = @b) or (Sender = @b and Receiver = @a)";
                SqlCommand cmd = new SqlCommand(select, c);
                cmd.Parameters.AddWithValue("a", nume);
                cmd.Parameters.AddWithValue("b", comboBox1.Text);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    RichTextBox message = new RichTextBox();
                    message.Text = r[1].ToString() + ": " + r[0].ToString();
                    int yPos = messageList.Count() > 0 ? messageList[messageList.Count() - 1].Location.Y + messageList[messageList.Count() - 1].Size.Height + 5 : 12;
                    message.Location = new System.Drawing.Point(350 - TextRenderer.MeasureText(message.Text, message.Font).Width, yPos);
                    message.Name = $"richTextBox{messageList.Count()}";
                    message.Size = new System.Drawing.Size(TextRenderer.MeasureText(message.Text, message.Font).Width, 28);
                    message.TabIndex = 2;
                    message.ReadOnly = true;
                    message.SelectionColor = Color.LightBlue;
                    messageList.Add(message);
                    panel1.Controls.Add(message);
                }
                c.Close();
                
            }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.Red;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.White;
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (pornit == false)
            {
                timer1.Start();
                pornit = true;
                button4.BackColor = Color.Green;
            }

            else
            {
                timer1.Stop();
                pornit = false;
                button4.BackColor = Color.Red;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(pornit == true && comboBox1.Text != "")
            {

                timerload(sender, e);
            }
        }
    }
}
