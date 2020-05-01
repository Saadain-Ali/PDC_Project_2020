using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Messaging;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace McDonaldOrderProcess
{
    public partial class Order_create : Form
    {
        public Order_create()
        {
            InitializeComponent();
            ord = new List<Item>();
            orders = new List<Order>();
        }
        int count_ord = 1;
        Dictionary<string, string> d;
        Dictionary<String, TcpClient> Clients = new Dictionary<string, TcpClient>();
        TcpClient client1 = new TcpClient();
        static byte[] msg = new byte[4096];
        private bool connected = false;


        private void Order_create_Load(object sender, EventArgs e)
        {


          
            //serverup
            TcpListener listner = new TcpListener((IPAddress.Loopback), 11000);
            listner.Start();
            listner.BeginAcceptTcpClient(new AsyncCallback(ConnectListner), listner);
            add_items();

            Process.Start(@"..\..\..\..\Kitchen\Kitchen\bin\Debug\Kitchen.exe");

            textBox1.Text = "Order no : " + count_ord;
        }
        private void add_items()
        {
            comboBox1.Items.Clear();
            d = new Dictionary<string, string>();
            //string[] arr = File.ReadAllLines(@"..\..\..\..\resources\items.txt");
            string[] arr = File.ReadAllLines(@"items.txt");
            List<string> it = new List<string>();
            foreach (var item in arr)
            {
                string[] a = item.Split(' ');
                it.Add(a[0]);
                d.Add(a[0], a[1]);
            }
            comboBox1.Items.AddRange(it.ToArray());
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox3.Text = d[comboBox1.Text];
            textBox2.Text = 1.ToString();
        }
        List<Order> orders;
        List<Item> ord;
        private void fill_list()
        {
            listView1.Items.Clear();
            foreach (var item in ord)
            {
                ListViewItem l = new ListViewItem(item.ItemName);
                l.SubItems.Add(item.quantity.ToString());
                listView1.Items.Add(l);
            }
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (connected)
            {
                if (comboBox1.Text.Trim() == "")
                {
                    comboBox1.BackColor = Color.Red;
                }
                else
                {
                    if (button1.Text != "update")
                    {
                        Item i = new Item(comboBox1.Text, Convert.ToInt32(textBox2.Text));
                        ord.Add(i);
                        comboBox1.Items.Remove(comboBox1.Text);
                        fill_list();
                    }
                    else
                    {
                        foreach (var item in ord)
                        {
                            if (item.ItemName == comboBox1.Text.Trim())
                            {
                                item.quantity = Convert.ToInt32(textBox2.Text);
                                break;
                            }
                        }
                        fill_list();
                        button1.Text = "Add more";
                    }
                    comboBox1.Text = "";
                    textBox2.Clear();
                    textBox3.Clear();
                }
            }
            else
            {
                MessageBox.Show("Kitchen is not connected....");
            }
        }
        Order o;
        private void button2_Click(object sender, EventArgs e)
        {
            if (connected)
            {
                if (ord.Count <= 0)
                {
                    MessageBox.Show("Please Select a meal form a menu");
                }
                else
                {
                    int total_price = 0;
                    o = new Order(count_ord, ord);
                    orders.Add(o);
                    listView1.Items.Clear();
                    string order = count_ord + ",";
                    foreach (var item in ord)
                    {
                        if (item.ItemName.Contains("@"))
                        {
                            order += item.ItemName + "," + 1 + ",";
                            total_price += Convert.ToInt32(item.quantity) * 1;
                        }
                        else
                        {
                            order += item.ItemName + "," + item.quantity + ",";
                            total_price += Convert.ToInt32(d[item.ItemName]) * item.quantity;
                        }
                        
                        
                    }
                    count_ord++;
                    textBox1.Text = "Order no : " + count_ord;
                    ord = new List<Item>();
                    order = order.Remove(order.Length - 1, 1);
                    MessageQueue queue = new MessageQueue();
                    string Path = System.Environment.MachineName + "\\MCDonald1";
                    //queue.Formatter = new XmlMessageFormatter();
                    add_items();
                    //if (!MessageQueue.Exists(Path))
                    //{
                    //    queue.Path = Path;
                    //    MessageQueue.Create(queue.Path);
                    //}
                    //queue.Send(o);
                    ns.Write(ASCIIEncoding.ASCII.GetBytes(order), 0, order.Length);
                    MessageBox.Show("order created! Bill : " + total_price);
                }  
            }
            else
            {
                MessageBox.Show("Kitchen is not connected....");
            }
        }
            
        NetworkStream ns;


        private void ConnectListner(IAsyncResult ar)
        {
            if (!connected)
            {
                connected = true;
                TcpListener listner = (TcpListener)ar.AsyncState;
                TcpClient Client = listner.EndAcceptTcpClient(ar);
                ns = Client.GetStream();
                ns.Write(ASCIIEncoding.ASCII.GetBytes("Server Connected!"), 0, "Server Connected!".Length);
                //MessageBox.Show("Kitchen is connected");
            }
            else
            {
                MessageBox.Show("Kitchen is already connected","message",MessageBoxButtons.OK);
            }
           
            //int count = ns.Read(msg, 0, msg.Length);
            //  string name = (ASCIIEncoding.ASCII.GetString(msg, 0, count));
            // Clients.Add(name, Client);
            //  listBox1.Items.Add(name);
            //ns.BeginRead(msg, 0, msg.Length, new AsyncCallback(StartRead), ns);
            //listner.BeginAcceptTcpClient(new AsyncCallback(ConnectListner), listner);

        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            comboBox1.Text = listView1.SelectedItems[0].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox3.Text = d[comboBox1.Text];
            button1.Text = "update";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_MouseDown(object sender, MouseEventArgs e)
        {
            comboBox1.BackColor = Color.White;
        }

        private void comboBox1_MouseDown(object sender, KeyEventArgs e)
        {
            comboBox1.BackColor = Color.White;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (panel2.Visible)
                panel2.Visible = false;
            else
                panel2.Visible = true;
        }
        public void menulitsener( Item _item)
        {
            Item i = _item;
            ord.Add(i);
            comboBox1.Items.Remove(comboBox1.Text);
            fill_list();

        }

        

        private void mcNug_340_DoubleClick(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            string[] data = p.Name.Split('_');
            Item i = new Item(data[0],Convert.ToInt32(data[1]));
            menulitsener(i);
        }
    }
}
