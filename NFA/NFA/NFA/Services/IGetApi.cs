using NFA.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

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
