using NFA.Models;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace NFA.ViewModels
{
    public class AppProfileModel : BaseViewModel
    {
        public AppProfileModel()
        {
            Title = "Profile";
        }

        public User User { get; set; }


        public async Task getUserAsync(string id = null)
        {
            try
            {
                User = await ADM.GetUserAsync(id);


            }

            catch (Exception ex)
            {
                //= DisplayAlert("Error", ex.ToString(), "Confirm");
                Console.WriteLine(ex);
            }


        }

    }
}