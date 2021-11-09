using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFA.Services;
using NFA.ViewModels;
using NFA.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NFA.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppScannedOrder : ContentPage
    {
        AppOrderModel OrderModel = new AppOrderModel();

        public AppScannedOrder(string orderId)
        {
            getOrderAsync(orderId);


        }



        public async void getOrderAsync(string id = null)
        {
            AppDataManagement dataManagement = new AppDataManagement();
            try
            {
                OrderModel.Order = await dataManagement.GetItemAsync(id);

            }

            catch (Exception ex)
            {
                //= DisplayAlert("Error", ex.ToString(), "Confirm");
                Console.WriteLine(ex);
            }

            
        }

    
    }  // partial class

}//namespace