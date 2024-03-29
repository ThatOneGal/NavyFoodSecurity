﻿using NFA.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NFA.Services;

namespace NFA.ViewModels
{
    public class AppProfileModel : BaseViewModel
    {
        LogUtils lu = new LogUtils();

        public AppProfileModel()
        {
            Title = "Profile";



        }

        public User User { get; set; }
        public List<UserRole> roles { get; set; }

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
                lu.Log(ex.ToString());
            }
        }

        public async Task getUserRolesAsync()
        {
            try
            {
                roles = await ADM.GetApiUserRoleListAsync();


            }

            catch (Exception ex)
            {
                //= DisplayAlert("Error", ex.ToString(), "Confirm");
                Console.WriteLine(ex);
                lu.Log(ex.ToString());
            }
        }



    }
}