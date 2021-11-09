using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using NFA.Models;
using NFA.Views;
using System.Threading.Tasks;
using System.Diagnostics;

namespace NFA.ViewModels
{
    public class AppOrderModel : BaseViewModel
    {

        //* note-may not be needed
        //public Command loadOrderCommand { get; set; }

        public Newtonsoft.Json.Linq.JObject PulledApi { get; set; } = null;


        public Order Order { get; set; } = null;
        public AppOrderModel(Order order)
        {
            //loadOrderCommand = new Command(async () => await ExecuteLoadOrderCommand());

            Title = order?.id.ToString();
            Order = order;

        }
        public AppOrderModel()
        {

        }



        //async Task ExecuteLoadOrderCommand()
        //{
        //    if (IsBusy)
        //        return;

        //    IsBusy = true;

        //    try
        //    {
        //        Order = null;


        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex);
        //    }
        //    finally
        //    {
        //        IsBusy = false;
        //    }
        //}

    } // base view
} // namespace
