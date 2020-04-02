using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.ViewModels.DataTransferObjects.Common;

namespace ApplicationCore.Interfaces
{
    public interface IAsyncService<in TEntityAddDto, in TEntityEditDto, TEntityGetDto> where TEntityAddDto : EntityAddDto where TEntityEditDto : EntityEditDto where TEntityGetDto : EntityGetDto
    {
        Task<List<TEntityGetDto>> ListAllAsync();

        IQueryable<TEntityGetDto> GetAll();

        Task<TEntityGetDto> GetByIdAsync(int id);

        Task<TEntityGetDto> AddAsync(TEntityAddDto entityAddDto);

        Task UpdateAsync(int id, TEntityEditDto entityEditDto);

        Task DeleteAsync(int id);

        Task<bool> ExistsByIdAsync(int id);
    }
}
