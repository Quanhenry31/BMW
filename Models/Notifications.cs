using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Notifications
    {
        public int NotificationID { get; set; }
        public int userID { get; set; }
        public string Content { get; set; }
        public string IsRead { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
