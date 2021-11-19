using NFA.Models;
using System;
using System.Threading.Tasks;

namespace NFA.ViewModels
{

    public class AppOrderModel : BaseViewModel
    {
        public AppOrderModel()
        {

        }


        //* note-may not be needed
        //public Command loadOrderCommand { get; set; }


        public Order Order { get; set; }


        public AppOrderModel(Order order)
        {
            //loadOrderCommand = new Command(async () => await ExecuteLoadOrderCommand());


            Title = order.id.ToString();

            Order = order;


        }


        public async Task getOrderAsync(string id = null)
        {
            try
            {
                Order = await ADM.GetItemAsync(id);


            }

            catch (Exception ex)
            {
                //= DisplayAlert("Error", ex.ToString(), "Confirm");
                Console.WriteLine(ex);
            }


        }

        public async Task pushOrderAsync()
        {
            try
            {
                await ADM.UpdateItemAsync(Order);

            }
            catch (Exception e)
            {
                Console.WriteLine("_______________________________________________________");
                Console.WriteLine(e);
                Console.WriteLine("_______________________________________________________");

            }
        }



    } // base view
} // namespace
