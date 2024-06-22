using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.Interfaces.GenaricInterface;
using AppDomain;
using AppPersistence.Context;
using Microsoft.EntityFrameworkCore;

namespace AppPersistence.Repository
{
    public abstract class GenaricRepository<T, TPrimareyKey> : IGenaricInterface<T, TPrimareyKey> where T : class
    {
        private readonly MyDbContext _myDbContext;
        private readonly DbSet<T> entities;
        public GenaricRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
            entities = _myDbContext.Set<T>();
        }
        public async Task DeleteAsync(TPrimareyKey primareyKey)
        {
            var Entity = await entities.FindAsync(primareyKey) ?? throw new Exception();
            entities.Remove(Entity);
            await _myDbContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await entities.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetAsync(TPrimareyKey primareyKey)
        {
            return await entities.FindAsync(primareyKey);

            // return await entities.FindAsync(primareyKey) ?? throw new Exception();
        }

        public async Task<T> GetFirstAsync()
        {
            return await entities.AsNoTracking().SingleAsync();
        }

        public async Task InsertAsync(T t)
        {
            await entities.AddAsync(t);
            await _myDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TPrimareyKey primareyKey, T t)
        {
            entities.Entry(t).State = EntityState.Modified;
            await _myDbContext.SaveChangesAsync();
        }
    }
}