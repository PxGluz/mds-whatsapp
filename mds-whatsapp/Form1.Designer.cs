using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace mds_whatsapp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.messageBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._mds_whatsappDataSet = new mds_whatsapp._mds_whatsappDataSet();
            this.messageTableAdapter = new mds_whatsapp._mds_whatsappDataSetTableAdapters.MESSAGESTableAdapter();
            this.userTableAdapter = new mds_whatsapp._mds_whatsappDataSetTableAdapters.USERSTableAdapter();
            this.tableAdapterManager = new mds_whatsapp._mds_whatsappDataSetTableAdapters.TableAdapterManager();
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(437, 365);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            this.button1.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(132, 373);
            this.textBox.MaxLength = 50;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(299, 20);
            this.textBox.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(132, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(385, 331);
            this.panel1.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Location = new System.Drawing.Point(12, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(114, 365);
            this.panel2.TabIndex = 3;
            // 
            // messageBindingSource
            // 
            this.messageBindingSource.DataSource = this._mds_whatsappDataSet;
            this.messageBindingSource.Position = 0;
            // 
            // _mds_whatsappDataSet
            // 
            this._mds_whatsappDataSet.DataSetName = "_mds_whatsappDataSet";
            this._mds_whatsappDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // messageTableAdapter
            // 
            this.messageTableAdapter.ClearBeforeFill = true;
            // 
            // userTableAdapter
            // 
            this.userTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.MESSAGESTableAdapter = this.messageTableAdapter;
            this.tableAdapterManager.UpdateOrder = mds_whatsapp._mds_whatsappDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.USERSTableAdapter = this.userTableAdapter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Destinatar:";
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(292, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 8;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 405);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Whatsapp";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox;
        private List<System.Windows.Forms.RichTextBox> messageList = new List<System.Windows.Forms.RichTextBox>();
        private Panel panel1;
        private ContextMenuStrip contextMenuStrip1;
        private Panel panel2;
        private _mds_whatsappDataSet _mds_whatsappDataSet;
        private BindingSource messageBindingSource;
        private _mds_whatsappDataSetTableAdapters.MESSAGESTableAdapter messageTableAdapter;
        private _mds_whatsappDataSetTableAdapters.USERSTableAdapter userTableAdapter;
        private _mds_whatsappDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private Label label2;
        private List<Button> conversationList = new List<Button>();
        private ContextMenuStrip contextMenuStrip2;
        private Label label3;
        private Timer timer1;
    }
}

