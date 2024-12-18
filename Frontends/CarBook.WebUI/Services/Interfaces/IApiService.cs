﻿namespace CarBook.WebUI.Services.Interfaces
{
    public interface IApiService<T>
    {
        Task<List<T>> GetListAsync(string url);
        Task<T> GetItemAsync(string url);
        Task<bool> CreateItemAsync(string url, T item);
        Task<bool> UpdateItemAsync(string url, T item);
        Task<bool> RemoveItemAsync(string url);
        Task<bool> GetSingleAsync(string url);
        Task GetEmpty();
    }
}
