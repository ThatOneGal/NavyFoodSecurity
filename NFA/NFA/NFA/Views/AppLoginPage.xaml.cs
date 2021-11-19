using NFA.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NFA.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppLoginPage : ContentPage
    {
        AppDataManagement ADM = new AppDataManagement();

        public AppLoginPage()
        {
            InitializeComponent(); 
        }

        private async void Bt_Login_Clicked(object sender, EventArgs e)
        {
            await Validate();
        }

        public async Task Validate()
        {
            //Et_Tester.Text
            //Et_Email
            //Et_Password
            string ender = "Users/" + Et_Tester.Text;
            bool responsecheck = await ADM.GetResponseCode(ender);
            await DisplayAlert("Login", "Logging in", "OK");

            if (responsecheck)
            {
                Preferences.Set("Local_Id", Et_Tester.Text);
                await Navigation.PopToRootAsync();
            }
            else
            {
                //william - could do a try catch and parse the message to the failed page to show why it failed.
                //scan failed
                await Navigation.PushModalAsync(new NavigationPage(new AppScanFailed()));
            }
        }

    }
}