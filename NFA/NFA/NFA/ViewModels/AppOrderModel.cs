using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using NFA.Models;
using NFA.Views;
using System.Threading.Tasks;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using NFA.Services;

namespace NFA.ViewModels
{

    public class AppOrderModel : BaseViewModel
    {
        public AppOrderModel()
        {

        }
        public AppOrderModel(string scannedId)
        {
           getOrderAsync(scannedId);

        }


        //* note-may not be needed
        //public Command loadOrderCommand { get; set; }

        public JObject PulledApi { get; set; } = null;

        public Order Order { get; set; }



        public async void getOrderAsync(string id = null)
        {
            AppDataManagement ADM = new AppDataManagement();
            try
            {
                Order = await ADM.GetItemAsync(id);
                //Order = await OrderStore.GetItemAsync(id);
                //OrderModel.PulledApi = await dataManagement.GetItemAsync(id);
                //await DisplayAlert("sda", OrderModel.PulledApi.ToString(), "cancel");

            }

            catch (Exception ex)
            {
                //= DisplayAlert("Error", ex.ToString(), "Confirm");
                Console.WriteLine(ex);
            }


        }




        public AppOrderModel(Order order)
        {
            //loadOrderCommand = new Command(async () => await ExecuteLoadOrderCommand());


            Title = order.id.ToString();

            Order = order;

            //Title = order.Value<JObject>("id").ToString();
            //Order.id = (int)order.Value<JObject>("id");
            //Order.CustomerId = (int)order.Value<JObject>("CustomerId");
            //Order.DriverId = (int)order.Value<JObject>("DriverId");
            //Order.LocationId = (int)order.Value<JObject>("LocationId");
            //Order.StatusId = (int)order.Value<JObject>("StatusId");
            //Order.PackerId = (int)order.Value<JObject>("PackerId");
            //Order.Content = order.Value<JObject>("Content").ToString() ;
            //Order.NotesPreparation = order.Value<JObject>("NotesPreparation").ToString();
            //Order.NotesStorage = order.Value<JObject>("NotesStorage").ToString();

        }



        //public int id { get; set; }
        //public int CustomerId { get; set; }
        //public int LocationId { get; set; }
        //public int StatusId { get; set; }
        //public DateTime OrderDate { get; set; }
        //public DateTime OrderShipped { get; set; }
        //public DateTime OrderPacked { get; set; }
        //public string PackageQty { get; set; }
        //public int PackerId { get; set; }
        //public int DriverId { get; set; }
        //public string Content { get; set; }
        //public string NotesStorage { get; set; }
        //public string NotesPreparation { get; set; }

    } // base view
} // namespace
