using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NFA.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : TabbedPage
    {

        public MainPage()
        {
            InitializeComponent();
            Start();
        }

        public void Start()
        {
            string user = Preferences.Get("Local_Id", "0");
            bool ischecking = Preferences.Get("LogOut", true);

            Console.WriteLine("________________________________________");

            Console.WriteLine(user);
            Console.WriteLine("________________________________________");

            Authenticate(user).Wait();
        }

        public async Task<bool> Authenticate(string usercheck)
        {
            string user = usercheck;
            bool isChecking = Preferences.Get("LogOut", true);

            if (user == "0")
            {
                await Navigation.PushModalAsync(new NavigationPage(new AppLoginPage()));
            }

            return isChecking;
        }



    }
}