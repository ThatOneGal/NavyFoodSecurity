using NFA.Models;
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
        AppProfileModel profileModel = new AppProfileModel();
        AppDataManagement ADM = new AppDataManagement();
        public string isLogged = Preferences.Get("Local_Id", "0");

        public AppProfilePage()
        {
            InitializeComponent();
            Title = "Profile";

            //Task asyncaa = Populate(isLogged);
            //Task userroles = PopUserRoles();

        }


        public async Task Populate(string id)
        {
            string ender = "Users/" + id;
            bool responsecheck = await ADM.GetResponseCode(ender);
            //profileModel = new AppProfileModel();
            if (responsecheck)
            {
                //var isLogged = Preferences.Get("Local_Id", "1");
                await profileModel.getUserAsync(id);
            }
            await profileModel.getUserRolesAsync();

        }



        public async Task PopUserRoles()
        {
            await profileModel.getUserRolesAsync();

            Pk_UserRole.ItemsSource = profileModel.roles;
            Pk_UserRole.ItemDisplayBinding = new Binding("RoleName");

            //sets the role based on the user settings
            foreach (UserRole item in profileModel.roles)
            {
                if (item.id == profileModel.User.UserRoleId)
                {
                    Preferences.Set("Role", item.RoleName);
                }
            }
        }

        public void updateRole()
        {
            UserRole role = (UserRole)Pk_UserRole.SelectedItem;
            profileModel.User.UserRoleId = role.id;

            Preferences.Set("Role", role.RoleName);
            Console.WriteLine("_____________________________________________________________________");
            Console.WriteLine(profileModel.User.UserRoleId);
            Console.WriteLine("_____________________________________________________________________");
            Console.WriteLine(role.id);
            Console.WriteLine(role.RoleName);
            Console.WriteLine("_____________________________________________________________________");


        }

        public async Task fill()
        {
            if (profileModel.User == null)
            {
                await Populate(isLogged);

            }
            if (Pk_UserRole.ItemsSource == null)
            {
                await PopUserRoles();
            }


            Lb_FirstName.Text = profileModel.User.firstName;

            Lb_LastName.Text = profileModel.User.lastName;

            Lb_Rank.Text = profileModel.User.rank;

            Lb_SerialNumber.Text = profileModel.User.serialnumber;

            Lb_Email.Text = profileModel.User.email;


            Pk_UserRole.SelectedItem = profileModel.roles.FirstOrDefault(u => u.id == profileModel.User.UserRoleId);

        }

        protected override async void OnAppearing()
        {
 
            Task a = fill();

        }

        private void Pk_UserRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateRole();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Preferences.Remove("Local_Id");
        }

        private void reload_Clicked(object sender, EventArgs e)
        {
            fill();
        }


    }
}