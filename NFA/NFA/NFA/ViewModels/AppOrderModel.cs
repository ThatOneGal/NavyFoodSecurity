using NFA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NFA.Services;

namespace NFA.ViewModels
{
    
    public class AppOrderModel : BaseViewModel
    {
        LogUtils lu = new LogUtils();

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
                lu.Log(ex.ToString());
            }


        }


        /// <summary>
        /// sends the Order data back into the api to be saved
        /// </summary>
        /// <returns></returns>
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
                lu.Log(e.ToString());
                Console.WriteLine("_______________________________________________________");

            }
        }

        /// <summary>
        /// Method for the conversion of id to name (UX) 
        /// </summary>
        /// <returns></returns>
        public async Task getNameForId()
        {
            StatusName = await ADM.GetApiStatusNameAsync(Order.StatusId);
            LocationName = await ADM.GetApiLocationNameAsync(Order.LocationId);
        }



    } // base view
} // namespace
