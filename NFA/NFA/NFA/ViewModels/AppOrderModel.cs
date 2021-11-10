using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using NFA.Models;
using NFA.Views;
using System.Threading.Tasks;
using System.Diagnostics;
using Newtonsoft.Json.Linq;

namespace NFA.ViewModels
{
    public class AppOrderModel : BaseViewModel
    {

        //* note-may not be needed
        //public Command loadOrderCommand { get; set; }

        public JObject PulledApi { get; set; } = null;


        public Order Order { get; set; } = null;
        public AppOrderModel(JObject order)
        {
            //loadOrderCommand = new Command(async () => await ExecuteLoadOrderCommand());
            Title = order.Value<JObject>("id").ToString();
            PulledApi = order;

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
