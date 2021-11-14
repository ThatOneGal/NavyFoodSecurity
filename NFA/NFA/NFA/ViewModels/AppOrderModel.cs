﻿using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using NFA.Models;
using NFA.Views;
using System.Threading.Tasks;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using NFA.Services;

namespace NFA.ViewModels
{

    public class AppOrderModel : BaseViewModel
    {
        public AppOrderModel()
        {

        }


        //* note-may not be needed
        //public Command loadOrderCommand { get; set; }

        public JObject PulledApi { get; set; } = null;

        public Order Order { get; set; }


        public AppOrderModel(Order order)
        {
            //loadOrderCommand = new Command(async () => await ExecuteLoadOrderCommand());


            Title = order.id.ToString();

            Order = order;


        }


        public async Task getOrderAsync(string id = null)
        {
            try
            {
                Order = await ADM.GetItemAsync(id);


            }

            catch (Exception ex)
            {
                //= DisplayAlert("Error", ex.ToString(), "Confirm");
                Console.WriteLine(ex);
            }


        }




    } // base view
} // namespace
