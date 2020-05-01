using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McDonaldOrderProcess
{
    class Order
    {
        public int OrderID { get; set; }
        public List<Item> OrderItems { get; set; }
        public int OrderPrice { get; set; }
        
        public Order(int orderid,List<Item> l) {
            OrderID  = 1;
            OrderPrice = 0;
            OrderItems = l;
        }
        

    }
}
