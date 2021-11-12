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

            Task asyncaa = Populate(orderId);

        }


        public async Task Populate(string ordId)
        {
            orderModel = new AppOrderModel();
            await orderModel.getOrderAsync(ordId);
            Title = "Order: " + orderModel.Order.id.ToString();
            Lb_CustomerId.Text = orderModel.Order.CustomerId.ToString() ;
            Lb_LocationId.Text = orderModel.Order.LocationId.ToString();
            Lb_StatusId.Text = orderModel.Order.StatusId.ToString();
            Lb_OrderDate.Text = orderModel.Order.OrderDate.ToString();
            Lb_OrderShipped.Text = orderModel.Order.OrderShipped.ToString();
            Lb_OrderPacked.Text = orderModel.Order.OrderPacked.ToString();
            Lb_PackageQty.Text = orderModel.Order.PackageQty;
            Lb_PackedId.Text = orderModel.Order.PackedId.ToString();
            Lb_DriverId.Text = orderModel.Order.DriverId.ToString();
            Lb_Content.Text = orderModel.Order.Content;
            Lb_NotesStorage.Text = orderModel.Order.NotesStorage;
            Lb_NotesNotesPreparation.Text = orderModel.Order.NotesPreparation;

        }


    }  // partial class

}//namespace