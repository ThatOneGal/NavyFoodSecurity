using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NFA.Models;

namespace NFA.Services
{
    public class DataManagement : IDataStore<Item>, IGetApi
    {

        public DataManagement()
        {

        }


        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
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