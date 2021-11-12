using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFA.Services;
using NFA.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NFA.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppScannedOrder : ContentPage
    {
        AppOrderModel orderModel = new AppOrderModel();


        public AppScannedOrder(string orderId)
        {
            InitializeComponent();
            orderModel = new AppOrderModel(orderId);


        }


        public void Populate()
        {
            Lb_id.Text = orderModel.Order.id.ToString();
        }

    
    }  // partial class

}//namespace