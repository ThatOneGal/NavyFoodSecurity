using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace NFA.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class AppScanFailed : ContentPage
    {
        public AppScanFailed()
        {
            InitializeComponent();
        }

        /// <summary>
        /// on button click, pop this page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TryAgainButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}