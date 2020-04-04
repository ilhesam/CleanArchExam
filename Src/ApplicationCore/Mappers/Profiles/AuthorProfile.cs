using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Mappers.Resolvers;
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

            CreateMap<AuthorAddDto, Author>()
                .ForMember(dest => dest.Password, opt => opt.MapFrom<PasswordResolver<AuthorAddDto, Author>>());

            CreateMap<AuthorEditDto, Author>();
        }
    }
}
