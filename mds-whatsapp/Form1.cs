using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox.Text != "")
            {
                RichTextBox message = new RichTextBox();
                message.Text = this.textBox.Text;
                //message.Text = this.textBox.Text;
                int yPos = messageList.Count() > 0 ? messageList[messageList.Count() - 1].Location.Y + messageList[messageList.Count() - 1].Size.Height + 5 : 12;
                message.Location = new System.Drawing.Point(350 - TextRenderer.MeasureText(message.Text, message.Font).Width, yPos);
                message.Name = $"richTextBox{messageList.Count()}";
                message.Size = new System.Drawing.Size(TextRenderer.MeasureText(message.Text, message.Font).Width, 28);
                message.TabIndex = 2;
                message.ReadOnly = true;
                messageList.Add(message);
                panel1.Controls.Add(message);
                this.textBox.Text = "";
            }
        }

        private void empty_convo(object sender, EventArgs e)
        {
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
            textBox.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
