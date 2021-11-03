using System;
using System.Collections.Generic;
using System.Text;

namespace NFA.Models
{
    public class User
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string rank { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public int urID { get; set; }



        public User()
        {
        }

    }
}
