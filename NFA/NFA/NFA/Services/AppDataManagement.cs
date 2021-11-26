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


        public async Task UpdateItemAsync(Order item)
        {


            //var oldItem = Order.Where((Order arg) => arg.Id == item.Id).FirstOrDefault();
            //items.Remove(oldItem);
            //items.Add(item);

            string baseLink = "https://pacific-spire-38129.herokuapp.com/api/Orders/";
            //string apiindex = apiLink + item.Value<Order>("id");
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
            
           /* Dictionary<string, string> values = new Dictionary<string, string>()
            {
               

                { "CustomerId"       ,item.CustomerId.ToString()},
                {"LocationId"        ,item.LocationId.ToString()    },
                {"StatusId"          ,item.StatusId.ToString()   },
                {"OrderDate"         ,item.OrderDate.ToString() },
                {"OrderShipped"      ,item.OrderShipped.ToString()  },
                {"OrderPacked"       ,item.OrderPacked.ToString()  },
                {"PackerId"          ,item.PackerId.ToString()},
                {"DriverId"          ,item.DriverId.ToString()},
                {"PackageQty"           ,item.PackageQty},
                {"Content"        ,item.Content},
                {"NotesStorage"      ,item.NotesStorage},
                {"NotesPreparation"  ,item.NotesPreparation},
            };*/
            //FormUrlEncodedContent form = new FormUrlEncodedContent(values);
            
            //form.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");


            //client setup

            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
      



            //client.DefaultRequestHeaders.Accept.Add(MediaTypeWithQualityHeaderValue("application/json"));

            //order data update
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            //HttpContent cont = new StringContent(json);

            //HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
            //MultipartFormDataContent form = new MultipartFormDataContent();
            //form.Add(new StringContent("_method"), "PUT");
            //form.Add(new StringContent(item.CustomerId.ToString()), "CustomerId");
            //form.Add(new StringContent(item.LocationId.ToString()), "LocationId");
            //form.Add(new StringContent(item.StatusId.ToString()), "StatusId");
            //form.Add(new StringContent(item.OrderDate.ToString()), "OrderDate");
            //form.Add(new StringContent(item.OrderShipped.ToString()), "OrderShipped");
            //form.Add(new StringContent(item.OrderShipped.ToString()), "OrderPacked");
            //form.Add(new StringContent(item.PackageQty), "PackageQty");
            //form.Add(new StringContent(item.PackerId.ToString()), "PackerId");
            //form.Add(new StringContent(item.DriverId.ToString()), "DriverId");
            //form.Add(new StringContent(item.Content), "Content");
            //form.Add(new StringContent(item.NotesStorage), "NotesStorage");
            //form.Add(new StringContent(item.NotesPreparation), "NotesPreparation");

            var response = await client.PutAsync(apiindex, content);
            //var response = await client.PutAsJsonAsync(apiindex, form);
            // var response = await client.PutAsJsonAsync(apiindex, cont);
            //var response = await client.PutAsync(apiindex, form);


            //response.EnsureSuccessStatusCode();

            Console.WriteLine("___________________________________________");
            Console.WriteLine(await response.Content.ReadAsStringAsync());
            Console.WriteLine("___________________________________________");
            //httpRequestMessage = await client.PostAsJsonAsync(apiLink, item).ConfigureAwait(false);



            //return await Task.FromResult(true);

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

            }
            catch (Exception e)
            {
                Console.WriteLine("\nThe following Exception was raised : {0}", e.Message);

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