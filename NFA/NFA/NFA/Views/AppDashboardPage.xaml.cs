using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing;

namespace NFA.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppDashboardPage : ContentPage
    {
        Result result = null;

        public AppDashboardPage()
        {
            InitializeComponent();
        }

        public void scanView_OnScanResult(Result result)
        {
<<<<<<< HEAD
            //when scanned
            scanView.Result = null;
            
            Device.BeginInvokeOnMainThread(async () =>
=======
            this.result = result;
            Device.BeginInvokeOnMainThread(test);



        }

        public async void test()
        {
            try
>>>>>>> 2bb0de5ce3c46e4aa930fbce07f28080e5e958db
            {
                if (result != null)
                {
                    scanView.IsAnalyzing = false;
                }
                else
                {
                    scanView.IsAnalyzing = true;
                }

                
                //validate qr code
                if (result.BarcodeFormat != BarcodeFormat.QR_CODE)
                {
                    //scan success

                    //result = null;
                    //scanView.IsAnalyzing = true;

                    //stop scanning and open AppScannedOrder to display order w/ confirmation + edit button

                    //if edited
                    //display edits on a new page w/ final confirmation

                }
                else
                {
                    await Navigation.PushModalAsync(new NavigationPage(new AppScanFailed()));
                    //result = null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }


        }

        //protected override bool OnBackButtonPressed()
        //{
        //    base.OnBackButtonPressed();
        //    scanView.IsScanning = true;

        //}

        protected override void OnAppearing()
        {

            scanView.IsAnalyzing = true;
            result = null;
            //base.OnAppearing();

        }
    }
}