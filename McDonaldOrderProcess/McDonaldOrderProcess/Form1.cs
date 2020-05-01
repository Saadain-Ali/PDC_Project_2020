using System;
using System.Messaging;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace McDonaldOrderProcess
{
    public partial class Form1 : Form
    {
        Item ChickenWings;
        Item Broast;
        Item ZingerBurger;
        Item BeefBurger;
        Order o;

        Dictionary<String, TcpClient> Clients = new Dictionary<string, TcpClient>();
        TcpClient client1 = new TcpClient();
        static byte[] msg = new byte[1024];
        public Form1()
        {
            InitializeComponent();
            //ChickenWings = new Item();
            //Broast = new Item();
            //ZingerBurger = new Item();
            //BeefBurger = new Item();
            //o = new Order();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // TcpListener listner = new TcpListener((IPAddress.Parse("192.168.1.113")), 11000);
            // listner.Start();
            // listner.BeginAcceptTcpClient(new AsyncCallback(ConnectListner), listner);
            MessageQueue queue = new MessageQueue();
            string Path = System.Environment.MachineName + "\\MCDonald1";
            //string Path = System.Environment.MachineName+@"\private$\MCDonald1";
            queue.Formatter = new XmlMessageFormatter();

            if (!MessageQueue.Exists(Path))
            {
                queue.Path = Path;
                MessageQueue.Create(queue.Path);
            }
            foreach (var item in o.OrderItems)
            {
                //o.OrderPrice += item.ItemPrice;
            }
            queue.Send(o);
            o.OrderItems.Clear();
            o.OrderPrice = 0;
            o.OrderID++;
        }
        private void ConnectListner(IAsyncResult ar)
        {
            TcpListener listner = (TcpListener)ar.AsyncState;
            TcpClient Client = listner.EndAcceptTcpClient(ar);
            NetworkStream ns = Client.GetStream();
            ns.Write(ASCIIEncoding.ASCII.GetBytes("Hey"), 0, "Hey".Length);
            //int count = ns.Read(msg, 0, msg.Length);
          //  string name = (ASCIIEncoding.ASCII.GetString(msg, 0, count));
           // Clients.Add(name, Client);
          //  listBox1.Items.Add(name);
            //ns.BeginRead(msg, 0, msg.Length, new AsyncCallback(StartRead), ns);
            //listner.BeginAcceptTcpClient(new AsyncCallback(ConnectListner), listner);

        }
        private void StartRead(IAsyncResult ar)
        {
            try
            {
                NetworkStream ns = (NetworkStream)ar.AsyncState;
                int count = ns.EndRead(ar);
                //string msg1 = ASCIIEncoding.ASCII.GetString(msg, 0, count);
               // InboxTxt.Text += msg1;
                //InboxTxt.Text += Environment.NewLine;
                ns.BeginRead(msg, 0, msg.Length, new AsyncCallback(StartRead), ns);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void BTN_ZingerBurger_Click(object sender, EventArgs e)
        {
            o.OrderItems.Add(ZingerBurger);
        }

        private void BTN_Broast_Click(object sender, EventArgs e)
        {
            //TcpClient client = new TcpClient();
            //Clients.TryGetValue(clientname, out client);
            //NetworkStream ns = client.GetStream();
            //ns.Write(ASCIIEncoding.ASCII.GetBytes(MsgTxt.Text), 0, MsgTxt.Text.Length);
            //MsgTxt.Clear();
            //  o.OrderItems.Add(Broast);
        }

        private void BTN_Wings_Click(object sender, EventArgs e)
        {
            o.OrderItems.Add(ChickenWings);
        }

        private void BTN_BeefBurger_Click(object sender, EventArgs e)
        {
            o.OrderItems.Add(BeefBurger);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //ChickenWings = new Item();
            //Broast = new Item();
            //ZingerBurger = new Item();
            //BeefBurger = new Item();
            //o = new Order();

            //LBL_OrderNo.Text = o.OrderID.ToString();
            //ChickenWings.ItemName = "Chicken Wings";
            //ChickenWings.ItemPrice = 400;
            //Broast.ItemName = "Broast";
            //Broast.ItemPrice = 350;
            //ZingerBurger.ItemName = "Zinger Burger";
            //ZingerBurger.ItemPrice = 500;
            //BeefBurger.ItemName = "Beef Burger";
            //BeefBurger.ItemPrice = 250;

            //CheckForIllegalCrossThreadCalls = false;
            //ChickenWings = new Item();
            //Broast = new Item();
            //ZingerBurger = new Item();
            //BeefBurger = new Item();
            //o = new Order();
        }
    }
}
