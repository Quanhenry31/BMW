﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Users
    {
        public int userID { get; set; }
        public string? userName { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
        public string? phone { get; set; }
        public string? token { get; set; }
    }
}
