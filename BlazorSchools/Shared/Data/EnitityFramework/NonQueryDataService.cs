using BlazorSchools.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorSchools.Shared.Data.EnitityFramework
{
    public class NonQueryDataService<T> where T : Common
    {
        private readonly SchoolDBContextFactory _contextFactory;

        public NonQueryDataService(SchoolDBContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<T> Create(T entity)
        {
            using SchoolDBContext context = _contextFactory.CreateDbContext();
            EntityEntry<T> createdResult = await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();

            return createdResult.Entity;
        }

        public async Task<T> CreateOrUpdateList(List<T> entity)
        {
            using SchoolDBContext context = _contextFactory.CreateDbContext();
            foreach (T t in entity)
            {
                 await context.Set<T>().AddAsync(t);
            }
            await context.SaveChangesAsync();
            return null;
        }

        public async Task<T> Update(int id, T entity)
        {
            using SchoolDBContext context = _contextFactory.CreateDbContext();
            entity.Id = id;

            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            using SchoolDBContext context = _contextFactory.CreateDbContext();
            T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();

            return true;
        }
    }
}