using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Product
    {
        public int productID { get; set; }
        public string? name { get; set; }
        public string? modelCode { get; set; }
        public int price { get; set; }
        public DateTime year { get; set; }
        public int categoryID { get; set; }
        public string? image { get; set; }
        public int quantity { get; set; }

    }
}


 