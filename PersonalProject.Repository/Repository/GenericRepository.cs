using Microsoft.EntityFrameworkCore;
using PersonalProject.Domain;
using PersonalProject.Domain.Entities;
using System.Linq.Expressions;

namespace PersonalProject.Repository.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Entity
    {
        protected readonly DbSet<TEntity> _entities;
        protected readonly DbContext _dbContext;

        protected GenericRepository(DbContext context)
        {
            _entities = context.Set<TEntity>();
            _dbContext = context;
        }
        public async Task SaveAsync(TEntity entity)
        {
            try
            {
                await _entities.AddAsync(entity);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public TEntity Update(TEntity entity)
        {
            try
            {

                var entityEntry = _entities.Update(entity);
                return entityEntry.Entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
