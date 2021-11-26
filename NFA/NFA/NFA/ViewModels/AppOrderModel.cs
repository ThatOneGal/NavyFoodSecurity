using NFA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFA.ViewModels
{

    public class AppOrderModel : BaseViewModel
    {

        App app = new App();
        public AppOrderModel()
        {
        }




        //* note-may not be needed
        //public Command loadOrderCommand { get; set; }


        public Order Order { get; set; }
        public string StatusName { get; set; }
        public string LocationName { get; set; }

        public AppOrderModel(Order order)
        {

            Title = order.id.ToString();

            Order = order;


        }

    



        /// <summary>
        /// loads the order into the model
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task getOrderAsync(string id = null)
           
        {
            try
            {

          
                Order = await ADM.GetItemAsync(id);


            }

            catch (Exception ex)
            {
                
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

        public async Task getNameForId()
        {
            StatusName = await ADM.GetApiStatusNameAsync(Order.StatusId);
            LocationName = await ADM.GetApiLocationNameAsync(Order.LocationId);
        }



    } // base view
} // namespace
