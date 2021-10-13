using System;
using System.Collections.Generic;
using System.Text;

namespace NFA.Models
{
    public class Order
    {
        //aaaaaaaaaaaaaaaa
        public int id { get; set; }
        public int customerId { get; set; }
        public int locationId { get; set; }
        public string orderStatus { get; set; }
        public DateTime orderDate { get; set; }
        public DateTime orderShipped { get; set; }
        public DateTime orderPacked { get; set; }
        public string packageQty { get; set; }
        public int packerId { get; set; }
        public int driverId { get; set; }
        public string content { get; set; }
        public string notesStorage { get; set; }
        public string notesPreparation { get; set; }
    }
}
