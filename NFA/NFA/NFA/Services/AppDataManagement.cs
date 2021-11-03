using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NFA.Models;

namespace NFA.Services
{
    public class AppDataManagement : IAppDataStore<Item>, IGetApi
    {

        public AppDataManagement()
        {

        }




        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }


        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
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