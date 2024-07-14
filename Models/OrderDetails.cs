using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class OrderDetails
    {
        public int OrderDetailID { get; set; }
        public int carID { get; set; }
        public int OrderID { get; set; }
        public int Quantity { get; set; }
        public string Allmoney { get; set; }
    }
}
