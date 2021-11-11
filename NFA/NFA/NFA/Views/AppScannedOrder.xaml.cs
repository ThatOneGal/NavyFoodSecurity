using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFA.Services;
using NFA.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NFA.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppScannedOrder : ContentPage
    {

        public AppScannedOrder(string orderId)
        {
            InitializeComponent();
            BindingContext = new AppOrderModel(orderId);
            
            
        }

    
    }  // partial class

}//namespace