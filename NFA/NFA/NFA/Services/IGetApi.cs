using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NFA.Models;

namespace NFA.Services
{
    interface IGetApi
    {
        Task<bool> GetApiOrderAsync(string orderId); // note: no async here
        Task<bool> GetApiLocationAsync(string locationId); // note: no async here
        Task<bool> GetApiStatusAsync(string statusId); // note: no async here
        Task<bool> GetApiUserAsync(string userId); // note: no async here
        Task<List<UserRole>> GetApiUserRoleListAsync(); // note: no async here
        
    }
}
