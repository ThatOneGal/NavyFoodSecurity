using Newtonsoft.Json;
using NFA.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NFA.Services
{
    public class AppDataManagement : IAppOrderDataStore<Order>, IGetApi
    {

        public AppDataManagement()
        {

        }

        public List<Order> OrderList { get; set; }
        LogUtils lu = new LogUtils();


        public async Task UpdateItemAsync(Order item)
        {

            string baseLink = "https://pacific-spire-38129.herokuapp.com/api/Orders/";
            string apiindex = baseLink + item.id;
            Console.WriteLine(apiindex);
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
            };
            string json = JsonConvert.SerializeObject(item,settings);

            Console.WriteLine("_______________________________________________________");
            Console.WriteLine(json);
            Console.WriteLine("_______________________________________________________");


            HttpClient client = new HttpClient();
         
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");


            var response = await client.PutAsync(apiindex, content);


            Console.WriteLine("___________________________________________");
            Console.WriteLine(await response.Content.ReadAsStringAsync());
            Console.WriteLine("___________________________________________");

        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">order id</param>
        /// <returns>Order object from id</returns>
        public async Task<Order> GetItemAsync(string id)
        {


            string baseLink = "https://pacific-spire-38129.herokuapp.com/api/Orders/";
            string apiAddress = baseLink + id;

            var client = new HttpClient();
            var response = await client.GetAsync(apiAddress);
            var responseString = await response.Content.ReadAsStringAsync();
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,

            };
            Order order = JsonConvert.DeserializeObject<Order>(responseString, settings);
            Console.WriteLine(responseString);
            return order;

        }

        public async Task<User> GetUserAsync(string id)
        {
            string baseLink = "https://pacific-spire-38129.herokuapp.com/api/Users/";
            string apiAddress = baseLink + id;

            var client = new HttpClient();
            var response = await client.GetAsync(apiAddress);
            var responseString = await response.Content.ReadAsStringAsync();
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,

            };
            User order = JsonConvert.DeserializeObject<User>(responseString, settings);
            Console.WriteLine(responseString);
            return order;

        }


        /// <summary>
        /// Determines the link will be valid before continuing
        /// url is open ended for flexiblility 
        /// </summary>
        /// <param name="urlEnd">Ending string of api</param>
        /// <returns>if api response is OK</returns>
        public async Task<bool> GetResponseCode(string urlEnd)
        {
            string baseLink = "https://pacific-spire-38129.herokuapp.com/api/";
            bool statusCheck = false;
            try
            {
                // Creates an HttpWebRequest for the specified URL.
                HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(baseLink + urlEnd);
                // Sends the HttpWebRequest and waits for a response.
                HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
                if (myHttpWebResponse.StatusCode == HttpStatusCode.OK)
                {

                    statusCheck = true;
                }

                // Releases the resources of the response
                myHttpWebResponse.Close();
            }
            catch (WebException e)
            {
                Console.WriteLine("\r\nWebException Raised. The following error occurred : {0}", e.Status);
                lu.Log(e.ToString());

            }
            catch (Exception e)
            {
                Console.WriteLine("\nThe following Exception was raised : {0}", e.Message);
                lu.Log(e.ToString());

            }
            return await Task.FromResult(statusCheck);
        }



        public async Task<List<UserRole>> GetApiUserRoleListAsync()
        {
            List<UserRole> Roles = new List<UserRole>();

            string baseLink = "https://pacific-spire-38129.herokuapp.com/api/UserRoles";

            var client = new HttpClient();
            var response = await client.GetAsync(baseLink);
            var responseString = await response.Content.ReadAsStringAsync();

            Roles = JsonConvert.DeserializeObject<List<UserRole>>(responseString);


            return Roles;
        }   
        
        public async Task<List<Order>> GetOrderList()
        {
            List<Order> orders = new List<Order>();

            string baseLink = "https://pacific-spire-38129.herokuapp.com/api/Orders";

            var client = new HttpClient();
            var response = await client.GetAsync(baseLink);
            var responseString = await response.Content.ReadAsStringAsync();
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,

            };
            orders = JsonConvert.DeserializeObject<List<Order>>(responseString, settings);
            Console.WriteLine(responseString);
            OrderList = orders;
            bool check = OrderList == orders;
            return orders;
        }

        public async Task<string> GetApiLocationNameAsync(int locationId)
        {

            string baseLink = "https://pacific-spire-38129.herokuapp.com/api/";
            string apiAddress = baseLink + "Locations/" + locationId.ToString();

            var client = new HttpClient();
            var response = await client.GetAsync(apiAddress);
            var responseString = await response.Content.ReadAsStringAsync();
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,

            };
            Location item = JsonConvert.DeserializeObject<Location>(responseString, settings);
            Console.WriteLine(responseString);
            return item.locationName;
        }

        public async Task<string> GetApiStatusNameAsync(int statusId)
        {
            string baseLink = "https://pacific-spire-38129.herokuapp.com/api/";
            string apiAddress = baseLink + "Statuses/" + statusId.ToString();

            var client = new HttpClient();
            var response = await client.GetAsync(apiAddress);
            var responseString = await response.Content.ReadAsStringAsync();
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,

            };
            Status item = JsonConvert.DeserializeObject<Status>(responseString, settings);
            Console.WriteLine(responseString);
            return item.statusName;
        }

        public Task<bool> GetApiUserAsync(string userId)
        {
            throw new NotImplementedException();
        }
    }
}