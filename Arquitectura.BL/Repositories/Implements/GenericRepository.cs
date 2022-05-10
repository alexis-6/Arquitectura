using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;
using Arquitectura.BL.Data;

namespace Arquitectura.BL.Repositories.Implements
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ArquitecturaContext arquitecturaContext;

        public GenericRepository(ArquitecturaContext arquitecturaContext)
        {
            this.arquitecturaContext = arquitecturaContext;
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);

            if (entity == null)
                throw new Exception("The entity is null");

            arquitecturaContext.Set<TEntity>().Remove(entity);
            await arquitecturaContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await arquitecturaContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await arquitecturaContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            arquitecturaContext.Set<TEntity>().Add(entity);
            await arquitecturaContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            //arquitecturaContext.Entry(entity).State = EntityState.Modified;
            arquitecturaContext.Set<TEntity>().AddOrUpdate(entity);
            await arquitecturaContext.SaveChangesAsync();
            return entity;
        }
    }
}
