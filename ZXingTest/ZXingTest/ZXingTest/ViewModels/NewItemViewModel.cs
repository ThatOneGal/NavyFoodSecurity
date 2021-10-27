using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using ZXingTest.Models;
using ZXing.Mobile;

namespace ZXingTest.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string text;
        private string description;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            Read = new Command(ReaderAsync);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private async void ReaderAsync()
        {

            var scanner = new MobileBarcodeScanner();
            var options = new MobileBarcodeScanningOptions
            {
                TryHarder = true,
                AutoRotate = false,
                UseFrontCameraIfAvailable = false
            };


            
            var result = await scanner.Scan(options);
            
            

            if (result != null)
            {
                Console.WriteLine("Scanned Barcode: " + result.Text);
                text = result.Text;
            }
        }


        //private async void BtnScanQR_Clicked(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        var options = new MobileBarcodeScanningOptions
        //        {
        //            AutoRotate = false,
        //            UseFrontCameraIfAvailable = false,
        //            TryHarder = true
        //        };

        //        var overlay = new ZXingDefaultOverlay
        //        {
        //            TopText = "Please scan QR code",
        //            BottomText = "Align the QR code within the frame"
        //        };

        //        var QRScanner = new ZXingScannerPage(options, overlay);

        //        await Navigation.PushModalAsync(QRScanner);

        //        QRScanner.OnScanResult += (result) =>
        //        {
        //            // Stop scanning
        //            QRScanner.IsScanning = false;

        //            // Pop the page and show the result
        //            Device.BeginInvokeOnMainThread(() =>
        //            {
        //                Navigation.PopModalAsync(true);
        //                strAccessToken.Text = result.Text.ToUpper().Trim();
        //                //DisplayAlert("Scanned Barcode", result.Text, "OK");
        //            });

        //        };

        //    }
        //    catch (Exception ex)
        //    {
        //        GlobalScript.SeptemberDebugMessages("ERROR", "BtnScanQR_Clicked", "Opening ZXing Failed: " + ex);
        //    }
        //}


        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(text)
                && !String.IsNullOrWhiteSpace(description);
        }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public Command SaveCommand { get; }
        public Command Read { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Text = Text,
                Description = Description
            };

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
