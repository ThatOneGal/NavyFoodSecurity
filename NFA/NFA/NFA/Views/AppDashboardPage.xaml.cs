using NFA.Models;
using NFA.Services;
using NFA.ViewModels;
using System;
using System.Collections.Generic;
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
        AppDataManagement ADM = new AppDataManagement();
        LogUtils lu = new LogUtils();

        public AppDashboardPage()
        {
            InitializeComponent();


        }

        /// <summary>
        /// validate the QRcode when a result is recieved
        /// </summary>
        /// <param name="result"></param>
        public void scanView_OnScanResult(Result result)
        {
            this.result = result;
            Device.BeginInvokeOnMainThread(ValidateCode);
        }

        /// <summary>
        /// on validate success, open order view. on validate fail, open scan fail view
        /// </summary>
        public async void ValidateCode()
        {
            Console.WriteLine("________________________________________");
            Console.WriteLine("scan results");
            Console.WriteLine(result.Text);
            Console.WriteLine("________________________________________");
            try
            {
                string ender = "Orders/" + result.Text;
                scanView.IsAnalyzing = result == null;
                bool responsecheck = await ADM.GetResponseCode(ender);

                //validate qr code
                if (responsecheck)
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
                Console.WriteLine("________________________________________");
                Console.WriteLine(e);
                lu.Log(e.ToString());
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