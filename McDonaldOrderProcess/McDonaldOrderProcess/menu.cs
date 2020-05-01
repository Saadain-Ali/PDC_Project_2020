using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace McDonaldOrderProcess
{
    public partial class menu : UserControl
    {
        private Action fill_list;
        public List<Item> ord;
        private Order_create order_create;

        public menu()
        {
            InitializeComponent();
        }

        public menu(Order_create order_create)
        {
            this.order_create = order_create;
        }

        public menu(ref List<Item> ord, Action fill_list)
        {
            this.ord = ord;
            this.fill_list = fill_list;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Item nug = new Item("mcNuggets",340);
            order_create.menulitsener(nug);
           
        }
    }
}
