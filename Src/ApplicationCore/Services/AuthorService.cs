using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using ApplicationCore.Security;
using ApplicationCore.ViewModels.DataTransferObjects;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace ApplicationCore.Services
{
    public class AuthorService : AsyncService<Author, AuthorAddDto, AuthorEditDto, AuthorGetDto>, IAuthorService<AuthorAddDto, AuthorEditDto, AuthorGetDto>
    {
        public AuthorService(IAuthorRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public virtual async Task<bool> ExistsAsync(AuthorLoginDto authorLoginDto) =>
            await Repository.ExistsAsync(pre =>
                pre.EmailAddress == authorLoginDto.EmailAddress
                && pre.Password == authorLoginDto.Password.EncodePasswordMd5());
    }
}
