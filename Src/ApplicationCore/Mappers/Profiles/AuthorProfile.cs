using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.ViewModels.DataTransferObjects;
using AutoMapper;
using Domain.Entities;

namespace ApplicationCore.Mappers.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorGetDto>();

            CreateMap<Author, AuthorEditDto>();

            CreateMap<AuthorAddDto, Author>();

            CreateMap<AuthorEditDto, Author>();
        }
    }
}
