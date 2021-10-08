using System;

using NFA.Models;

namespace NFA.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Order order { get; set; }
        public ItemDetailViewModel(Order o = null)
        {
            Title = "Order " + o?.id.ToString();
            order = o;
        }
    }
}
