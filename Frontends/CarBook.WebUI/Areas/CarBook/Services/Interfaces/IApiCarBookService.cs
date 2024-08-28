﻿namespace CarBook.WebUI.Areas.CarBook.Services.Interfaces
{
    public interface IApiCarBookService<T>
    {
        Task<List<T>> GetListAsync(string url);
        Task<T> GetItemAsync(string url);
        Task<bool> CreateItemAsync(string url, T item);
        Task<bool> GetSingleAsync(string url);
    }
}
