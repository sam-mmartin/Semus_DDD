﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationApp.Interfaces.Generics
{
    public interface IGenericApp<T> where T : class
    {
        Task Add(T Object);
        Task Update(T Object);
        Task Delete(T Object);
        Task<T> GetEntityById(int Id);
        Task<List<T>> List();
    }
}
