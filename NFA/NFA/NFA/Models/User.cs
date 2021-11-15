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
        public string serialnumber { get; set; }
        public string email { get; set; }
        public int UserRoleId { get; set; }



        public User()
        {
        }

    } // class
} // namespace

/*
public DateTime OrderPacked
{
    get { return _OrderPacked; }
    set
    {
        if (value == null)
        {
            _OrderPacked = DateTime.Now;
        }
        else
        {
            _OrderPacked = value;
        }
    }
}
public string PackageQty { get; set; }

public int PackedId
{
    get { return _PackerId; }
    set
    {
        if (value == null)
        {
            _PackerId = 0;
        }
        else
        {
            _PackerId = value;
        }
    }
}

*/