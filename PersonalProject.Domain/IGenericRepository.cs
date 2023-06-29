using PersonalProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProject.Domain
{
    public interface IGenericRepository<TEntity> where TEntity : Entity
    {
        Task SaveAsync(TEntity entity);
        TEntity Update(TEntity entity);
    }
}
