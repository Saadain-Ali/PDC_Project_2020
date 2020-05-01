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

namespace McDonaldOrderWaiting
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        TcpClient client;
        Queue queue;
        static byte[] msg = new byte[1024];
        List<Label> LabelList;
        private void Form1_Load(object sender, EventArgs e)
        {
            //something that is useless for you can be useful to others 
            CheckForIllegalCrossThreadCalls = false;
            queue = new Queue();
            LabelList = new List<Label>();
            LabelList.Add(label2);
            LabelList.Add(label3);
            LabelList.Add(label4);
            LabelList.Add(label5);
            LabelList.Add(label6);
            LabelList.Add(label7);
            LabelList.Add(label8);
            LabelList.Add(label9);

            foreach (var item in LabelList)
            {
                item.Text = "vacant";
            }
            try
            {
                client = new TcpClient();
                client.Connect((IPAddress.Loopback), 11001);
                NetworkStream ns = client.GetStream();
                ns.Write(ASCIIEncoding.ASCII.GetBytes("waiting"), 0, "waiting".Length);
                ns.BeginRead(msg, 0, msg.Length, new AsyncCallback(StartRead), ns);
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
                string [] message = NewOrder.Split(',');
                // LastServe.Text = NewOrder;
                string OlddOrder = "";
                if (message[1] =="add")
                {
                    if (queue.Count == 8)
                    {
                        OlddOrder = (string)queue.Dequeue();
                        foreach (var item in LabelList)
                        {
                            if (item.Text.Contains(OlddOrder))
                            {
                                queue.Enqueue(message[0]);
                                item.Text = "Order No: "+message[0];
                            }
                        }
                    }
                    else
                    {
                        foreach (var item in LabelList)
                        {
                            if (item.Text == "vacant")
                            {
                                queue.Enqueue(message[0]);
                                item.Text = "Order No: " + message[0];
                                break;
                            }
                        }
                    }

                }
                else if(message[1] == "remove")
                {
                    foreach (var item in LabelList)
                    {
                        if (item.Text.Contains(message[0]))
                        {
                            
                            item.Text = "vacant";
                        }
                    }
                    int counter = queue.Count;
                    for (int i = 0; i < counter; i++)
                    {
                        string temp = (string)queue.Dequeue();
                        if (temp != message[1])
                        {
                            queue.Enqueue(temp);
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
