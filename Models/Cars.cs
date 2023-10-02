using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Cars
    {
        public int carID { get; set; }
        public string? name { get; set; }
        public string? modelCode { get; set; }
        public DateTime year { get; set; }
        public string? price { get; set; }
        public string? description { get; set; }
        public string? categoryID { get; set; }
    }
}
//year date,
//    price varchar(50),
//	description nvarchar(500),--Mô tả chi tiết về xe ô tô.
//	categoryID varchar(50),