using LindseyQRScanner.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace LindseyQRScanner.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}