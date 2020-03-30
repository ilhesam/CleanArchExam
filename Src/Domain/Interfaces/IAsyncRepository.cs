using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Interfaces
{
    public interface IAsyncRepository<TEntity> where TEntity : Entity
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> GetByIdAsync(int id);

        Task<TEntity> AddAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);

        Task DeleteAsync(int id);
    }
}
