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
        AppProfileModel profileModel= new AppProfileModel();
        AppDataManagement ADM = new AppDataManagement();
        public AppProfilePage()
        {
            InitializeComponent();
            Title = "Profile";

            Task asyncaa = Populate("1");
            Task userroles = PopUserRoles();

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


            }
 
            
        }

        public async Task PopUserRoles()
        {
            await profileModel.getUserRolesAsync();
            fill();
        }

        public void updateRole()
        {
            UserRole role = (UserRole)Pk_UserRole.SelectedItem;
            profileModel.User.UserRoleId = role.id;
            if(role.RoleName=="Driver" || role.RoleName == "Packer")
            {
                Preferences.Set("Role", role.RoleName);
            }
            //Console.WriteLine("_____________________________________________________________________");
            //Console.WriteLine(profileModel.User.UserRoleId);
            //Console.WriteLine("_____________________________________________________________________");
            //Console.WriteLine(role.id);
            //Console.WriteLine(role.RoleName);
            //Console.WriteLine("_____________________________________________________________________");


        }

        public void fill()
        {
            
            Lb_FirstName.Text = profileModel.User.firstName;

            Lb_LastName.Text = profileModel.User.lastName;

            Lb_Rank.Text = profileModel.User.rank;

            Lb_SerialNumber.Text = profileModel.User.serialnumber;

            Lb_Email.Text = profileModel.User.email;

            Pk_UserRole.ItemsSource = profileModel.roles;
            Pk_UserRole.ItemDisplayBinding = new Binding("RoleName");
            Pk_UserRole.SelectedItem = profileModel.roles.FirstOrDefault(u => u.id == profileModel.User.UserRoleId);

        }

        private void Pk_UserRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateRole();
        }
    }
}