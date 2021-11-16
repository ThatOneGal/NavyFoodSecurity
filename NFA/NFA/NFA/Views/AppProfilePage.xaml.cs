using NFA.Services;
using NFA.ViewModels;
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
    public partial class AppProfilePage : ContentPage
    {
        AppProfileModel profileModel= new AppProfileModel();
        AppDataManagement ADM = new AppDataManagement();
        public AppProfilePage()
        {
            InitializeComponent();
            Title = "Profile";

            Task asyncaa = Populate("");

        }


        public async Task Populate(string id)
        {
            string ender = "Users/" + id;
            bool responsecheck = await ADM.GetResponseCode(ender);
            profileModel = new AppProfileModel();
            if (responsecheck)
            {
                var isLogged = Preferences.Get("Local_Id", "0");
                await profileModel.getUserAsync(id);
                fill();

            }
 
            
        }
        public void fill()
        {
            
            Lb_FirstName.Text = profileModel.User.firstName;
            Lb_LastName.Text = profileModel.User.lastName;
            Lb_Rank.Text = profileModel.User.rank;
            Lb_SerialNumber.Text = profileModel.User.serialnumber;
            Lb_Email.Text = profileModel.User.email;
            Lb_UserRole.Text = profileModel.User.UserRoleId.ToString();
        }


    }
}