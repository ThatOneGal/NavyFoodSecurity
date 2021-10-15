using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using NFA.Services;
using ZXing.Mobile;
using Xamarin.Forms;

[assembly: Dependency(typeof(NFA.Droid.Services.IQRScanningService))]

namespace NFA.Droid.Services
{
    class IQRScanningService
    {
        public class QrScanningService : IQRScanningService
        {
            public async Task<string> ScanAsync()
            {
                var optionsDefault = new MobileBarcodeScanningOptions();
                var optionsCustom = new MobileBarcodeScanningOptions();

                var scanner = new MobileBarcodeScanner()
                {
                    TopText = "Scan the QR Code",
                    BottomText = "Please Wait",
                };

                var scanResult = await scanner.Scan(optionsCustom);
                return scanResult.Text;
            }
        }
    }
}