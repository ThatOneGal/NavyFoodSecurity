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
        public AppDashboardPage()
        {
            InitializeComponent();
        }

        public void scanView_OnScanResult(Result result)
        {
            //when scanned

            Device.BeginInvokeOnMainThread(async () =>
            {
                /*popup*/ await DisplayAlert("Scanned result", "The qr code's text is " + result.Text + ".", "OK");

                //validate qr code
                //if qr code is invalid, display a popup/new page w/ confirmation
                //if qr code is valid, stop scanning and open AppScannedOrder to display order w/ confirmation + edit button
                //if edited, display edits on a new page w/ final confirmation
                //when confirmation is pressed, open dashboard again to scan a new code
            });
        }
    }
}