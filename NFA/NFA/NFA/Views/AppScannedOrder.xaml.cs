using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFA.Models;
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

        public string Role = Preferences.Get("Role", "");
        int UserId = int.Parse(Preferences.Get("Local_Id", "0"));

        public AppScannedOrder(string orderId)
        {
            InitializeComponent();
            Console.WriteLine(Role);
            Task asyncaa = Populate(orderId);


        }


        /// <summary>
        /// Fills the Model data based off the order id being retrieved from the dashboard
        /// </summary>
        /// <param name="ordId"></param>
        /// <returns></returns>
        public async Task Populate(string ordId)
        {
            orderModel = new AppOrderModel();

            await orderModel.getOrderAsync(ordId);
            FillOrderForm();



            await orderModel.getNameForId();

            Lb_LocationId.Text = orderModel.LocationName;
            Lb_StatusId.Text = orderModel.StatusName;

        }

        public async Task PopulateName()
        {
            await orderModel.getNameForId();

        }
        /// <summary>
        /// matches the data from the view model Order into the view
        /// </summary>
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
            Lb_PackerId.Text = orderModel.Order.PackerId.ToString();
            Lb_DriverId.Text = orderModel.Order.DriverId.ToString();
            Et_Content.Text = orderModel.Order.Content;
            Et_NotesStorage.Text = orderModel.Order.NotesStorage;
            Et_NotesNotesPreparation.Text = orderModel.Order.NotesPreparation;

        }


        /// <summary>
        /// returns the data placed in the view back into the Model, ready for saving
        ///
        /// </summary>
        public void FillOrderObject()
        {

            orderModel.Order.Content = Et_Content.Text;
   
            orderModel.Order.PackageQty = Et_PackageQty.Text;
            orderModel.Order.NotesStorage = Et_NotesStorage.Text;
            orderModel.Order.NotesPreparation = Et_NotesNotesPreparation.Text;

            orderModel.Order.PackerId = UserId;
            orderModel.Order.DriverId = UserId;

            // placeholder awaiting user role application
            //if user role is packer shows update packeddate
            if (Role == "Packer")
            {
                orderModel.Order.PackerId = UserId;
                orderModel.Order.OrderPacked = DateTime.Now;
            }

            if (Role == "Driver")
            {
                orderModel.Order.DriverId = UserId;
                orderModel.Order.OrderShipped = DateTime.Now;
            }

        }

        private void Btn_Update_Clicked(object sender, EventArgs e)
        {

            Task updater = validateUpdate();
        }

        private async void Btn_Reset_Clicked(object sender, EventArgs e)
        {

            await validatedReset();

        }

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
                Lb_LocationId.Text = orderModel.LocationName;
                Lb_StatusId.Text = orderModel.StatusName;
            }

        }

        public async Task validateUpdate()
        {
            string title = "Update";
            string message = "Continuing will save changes, are you sure?";
            string accept = "Yes";
            string cancel = "No";
            bool checker = await DisplayAlert(title, message, accept, cancel);
            if (checker)
            {

                FillOrderObject();

                await orderModel.pushOrderAsync();



            }
        }






    }  // partial class




}//namespace