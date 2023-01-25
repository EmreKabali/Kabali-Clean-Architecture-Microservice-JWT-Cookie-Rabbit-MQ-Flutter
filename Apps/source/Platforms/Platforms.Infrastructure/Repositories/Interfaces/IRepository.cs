using Platforms.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Platforms.Infrastructure.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class, IEntity, new()
    {
        #region Get
        TEntity Get(Expression<Func<TEntity, bool>> filter = null);

        List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);
        #endregion

        #region Add
        TEntity Add(TEntity entity);

        Task<TEntity> AddAsync(TEntity entity);

        Task<List<TEntity>> AddListAsync(List<TEntity> entityList);
        #endregion

        #region Update
        TEntity Update(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);
        #endregion

        #region Delete
        void Delete(TEntity entity);

        Task DeleteAsync(TEntity entity);
        #endregion
    }
}
