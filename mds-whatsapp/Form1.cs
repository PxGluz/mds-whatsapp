using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace mds_whatsapp
{


    public partial class Form1 : Form
    {
        string key = "b14ca5898a4e4133bbce2ea2315a1916";
        public static bool pornit = true;
        public string var, var1;
        public static string nume;
        SqlConnection c = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\source\repos\mds-whatsapp\mds-whatsapp\Database1.mdf;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (label3.Text != "")
            {
                if (this.textBox.Text != "" && textBox.Text.Length < 50)
                {
                    c.Open();
                    string insert = "insert into mesaje (Sender,Receiver,Mesaj,Time) values (@a,@b,@c,@d)";
                    SqlCommand cmd = new SqlCommand(insert, c);
                    cmd.Parameters.AddWithValue("a", nume);
                    cmd.Parameters.AddWithValue("b", label3.Text);
                    cmd.Parameters.AddWithValue("c", Encrypter.EncryptString(key, textBox.Text));
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
                    if (panel1.Controls.Count > 0)
                        panel1.ScrollControlIntoView(messageList[messageList.Count() - 1]);
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

            int buttonSize = 40;
            while (r.Read())
            {
                Button button = new Button();
                panel2.Controls.Add(button);
                button.Location = new System.Drawing.Point(0, conversationList.Count() == 0 ? 0 : conversationList.Count * buttonSize);
                button.Name = $"button{conversationList.Count()}";
                button.Size = new System.Drawing.Size(114, buttonSize);
                button.TabIndex = 7;
                button.Text = r[0].ToString();
                button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                button.UseVisualStyleBackColor = true;
                button.Click += new EventHandler(button5_Click);
                conversationList.Add(button);
            }
            
            c.Close();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            uploadcombo();
            label2.Text = "Logged in as:" + nume;
            timer1.Start();
        }

        void timerload(object sender, EventArgs e)
        {

            c.Open();
            string select1 = @"select Mesaj,Sender,Receiver from mesaje where (Sender = @a and Receiver = @b) or (Sender = @b and Receiver = @a)";
            SqlCommand cmd1 = new SqlCommand(select1, c);
            cmd1.Parameters.AddWithValue("a", nume);
            cmd1.Parameters.AddWithValue("b", label3.Text);
            SqlDataReader r1 = cmd1.ExecuteReader();
            while (r1.Read())
            {
                var = r1[1].ToString() + ": " + r1[0].ToString();
            }
            c.Close();

            if (var != var1)
            {
                empty_convo(sender, e);
                c.Open();
                string select = @"select Mesaj,Sender,Receiver from mesaje where (Sender = @a and Receiver = @b) or (Sender = @b and Receiver = @a)";
                SqlCommand cmd = new SqlCommand(select, c);
                cmd.Parameters.AddWithValue("a", nume);
                cmd.Parameters.AddWithValue("b", label3.Text);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    RichTextBox message = new RichTextBox();
                    message.Text = r[1].ToString() + ": " + Encrypter.DecryptString(key, r[0].ToString());
                    int yPos = messageList.Count() > 0 ? messageList[messageList.Count() - 1].Location.Y + messageList[messageList.Count() - 1].Size.Height + 5 : 12;
                    message.Location = new System.Drawing.Point(r[1].ToString() == nume ? 350 - TextRenderer.MeasureText(message.Text, message.Font).Width : 0, yPos);
                    message.Name = $"richTextBox{messageList.Count()}";
                    message.Size = new System.Drawing.Size(TextRenderer.MeasureText(message.Text, message.Font).Width, 28);
                    message.TabIndex = 2;
                    message.ReadOnly = true;
                    message.SelectionColor = Color.LightBlue;
                    messageList.Add(message);
                    panel1.Controls.Add(message);
                }

                c.Close();
                var1 = var;
                if (panel1.Controls.Count > 0)
                    panel1.ScrollControlIntoView(messageList[messageList.Count() - 1]);
            }
        }

        private void load_conversation(object sender, EventArgs e)
        {
            empty_convo(sender, e);

            if (label3.Text != "")
            {
                c.Open();
                string select = @"select Mesaj,Sender,Receiver from mesaje where (Sender = @a and Receiver = @b) or (Sender = @b and Receiver = @a)";
                SqlCommand cmd = new SqlCommand(select, c);
                cmd.Parameters.AddWithValue("a", nume);
                cmd.Parameters.AddWithValue("b", label3.Text);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    RichTextBox message = new RichTextBox();
                    message.Text = r[1].ToString() + ": " + Encrypter.DecryptString(key, r[0].ToString());
                    int yPos = messageList.Count() > 0 ? messageList[messageList.Count() - 1].Location.Y + messageList[messageList.Count() - 1].Size.Height + 5 : 12;
                    message.Location = new System.Drawing.Point(r[1].ToString() == nume ? 350 - TextRenderer.MeasureText(message.Text, message.Font).Width : 0, yPos);
                    message.Name = $"richTextBox{messageList.Count()}";
                    message.Size = new System.Drawing.Size(TextRenderer.MeasureText(message.Text, message.Font).Width, 28);
                    message.TabIndex = 2;
                    message.ReadOnly = true;
                    message.SelectionColor = Color.LightBlue;
                    messageList.Add(message);
                    panel1.Controls.Add(message);
                }
                c.Close();
                if (panel1.Controls.Count > 0)
                    panel1.ScrollControlIntoView(messageList[messageList.Count() - 1]);
            }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.Green;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.White;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Text != label3.Text)
                label3.Text = button.Text;
            else
                label3.Text = "";
            load_conversation(sender, e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pornit == true && label3.Text != "")
                timerload(sender, e);
        }
    }
}
