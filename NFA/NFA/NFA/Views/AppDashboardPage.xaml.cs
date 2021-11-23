using NFA.Services;
using System;
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
            AppDataManagement ADM = new AppDataManagement();

            Console.WriteLine("________________________________________");
            Console.WriteLine(result.Text);
            Console.WriteLine("________________________________________");
            try
            {
                string ender = "Orders/" + result.Text;
                scanView.IsAnalyzing = result == null;
                bool responsecheck = await ADM.GetResponseCode(ender);
                //validate qr code
                if (responsecheck)
                //if (result.BarcodeFormat == BarcodeFormat.QR_CODE) << original code
                //if (result.BarcodeFormat == BarcodeFormat.QR_CODE && result.Text.Contains("NFA"))
                {
                    //scan success

                    //await Shell.Current.GoToAsync($"{nameof(AppScannedOrder)}?{nameof(AppOrderModel.OrderId)}={result.Text}");

                    await Navigation.PushModalAsync(new NavigationPage(new AppScannedOrder(result.Text)));
                    //await Navigation.PushModalAsync(new NavigationPage(new AppScannedOrder(result.Text)));

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
                Console.WriteLine("________________________________________");
                Console.WriteLine(e);
                Console.WriteLine("________________________________________");

            }
        }


        protected override void OnAppearing()
        {
            scanView.IsAnalyzing = true;
            result = null;
        }
        protected override void OnDisappearing()
        {
            scanView.IsAnalyzing = false;
            result = null;
        }

    }
}