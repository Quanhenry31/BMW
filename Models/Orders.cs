using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Orders
    {
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public DateTime OrderDate { get; set; }
        public string Address { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateOk { get; set; }
        public DateTime Time { get; set; }
        public string allPrice { get; set; }
        public List<OrderDetails> list_json_chitiethoadon { get; set; }

    }

    public class OrderDetails
    {
        public int OrderDetailID { get; set; }
        public int carID { get; set; }
        public int OrderID { get; set; }
        public int Quantity { get; set; }
        public string Tatus { get; set; }
        public int Allmoney { get; set; }
        public string status { get; set; }
       

    }
}
