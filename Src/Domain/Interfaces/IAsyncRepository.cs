using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Interfaces
{
    public interface IAsyncRepository<TEntity> where TEntity : Entity
    {
        Task<IEnumerable<TEntity>> ListAllAsync();

        Task<TEntity> GetById(int id);

        Task<TEntity> AddAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);

        Task DeleteAsync(int id);
    }
}
