using NFA.Models;
using NFA.Views;
using System.Collections.Generic;
using Xamarin.Forms;

namespace NFA
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }
        public List<Order> OrderList { get; set; }


        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }



    }
}
