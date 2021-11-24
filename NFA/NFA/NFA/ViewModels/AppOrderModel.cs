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
            //loadOrderCommand = new Command(async () => await ExecuteLoadOrderCommand());


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
                
                if (app.OrderList == null)
                {
                   app.OrderList = await ADM.GetOrderList();
                }

                if (Order != null)
                {
                    Order = new Order();
                }
                Order ob = (Order)ADM.OrderList.Find(x => x.id.ToString() == id);
                Order = ob;
                //Order = await ADM.GetItemAsync(id);


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

                Order check = app.OrderList.First(O => O.id == Order.id);

                var index = app.OrderList.IndexOf(check);
                Order updated = check;

                if (index != -1)
                   app.OrderList[index] = updated;
                //await ADM.UpdateItemAsync(Order);

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
