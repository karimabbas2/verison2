
using AppDomain;

namespace AppCore.Interfaces.GenaricInterface
{
    public interface IGenaricInterface<T, in TPrimareyKey> where T : class
    {
        public Task<List<T>> GetAllAsync();
        public Task<T> GetAsync(TPrimareyKey primareyKey);
        public Task InsertAsync(T t);
        public Task UpdateAsync(TPrimareyKey primareyKey, T t);
        public Task DeleteAsync(TPrimareyKey primareyKey);
        Task<T> GetFirstAsync();

    }
}