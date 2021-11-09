using System;
using System.Collections.Generic;
using System.Text;

namespace NFA.Models
{
    public class Order
    {
        public int id { get; set; }
        public int CustomerId { get; set; }
        public int LocationId { get; set; }
        public int StatusId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime OrderShipped { get; set; }
        public DateTime OrderPacked { get; set; }
        public string PackageQty { get; set; }
        public int PackerId { get; set; }
        public int DriverId { get; set; }
        public string Content { get; set; }
        public string NotesStorage { get; set; }
        public string NotesPreparation { get; set; }

        public Order()
        {

        }
    }
}
