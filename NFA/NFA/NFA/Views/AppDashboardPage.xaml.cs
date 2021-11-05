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
            this.result = result;
            Device.BeginInvokeOnMainThread(ValidateCode);
        }

        public async void ValidateCode()
        {
            try
            {
                scanView.IsAnalyzing = result == null;

                //validate qr code
                if (result.BarcodeFormat == BarcodeFormat.QR_CODE)
                //if (result.BarcodeFormat == BarcodeFormat.QR_CODE && result.Text.Contains("NFA"))
                {
                    //scan success


                    await Navigation.PushModalAsync(new NavigationPage(new AppScannedOrder(result.Text)));
                }
                else
                {
                    //william - could do a try catch and parse the message to the failed page to show why it failed.
                    //scan failed
                    await Navigation.PushModalAsync(new NavigationPage(new AppScanFailed()));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        protected override void OnAppearing()
        {
            scanView.IsAnalyzing = true;
            result = null;
        }
    }
}