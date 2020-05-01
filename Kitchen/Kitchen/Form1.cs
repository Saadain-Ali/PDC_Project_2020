using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kitchen
{
    public partial class Form1 : Form
    {
        bool isServerUp = false;
        public Form1()
        {
            
            InitializeComponent();
            TcpListener listner = new TcpListener(new IPEndPoint(IPAddress.Loopback, 11001));
            listner.Start();
            listner.BeginAcceptTcpClient(new AsyncCallback(ConnectListner), listner);

            client = new TcpClient();
            try
            {
                client.Connect(IPAddress.Loopback, 11000);
                NetworkStream ns = client.GetStream();
                button1.Enabled = false;
                ns.BeginRead(msg, 0, msg.Length, new AsyncCallback(StartReadOrder), ns);
                isServerUp = true;
            }
            catch (Exception e)
            {
                if (e.Message.Contains("No connection could be made because the target machine actively refused it 127.0.0.1:11000"))
                {
                    MessageBox.Show("Please run Order Screen first");
                }
                

            }
           

        }
        TcpClient client;
        Dictionary<String, TcpClient> Clients = new Dictionary<string, TcpClient>();
        static byte[] msg = new byte[4096];
        List<string> orders = new List<string>();
        List<string> waiting = new List<string>();

        private void ConnectListner(IAsyncResult ar)
        {
            TcpListener listner = (TcpListener)ar.AsyncState;
            TcpClient Client = listner.EndAcceptTcpClient(ar);
            NetworkStream ns = Client.GetStream();
            int count = ns.Read(msg, 0, msg.Length);
            string name = (ASCIIEncoding.ASCII.GetString(msg, 0, count));
            //MessageBox.Show(name);
            Clients.Add(name, Client);
            listner.BeginAcceptTcpClient(new AsyncCallback(ConnectListner), listner);

        }





        private void StartReadOrder(IAsyncResult ar)
        {
            try
            {
                NetworkStream ns = client.GetStream();
                int count = ns.EndRead(ar);
                string msg1 = ASCIIEncoding.ASCII.GetString(msg, 0, count);
                string[] orderarray = msg1.Split(',');
                //InboxTxt.Text += msg1;
                //InboxTxt.Text += Environment.NewLine;
                if (msg1.Contains("Server"))
                {
                    MessageBox.Show("Connected to Server");
                }
                else if (orders.Count < 5)
                {
                    orders.Add(msg1);
                    for (int i = 0; i < orderarray.Length; i++)
                    {
                        txt_orders.Text += orderarray[i] + " ";
                    }
                    txt_orders.Text += Environment.NewLine;
                    
                }
                else
                {
                    waiting.Add(msg1);
                    TcpClient waitingclient = new TcpClient();
                    Clients.TryGetValue("waiting", out waitingclient);
                    NetworkStream nswaiting = waitingclient.GetStream();
                    nswaiting.Write(ASCIIEncoding.ASCII.GetBytes(orderarray[0] + ",add"), 0, orderarray[0].Length + 4);
                }
                ns.BeginRead(msg, 0, msg.Length, new AsyncCallback(StartReadOrder), ns);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void btn_completed_Click(object sender, EventArgs e)
        {
            TcpClient completedclient = new TcpClient();
            Clients.TryGetValue("completed", out completedclient);
            NetworkStream completedstream = completedclient.GetStream();
            completedstream.Write(ASCIIEncoding.ASCII.GetBytes(txt_completed.Text), 0, txt_completed.Text.Length);
            for (int i = 0; i < orders.Count; i++)
            {
                string[] temp = orders[i].Split(',');
                if (txt_completed.Text.ToString() == temp[0])
                {
                    orders.RemoveAt(i);
                    if (waiting.Count > 0)
                    {
                        orders.Add(waiting[0]);
                    }
                   
                }
            }
            if (waiting.Count > 0)
            {
                string[] arr = waiting[0].Split(',');
                waiting.RemoveAt(0);
                TcpClient waitingclient = new TcpClient();
                Clients.TryGetValue("waiting", out waitingclient);
                NetworkStream waitingstream = waitingclient.GetStream();
                waitingstream.Write(ASCIIEncoding.ASCII.GetBytes(arr[0] + ",remove"), 0, arr[0].Length + 7);
            }
            

            txt_orders.Text = string.Empty;
            
            for (int i = 0; i < orders.Count; i++)
            {
                string[] array = orders[i].Split(',');
                for (int j = 0; j < array.Length; j++)
                {
                    txt_orders.Text += array[j] + " ";
                }

                txt_orders.Text += Environment.NewLine;

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            client = new TcpClient();
            client.Connect(IPAddress.Parse("192.168.0.120"), 11000);
            client.Connect(IPAddress.Loopback,11000);
            NetworkStream ns = client.GetStream();
            button1.Enabled = false;
            ns.BeginRead(msg, 0, msg.Length, new AsyncCallback(StartReadOrder), ns);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            if (!isServerUp)
            {
                Application.ExitThread();
            }
            Process.Start(@"..\..\..\..\McDonaldOrderCompleted\McDonaldOrderCompleted\bin\Debug\McDonaldOrderCompleted.exe");
            Process.Start(@"..\..\..\..\McDonaldOrderWaiting\McDonaldOrderWaiting\bin\Debug\McDonaldOrderWaiting.exe");
        }
    }
}
