using NFA.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NFA.Services
{
    interface IGetApi
    {
        Task<string> GetApiLocationNameAsync(int locationId); // note: no async here
        Task<string> GetApiStatusNameAsync(int statusId); // note: no async here
        Task<bool> GetApiUserAsync(string userId); // note: no async here
        Task<List<UserRole>> GetApiUserRoleListAsync(); // note: no async here

    }
}
