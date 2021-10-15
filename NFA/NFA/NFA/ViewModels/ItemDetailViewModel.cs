using System;

using NFA.Models;

namespace NFA.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Order order { get; set; }
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null/*Order o = null*/)
        {
            Title = item?.Text; /*"Order " + o?.id.ToString();*/
            Item = item;/*order = o;*/
        }
    }
}
