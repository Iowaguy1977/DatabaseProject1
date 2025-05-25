using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject1
{
    internal class OrderEntity
    {
        public int Order_ID { get; set; }
        public string Item_type { get; set; }
        public string Item_name { get; set; }
        public int Qty { get; set; }
        public double Price_Each { get; set; }
        public int Customer_ID { get; set; }
    }
}
