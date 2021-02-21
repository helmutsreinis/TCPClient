using SimpleTcp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCPClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SimpleTcpClient client;
        private void btn_Connect_Click(object sender, EventArgs e)
        {
            try
            {
                client.Connect();
                btn_SendMsg.Enabled = true;
                btn_Connect.Enabled = false;
                btn_Disconnect.Enabled = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,"Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_SendMsg_Click(object sender, EventArgs e)
        {
            if (client.IsConnected)
            {
                if (!string.IsNullOrEmpty(tb_SendMsg.Text))
                {
                    client.Send(tb_SendMsg.Text);
                    tb_ReceivedMessages.Text += $"Me: {tb_SendMsg.Text}{Environment.NewLine}";
                    tb_SendMsg.Text = string.Empty;

                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new(tb_Server.Text);
            client.Events.Connected += Events_Connected;
            client.Events.Disconnected += Events_Disconnected;
            client.Events.DataReceived += Events_DataReceived;
            btn_SendMsg.Enabled = false;
        }


        private void Events_DataReceived(object sender, DataReceivedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                tb_ReceivedMessages.Text += $"Server: {Encoding.UTF8.GetString(e.Data)}{Environment.NewLine}";
            });
        }

        private void Events_Disconnected(object sender, ClientDisconnectedEventArgs e)
        {
            
            this.Invoke((MethodInvoker)delegate
            {
                tb_ReceivedMessages.Text += $"Server Disconnected. {Environment.NewLine}";
                btn_Connect.Enabled = true;
                btn_Disconnect.Enabled = false;
                client.Disconnect();
                client.Dispose();
            });
        }

        private void Events_Connected(object sender, ClientConnectedEventArgs e)
        {
            
            this.Invoke((MethodInvoker)delegate
            {
                tb_ReceivedMessages.Text += $"Server connected. {Environment.NewLine}";
                tb_ReceivedMessages.Text += $"Verifying Credentials... {Environment.NewLine}";
                client.Send($"/login {tb_UserName.Text}:{tb_Password.Text}");
            });
        }

        private void btn_Disconnect_Click(object sender, EventArgs e)
        {
            try
            {
                client.Disconnect();
                client.Dispose();
                btn_SendMsg.Enabled = false;
                btn_Connect.Enabled = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
