using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.ViewModels.DataTransferObjects;

namespace ApplicationCore.Interfaces
{
    public interface IAuthorService<in TAuthorAddDto, TAuthorEditDto, TAuthorGetDto> : IAsyncService<TAuthorAddDto, TAuthorEditDto, TAuthorGetDto> where TAuthorAddDto : AuthorAddDto where TAuthorEditDto : AuthorEditDto where TAuthorGetDto : AuthorGetDto
    {
        Task<bool> ExistsAsync(AuthorLoginDto authorLoginDto);
    }
}
