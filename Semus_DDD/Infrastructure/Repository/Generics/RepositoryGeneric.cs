using Domain.Interfaces.Generics;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Generics
{
    public class RepositoryGeneric<T> : IGeneric<T>, IDisposable where T : class
    {
        private readonly DbContextOptions<ContextBase> _OptionBuilder;

        public RepositoryGeneric()
        {
            _OptionBuilder = new DbContextOptions<ContextBase>();
        }

        #region Tasks Generics
        public async Task Add(T Object)
        {
            using ContextBase data = new ContextBase(_OptionBuilder);
            _ = await data.Set<T>().AddAsync(Object);
            _ = await data.SaveChangesAsync();
        }

        public async Task Delete(T Object)
        {
            using ContextBase data = new ContextBase(_OptionBuilder);
            _ = data.Set<T>().Remove(Object);
            _ = await data.SaveChangesAsync();
        }

        public async Task<T> GetEntityById(int Id)
        {
            using ContextBase data = new ContextBase(_OptionBuilder);
            return await data.Set<T>().FindAsync(Id);
        }

        public async Task<List<T>> List()
        {
            using ContextBase data = new ContextBase(_OptionBuilder);
            return await data.Set<T>().ToListAsync();
        }

        public async Task Update(T Object)
        {
            using ContextBase data = new ContextBase(_OptionBuilder);
            _ = data.Set<T>().Update(Object);
            _ = await data.SaveChangesAsync();
        }
        #endregion

        #region Disposed
        bool disposed = false;
        private readonly SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            disposed = true;
        }
        #endregion
    }
}
