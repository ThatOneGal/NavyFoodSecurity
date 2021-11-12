﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NFA.Models;

namespace NFA.Services
{
    public class AppDataManagement : IAppOrderDataStore<Order>, IGetApi
    {

        public AppDataManagement()
        {
            
        }




        public async Task<bool> UpdateItemAsync(Order item)
        {


            //var oldItem = Order.Where((Order arg) => arg.Id == item.Id).FirstOrDefault();
            //items.Remove(oldItem);
            //items.Add(item);

            string baseLink = "https://pacific-spire-38129.herokuapp.com/";
            string apiLink = "api/Orders/";
            //string apiindex = apiLink + item.Value<Order>("id");
            string apiindex = apiLink + item.id;
            var json = JsonConvert.SerializeObject(item);

            var client = new HttpClient();

            //client setup
            client.BaseAddress = new Uri(baseLink);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            //order data update
            var content = new StringContent(json.ToString(), System.Text.Encoding.UTF8, "application/json");

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
            var response = await client.PostAsync(baseLink+apiindex,content);

            //httpRequestMessage = await client.PostAsJsonAsync(apiLink, item).ConfigureAwait(false);

            //httpRequestMessage = await client.PostAsync(apiAddress, json);


            return await Task.FromResult(true);

        }




        public async Task<Order> GetItemAsync(string id)
        {


            string baseLink = "https://pacific-spire-38129.herokuapp.com/api/Orders/";
            string apiAddress = baseLink + id;

            var client = new HttpClient();
            var response = await client.GetAsync(apiAddress);
            var responseString = await response.Content.ReadAsStringAsync();
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,

            };
            Order jsonorder = JsonConvert.DeserializeObject<Order>(responseString,settings);
            //var jsonorder = JsonConvert.DeserializeObject<JObject>(responseString, settings);
            //Order RequestedOrder = new Order();
            //RequestedOrder = jsonorder;
            Console.WriteLine(responseString);
            return jsonorder;


            // try catch snytax 


            /*
            var client = new HttpClient();
            //var response = await client.GetAsync("https://api.exchangeratesapi.io/latest?base=AUD&symbolsGBP");
            var response = await client.GetAsync("https://api.exchangeratesapi.io/latest?base=AUD");
            var responseString = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseString);

            var obj = JsonConvert.DeserializeObject<JObject>(responseString);

            var rates = obj.Value<JObject>("rates");
            //responselabel.Text = response.ToString();   
            ToRate = currency;
            ToRateFloat = rates.Value<float>(currency);
            */

            //return await Task.FromResult(RequestedOrder);

        }



        public Task<bool> GetApiOrderAsync(string orderId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetApiLocationAsync(string locationId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetApiStatusAsync(string statusId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetApiUserAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetApiUserRoleAsync(string userRoleId)
        {
            throw new NotImplementedException();
        }
    }
}