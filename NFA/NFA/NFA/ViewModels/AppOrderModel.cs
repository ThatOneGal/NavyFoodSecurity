using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using NFA.Models;
using NFA.Views;

namespace NFA.ViewModels
{
    public class AppOrderModel : BaseViewModel
    {
        /*
         * note-may not be needed 
                private Command loadOrderCommand;

                public ICommand LoadOrderCommand
                {
                    get
                    {
                        if (loadOrderCommand == null)
                        {
                            loadOrderCommand = new Command(LoadOrder);
                        }

                        return loadOrderCommand;
                    }
                }

                private void LoadOrder()
                {

                }
        */
        public Order Order { get; set; }
        public AppOrderModel(Order order = null)
        {
            Title = order?.id.ToString();
            Order = order;

        }




    }
}
