using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McDonaldOrderProcess
{
   public class Item
    {
        public string ItemName { get; set; }
        public int quantity { get; set; }
        public Item(string ItemName, int quan)
        {
            this.ItemName = ItemName;
            quantity = quan;
        }

    }
}
