namespace CarBook.WebUI.Areas.Admin.Services.Interfaces
{
    public interface IApiAdminService<T>
    {
        Task<List<T>> GetListAsync(string url);
        Task<T> GetItemAsync(string url);
        Task<bool> CreateItemAsync(string url, T item);
        Task<bool> UpdateItemAsync(string url, T item);
        Task<bool> RemoveItemAsync(string url);
        Task<bool> GetSingleAsync(string url);
    }
}
