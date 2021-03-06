﻿using ApplicationApp.Interfaces.Generics;
using Entities.Entity;
using System.Threading.Tasks;

namespace ApplicationApp.Interfaces
{
    public interface IStockApp : IGenericApp<Stock>
    {
        Task AddStock(Stock stock);
        Task UpdateStock(Stock stock);
        Task<Stock> GetById(int id);
    }
}
