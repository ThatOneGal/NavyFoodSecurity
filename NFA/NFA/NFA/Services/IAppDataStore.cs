﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NFA.Services
{
    public interface IAppDataStore<T>
    {
        Task<bool> UpdateItemAsync(T item);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}
