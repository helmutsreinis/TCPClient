
namespace TCPServer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tb_Server = new System.Windows.Forms.TextBox();
            this.tb_ReceivedMessages = new System.Windows.Forms.TextBox();
            this.tb_SendMsg = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_SendMsg = new System.Windows.Forms.Button();
            this.btn_StartServ = new System.Windows.Forms.Button();
            this.lb_Clients = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server:";
            // 
            // tb_Server
            // 
            this.tb_Server.Location = new System.Drawing.Point(74, 6);
            this.tb_Server.Name = "tb_Server";
            this.tb_Server.Size = new System.Drawing.Size(393, 23);
            this.tb_Server.TabIndex = 1;
            this.tb_Server.Text = "127.0.0.1:9000";
            // 
            // tb_ReceivedMessages
            // 
            this.tb_ReceivedMessages.Location = new System.Drawing.Point(74, 35);
            this.tb_ReceivedMessages.Multiline = true;
            this.tb_ReceivedMessages.Name = "tb_ReceivedMessages";
            this.tb_ReceivedMessages.ReadOnly = true;
            this.tb_ReceivedMessages.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tb_ReceivedMessages.Size = new System.Drawing.Size(393, 381);
            this.tb_ReceivedMessages.TabIndex = 3;
            // 
            // tb_SendMsg
            // 
            this.tb_SendMsg.Location = new System.Drawing.Point(74, 422);
            this.tb_SendMsg.Name = "tb_SendMsg";
            this.tb_SendMsg.Size = new System.Drawing.Size(393, 23);
            this.tb_SendMsg.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 426);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Message:";
            // 
            // btn_SendMsg
            // 
            this.btn_SendMsg.Location = new System.Drawing.Point(311, 451);
            this.btn_SendMsg.Name = "btn_SendMsg";
            this.btn_SendMsg.Size = new System.Drawing.Size(75, 23);
            this.btn_SendMsg.TabIndex = 6;
            this.btn_SendMsg.Text = "Send";
            this.btn_SendMsg.UseVisualStyleBackColor = true;
            this.btn_SendMsg.Click += new System.EventHandler(this.btn_SendMsg_Click);
            // 
            // btn_StartServ
            // 
            this.btn_StartServ.Location = new System.Drawing.Point(392, 451);
            this.btn_StartServ.Name = "btn_StartServ";
            this.btn_StartServ.Size = new System.Drawing.Size(75, 23);
            this.btn_StartServ.TabIndex = 7;
            this.btn_StartServ.Text = "Start";
            this.btn_StartServ.UseVisualStyleBackColor = true;
            this.btn_StartServ.Click += new System.EventHandler(this.btn_StartServ_Click);
            // 
            // lb_Clients
            // 
            this.lb_Clients.DisplayMember = "Username";
            this.lb_Clients.FormattingEnabled = true;
            this.lb_Clients.ItemHeight = 15;
            this.lb_Clients.Location = new System.Drawing.Point(473, 35);
            this.lb_Clients.Name = "lb_Clients";
            this.lb_Clients.Size = new System.Drawing.Size(291, 439);
            this.lb_Clients.TabIndex = 8;
            this.lb_Clients.ValueMember = "IP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(473, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Client IP:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 508);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lb_Clients);
            this.Controls.Add(this.btn_StartServ);
            this.Controls.Add(this.btn_SendMsg);
            this.Controls.Add(this.tb_SendMsg);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_ReceivedMessages);
            this.Controls.Add(this.tb_Server);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TCP/IP Server";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_Server;
        private System.Windows.Forms.TextBox tb_ReceivedMessages;
        private System.Windows.Forms.TextBox tb_SendMsg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_SendMsg;
        private System.Windows.Forms.Button btn_StartServ;
        private System.Windows.Forms.ListBox lb_Clients;
        private System.Windows.Forms.Label label3;
    }
}

