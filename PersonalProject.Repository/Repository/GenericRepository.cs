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

        public async Task<TEntity> GetByIdAsync(Guid id, bool isActive = true)
        {
            return await _entities.SingleOrDefaultAsync(s => s.Id == id && s.Status == isActive);
        }

        public async Task<List<TEntity>> AllAsync(bool isActive = true)
        {
            return await _entities.Where(s => s.Status == isActive).AsQueryable().ToListAsync();
        }

        public async Task<TEntity> FindByAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _entities.SingleOrDefaultAsync(predicate);
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _entities.FirstOrDefaultAsync(predicate);
        }

        public async Task<List<TEntity>> FilterByAsync(Expression<Func<TEntity, bool>> predicate, bool isActive = true)
        {
            return await _entities.Where(predicate).Where(s => s.Status == isActive).ToListAsync();
        }

        public async Task SaveAsync(TEntity entity)
        {
            await _entities.AddAsync(entity);
        }

        public TEntity Update(TEntity entity)
        {
            var entityEntry = _entities.Update(entity);
            return entityEntry.Entity;
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, bool isActive = true)
        {
            return await _entities.Where(predicate).Where(s => s.Status == isActive).CountAsync();
        }

        public void Delete(TEntity entity)
        {
            entity.SetStatus(false);
        }

        public async Task BulkAddAsync(IEnumerable<TEntity> entities)
        {
            try
            {
                using var transaction = await _dbContext.Database.BeginTransactionAsync();
                _entities.AddRange(entities);
                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Hata : " + ex.Message);
            }

        }
    }
}
