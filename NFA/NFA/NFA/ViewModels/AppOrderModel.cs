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
            Order.id = (int)order.Value<JObject>("id");
            //Order.CustomerId = (int)order.Value<JObject>("CustomerId");
            //Order.DriverId = (int)order.Value<JObject>("DriverId");
            //Order.LocationId = (int)order.Value<JObject>("LocationId");
            //Order.StatusId = (int)order.Value<JObject>("StatusId");
            //Order.PackerId = (int)order.Value<JObject>("PackerId");
            //Order.Content = order.Value<JObject>("Content").ToString() ;
            //Order.NotesPreparation = order.Value<JObject>("NotesPreparation").ToString();
            //Order.NotesStorage = order.Value<JObject>("NotesStorage").ToString();

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
