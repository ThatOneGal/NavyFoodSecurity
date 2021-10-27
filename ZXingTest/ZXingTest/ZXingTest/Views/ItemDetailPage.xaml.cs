using System.ComponentModel;
using Xamarin.Forms;
using ZXingTest.ViewModels;

namespace ZXingTest.Views
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