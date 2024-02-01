using Finance.Domain.Interfaces.Repositories;
using Finance.Infra.Data.Date.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace Finance.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly DbContextOptions<FinanceDbContext> options;
        public RepositoryBase()
        {
            this.options = new DbContextOptions<FinanceDbContext>();
        }

        public async Task Add(TEntity obj)
        {
            using (var data = new FinanceDbContext(options))
            {
                await data.Set<TEntity>().AddRangeAsync(obj);
                await data.SaveChangesAsync();
            }
        }

        public async Task Delete(TEntity obj)
        {
            using (var data = new FinanceDbContext(options))
            {
                data.Set<TEntity>().Remove(obj);
                await data.SaveChangesAsync();
            }
        }

        public async Task<TEntity> GetEntityById(int Id)
        {
            using (var data = new FinanceDbContext(options))
            {
                return await data.Set<TEntity>().FindAsync(Id);
            }
        }

        public async Task<List<TEntity>> List()
        {
            using (var data = new FinanceDbContext(options))
            {
                return await data.Set<TEntity>().ToListAsync();
            }
        }

        public async Task Update(TEntity obj)
        {
            using (var data = new FinanceDbContext(options))
            {
                data.Set<TEntity>().Update(obj);
                await data.SaveChangesAsync();
            }
        }

        //Disposable
        #region Disposed https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);


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
