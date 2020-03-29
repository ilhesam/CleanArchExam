using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.ViewModels.DataTransferObjects.Common;

namespace ApplicationCore.Interfaces
{
    public interface IAsyncService<in TEntityAddDto, in TEntityEditDto, TEntityGetDto> where TEntityAddDto : EntityAddDto where TEntityEditDto : EntityEditDto where TEntityGetDto : EntityGetDto
    {
        Task<TEntityGetDto> GetByIdAsync(int id);

        Task<TEntityGetDto> AddAsync(TEntityAddDto entityAddDto);

        Task UpdateAsync(int id, TEntityEditDto entityEditDto);

        Task DeleteAsync(int id);
    }
}
