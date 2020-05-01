using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace McDonaldOrderCompleted
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool ServerUp = false;
        TcpClient client;
        Queue queue;
        static byte[] msg = new byte[1024];
        List<Label> LabelList; 
        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            queue = new Queue();
            LabelList = new List<Label>();
            LabelList.Add(label2);
            LabelList.Add(label3);
            LabelList.Add(label4);
            LabelList.Add(label5);
            LabelList.Add(label6);
            LabelList.Add(label7);
            foreach (var item in LabelList)
            {
                item.Text = "vacant";
            }
            try
            {
                client = new TcpClient();
                client.Connect((IPAddress.Loopback), 11001);
                NetworkStream ns = client.GetStream();
                ns.Write(ASCIIEncoding.ASCII.GetBytes("completed"), 0, "completed".Length);
                ns.BeginRead(msg, 0, msg.Length, new AsyncCallback(StartRead), ns);
                ServerUp = true;
            }
            catch (Exception err)
            {
                if (err.Message == "No connection could be made because the target machine actively refused it 127.0.0.1:11001")
                {
                    MessageBox.Show("Please run Kitchen Screen first");
                    Application.Exit();
                }
            }
            
        }
        private void StartRead(IAsyncResult ar)
        {
            
            try
            {
                NetworkStream ns = client.GetStream();
                int count = ns.EndRead(ar);
                string NewOrder = ASCIIEncoding.ASCII.GetString(msg, 0, count);
                LastServe.Text = "Last Served: " +NewOrder;
                string OlddOrder = "";
                if (queue.Count ==6)
                {
                    OlddOrder=(string) queue.Dequeue();
                    foreach (var item in LabelList)
                    {
                        if (item.Text.Contains(OlddOrder))
                        {
                            queue.Enqueue(NewOrder);
                            item.Text = "Order No: "+NewOrder;
                        }
                    }
                }
                else
                {
                    foreach (var item in LabelList)
                    {
                        if (item.Text == "vacant")
                        {
                            queue.Enqueue(NewOrder);
                            item.Text = "Order No: " + NewOrder;
                            break;
                        }
                    }
                }

              //  InboxTxt.Text += msg1;
               // InboxTxt.Text += Environment.NewLine;
                ns.BeginRead(msg, 0, msg.Length, new AsyncCallback(StartRead), ns);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
