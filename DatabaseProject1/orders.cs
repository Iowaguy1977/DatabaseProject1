using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject1
{

    public class orders
    {
        public object[] order = new object[5];
        public int Order_ID;
        public string Item_Type;
        public string Item_Name;
        public int Qty;
        public double Price_each;
        public int Customer_ID;

        public void setOrder()
        {
            order[0]=(Order_ID);
            order[1]=(Item_Type);
            order[2]=(Item_Name);
            order[3]=(Qty);
            order[4]=(Price_each);
            order[5]=(Customer_ID);
        }
        
    }
      







    
}
