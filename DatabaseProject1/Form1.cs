using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;
using System.Text.Json.Nodes;
using Newtonsoft.Json;

using Dapper;
using Microsoft.VisualBasic;
namespace DatabaseProject1
{
   
    public partial class Form1 : Form
    {
       
        readonly String connectionString = "Data Source=DESKTOP-8AR155P;Initial Catalog=DBProject1;Integrated Security=True;Trust Server Certificate=True";
        readonly String Chris = System.IO.File.ReadAllText(@"C:\Users\chris\source\repos\DatabaseProject1\DatabaseProject1.json.txt");
       


        public Form1()
        {
            InitializeComponent();
        }   

        private void button1_Click(object sender, EventArgs e)
        {
            Orders[] deserializedOrders = JsonConvert.DeserializeObject<Orders[]>(Chris);

            string sql = "INSERT INTO Orders (Item_Type, Item_Name, Qty, Price_Each, Customer_ID) VALUES (@Item_Type,@Item_Name, @Qty, @Price_Each, @Customer_ID)";
            // Fix: Ensure the SqlConnection type is recognized by including the correct namespace  
            using (var connection = new SqlConnection(connectionString))
            {
                
                connection.Open();
                _ = connection.Execute(sql, new { Item_Type = deserializedOrders[0].Order_ID, Item_Name = deserializedOrders[0].Item_Name, Qty = deserializedOrders[0].Qty, Price_Each = deserializedOrders[0].Price_each, Customer_ID = deserializedOrders[0].Customer_ID });
                connection.Close();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String pulleddata = "select * from Orders";
            Orders chris = new Orders();
          

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var orders1= connection.Query<Orders>(pulleddata);
                SqlDataAdapter da = new SqlDataAdapter(pulleddata, connection);
                DataTable dataTable = new DataTable();
                da.Fill(dataTable);
                File.AppendAllText(@"C:\Users\chris\source\repos\DatabaseProject1\DatabaseProject1.json.txt", JsonConvert.SerializeObject(dataTable));
                    
                connection.Close();

            }
        }
    }
}