using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace NFA.Models
{
    public class Order : INotifyPropertyChanged
    {
        DateTime _OrderDate;
        DateTime _OrderShipped;
        DateTime _OrderPacked;
        int _PackerId;
        int _DriverId;


        public int id { get; set; }
        public int CustomerId { get; set; }
        public int LocationId { get; set; }
        public int StatusId { get; set; }
        public DateTime OrderDate {
            get { return _OrderDate; }
            set 
            {
                if(value == null)
                {
                    _OrderDate = DateTime.Now;
                }
                else
                {
                    _OrderDate = value;
                }
            }
        }        
        public DateTime OrderShipped {
            get { return _OrderShipped; }
            set 
            {
                if(value == null)
                {
                    _OrderShipped = DateTime.Now;
                }
                else
                {
                    _OrderShipped = value;
                }
            }
        }        
        public DateTime OrderPacked {
            get { return _OrderPacked; }
            set 
            {
                if(value == null)
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

        public int PackerId
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
        public int DriverId
        {
            get { return _DriverId; }
            set
            {
                if (value == null)
                {
                    _DriverId= 0;
                }
                else
                {
                    _DriverId = value;
                }
            }
        }
        public string Content { get; set; }
        public string NotesStorage { get; set; }
        public string NotesPreparation { get; set; }

        public Order()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
