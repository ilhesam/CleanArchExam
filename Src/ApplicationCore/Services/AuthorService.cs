using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Interfaces;
using ApplicationCore.ViewModels.DataTransferObjects;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace ApplicationCore.Services
{
    public class AuthorService : AsyncService<Author, AuthorAddDto, AuthorEditDto, AuthorGetDto>, IAuthorService<AuthorAddDto, AuthorEditDto, AuthorGetDto>
    {
        public AuthorService(IAsyncRepository<Author> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
