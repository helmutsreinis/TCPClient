using SimpleTcp;
using System;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace TCPServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SimpleTcpServer server;
        BackgroundWorker UnauthorizedUsers = new BackgroundWorker();

        private void btn_StartServ_Click(object sender, EventArgs e)
        {
            server.Start();
            tb_ReceivedMessages.Text += $"Started Server...{Environment.NewLine}";
            btn_StartServ.Enabled = false;
            btn_StopServer.Enabled = true;
            btn_SendMsg.Enabled = true;
        }

        private void UnauthorizedUsers_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                Thread.Sleep(10000);
                for (int i = 0; i < lb_Clients.Items.Count; i++)
                {
                    ConnectedUser loopinguser = (ConnectedUser)lb_Clients.Items[i];
                    if (loopinguser.Username == "Unauthorized")
                    {
                        this.BeginInvoke(new Action(delegate ()
                        {
                            lb_Clients.Items.RemoveAt(i);
                        }));
                        server.DisconnectClient(loopinguser.IP);
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btn_SendMsg.Enabled = false;
            server = new SimpleTcpServer(tb_Server.Text);
            server.Events.ClientConnected += Events_ClientConnected;
            server.Events.ClientDisconnected += Events_ClientDisconnected;
            server.Events.DataReceived += Events_DataReceived;

            UnauthorizedUsers.DoWork += UnauthorizedUsers_DoWork;
            UnauthorizedUsers.RunWorkerAsync();
        }

        private void Events_DataReceived(object sender, DataReceivedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                tb_ReceivedMessages.Text += $"{e.IpPort}: {Encoding.UTF8.GetString(e.Data)}{Environment.NewLine}";
                string Data = Encoding.UTF8.GetString(e.Data);
                if (Data.StartsWith("/login "))
                {
                    string[] username = Data.Replace("/login ", "").Split(":");
                    if (username[0].Length == 0 || username[1].Length == 0 || username[0].Contains(" ") || username[1].Contains(" "))
                    {
                        server.Send(e.IpPort, "Verification Failed...");
                        server.DisconnectClient(e.IpPort);
                    }
                    ConnectedUser connectedUser = new ConnectedUser();
                    connectedUser.IP = e.IpPort;
                    connectedUser.Username = "Unauthorized";

                    for (int i = 0; i < lb_Clients.Items.Count; i++)
                    {
                        ConnectedUser loopinguser = (ConnectedUser)lb_Clients.Items[i];
                        if (loopinguser.IP == connectedUser.IP && loopinguser.Username == "Unauthorized")
                        {
                            lb_Clients.Items.RemoveAt(i);
                            connectedUser.Username = username[0];
                            lb_Clients.Items.Add(connectedUser);
                        }
                    }
                }
            });  
        }

         

        private void Events_ClientDisconnected(object sender, ClientDisconnectedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                tb_ReceivedMessages.Text += $"{e.IpPort} disconnected {Environment.NewLine}";
                ConnectedUser connectedUser = new ConnectedUser();
                connectedUser.IP = e.IpPort;
                for (int i = 0; i < lb_Clients.Items.Count; i++)
                {
                    ConnectedUser loopinguser = (ConnectedUser)lb_Clients.Items[i];
                    if (loopinguser.IP == connectedUser.IP)
                    {
                        lb_Clients.Items.RemoveAt(i);
                    }
                }
            });
            
        }

        private void Events_ClientConnected(object sender, ClientConnectedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                tb_ReceivedMessages.Text += $"{e.IpPort} connected {Environment.NewLine}";
                ConnectedUser connectedUser = new ConnectedUser();
                connectedUser.IP = e.IpPort;
                connectedUser.Username = "Unauthorized";
                lb_Clients.Items.Add(connectedUser);
            });
            
        }

        private void btn_SendMsg_Click(object sender, EventArgs e)
        {
            if (server.IsListening)
            {
                if (!string.IsNullOrEmpty(tb_SendMsg.Text)&&lb_Clients.SelectedItem != null)
                {
                    ConnectedUser connectedUser = (ConnectedUser)lb_Clients.SelectedItem;
                    server.Send(connectedUser.IP, tb_SendMsg.Text);
                    tb_ReceivedMessages.Text += $"Server: {tb_SendMsg.Text}{Environment.NewLine}";
                    tb_SendMsg.Text = string.Empty;
                }
            }
        }

        private void btn_StopServer_Click(object sender, EventArgs e)
        {
            server.Stop();
            server.Dispose();
            tb_ReceivedMessages.Text += $"Stopping...{Environment.NewLine}";
            btn_StartServ.Enabled = true;
            btn_StopServer.Enabled = false;
            btn_SendMsg.Enabled = false;
            btn_SendAll.Enabled = false;
        }

        private void btn_SendAll_Click(object sender, EventArgs e)
        {
            if (server.IsListening)
            {
                if (!string.IsNullOrEmpty(tb_SendMsg.Text) && lb_Clients.Items.Count != 0)
                {
                    for (int i = 0; i < lb_Clients.Items.Count; i++)
                    {
                        ConnectedUser loopinguser = (ConnectedUser)lb_Clients.Items[i];
                        server.Send(loopinguser.IP, tb_SendMsg.Text);
                    }
                    tb_ReceivedMessages.Text += $"Server: {tb_SendMsg.Text}{Environment.NewLine}";
                    tb_SendMsg.Text = string.Empty;
                }
            }
        }
    }

    public class ConnectedUser
    {
        public string IP { get; set; }
        public string Username { get; set; }
    }
}
