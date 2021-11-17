using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFA.Services;
using NFA.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NFA.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppScannedOrder : ContentPage
    {
        AppOrderModel orderModel = new AppOrderModel();

        string Role = Preferences.Get("Role", "");
        int UserId = int.Parse(Preferences.Get("Local_Id","0"));

        public AppScannedOrder(string orderId)
        {
            InitializeComponent();

            Task asyncaa = Populate(orderId);

        }


        public async Task Populate(string ordId)
        {
            orderModel = new AppOrderModel();
            await orderModel.getOrderAsync(ordId);
            FillOrderForm();
   

        }

        public void FillOrderForm()
        {
            Title = "Order: " + orderModel.Order.id.ToString();
            Lb_CustomerId.Text = orderModel.Order.CustomerId.ToString();
            Lb_LocationId.Text = orderModel.Order.LocationId.ToString();
            Lb_StatusId.Text = orderModel.Order.StatusId.ToString();
            Lb_OrderDate.Text = orderModel.Order.OrderDate.ToString();
            Lb_OrderShipped.Text = orderModel.Order.OrderShipped.ToString();
            Lb_OrderPacked.Text = orderModel.Order.OrderPacked.ToString();
            Et_PackageQty.Text = orderModel.Order.PackageQty;
            Lb_PackedId.Text = orderModel.Order.PackerId.ToString();
            Lb_DriverId.Text = orderModel.Order.DriverId.ToString();
            Et_Content.Text = orderModel.Order.Content;
            Et_NotesStorage.Text = orderModel.Order.NotesStorage;
            Et_NotesNotesPreparation.Text = orderModel.Order.NotesPreparation;

        }
        
        public void FillOrderObject()
        {
            //Lb_CustomerId.Text = orderModel.Order.CustomerId.ToString();
            //Lb_LocationId.Text = orderModel.Order.LocationId.ToString();
            //Lb_OrderDate.Text = orderModel.Order.OrderDate.ToString();
       

            //considerations required for editability
            orderModel.Order.Content = Et_Content.Text;
            orderModel.Order.StatusId = int.Parse(Lb_StatusId.Text);


            orderModel.Order.PackageQty = Et_PackageQty.Text;
            orderModel.Order.NotesStorage = Et_NotesStorage.Text;
            orderModel.Order.NotesPreparation = Et_NotesNotesPreparation.Text;

            // placeholder awaiting user role application
            //if user role is packer shows update packeddate
            if (Role == "Packer")
            {
                //Lb_PackedId.Text = orderModel.Order.PackerId.ToString();
                orderModel.Order.PackerId = UserId;
                orderModel.Order.OrderPacked = DateTime.Now;
                //Lb_OrderPacked.Text = orderModel.Order.OrderPacked.ToString();
            }

            if (Role == "Driver")
            {
                //Lb_DriverId.Text = orderModel.Order.DriverId.ToString();
                orderModel.Order.DriverId = UserId;
                orderModel.Order.OrderShipped = DateTime.Now;
                //Lb_OrderShipped.Text = orderModel.Order.OrderShipped.ToString();
            }

        }

        private void Btn_Update_Clicked(object sender, EventArgs e)
        {

            Task updater = validateUpdate();
        }

        private void Btn_Reset_Clicked(object sender, EventArgs e)
        {

            //FillOrderForm();
            Task checking = validatedReset();

        }

    //    Task confirm = checker();

    //    bool check = checker().Result;

    //        if (check)
    //        {
    //            Task LoadOrder = Populate(orderModel.Order.id.ToString());
    //}

        public async Task validatedReset()
        {
            string title = "Reset";
            string message = "This will undo changes, are you sure?";
            string accept = "Yes";
            string cancel = "No";

            bool checker = await DisplayAlert(title, message, accept, cancel);
            if (checker)
            {
                FillOrderForm();
            }

        }

        public async Task validateUpdate()
        {
            string title = "Update";
            string message = "Continuing will save changes, are you sure?";
            string accept = "Yes";
            string cancel = "No";
            FillOrderObject();
            if (Role == "Driver" && orderModel.Order.PackerId != 0)
            {
                bool checker = await DisplayAlert(title, message, accept, cancel);
                if (checker)
                {
                    Task check = orderModel.pushOrderAsync();
                    FillOrderForm();
                }
            }
            else
            {
                await DisplayAlert(title, "The order has not been packed yet.", "Understood");

            }


        }





    }  // partial class

}//namespace