using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using NFA.Models;
using NFA.Views;

namespace NFA.ViewModels
{
    public class AppOrderModel : BaseViewModel
    {

        private Command loadItemsCommand;

        public ICommand LoadItemsCommand
        {
            get
            {
                if (loadItemsCommand == null)
                {
                    loadItemsCommand = new Command(LoadItems);
                }

                return loadItemsCommand;
            }
        }

        private void LoadItems()
        {
        }
    }
}
