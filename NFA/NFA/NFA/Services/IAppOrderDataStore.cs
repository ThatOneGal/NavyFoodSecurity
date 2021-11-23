using System.Threading.Tasks;

namespace NFA.Services
{
    public interface IAppOrderDataStore<T>
    {
        Task UpdateItemAsync(T item);
        Task<T> GetItemAsync(string id);
        //Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}
