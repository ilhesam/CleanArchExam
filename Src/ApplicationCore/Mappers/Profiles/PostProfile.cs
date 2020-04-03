using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.ViewModels.DataTransferObjects;
using AutoMapper;
using Domain.Entities;

namespace ApplicationCore.Mappers.Profiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<Post, PostGetDto>();

            CreateMap<Post, PostEditDto>();

            CreateMap<PostAddDto, Post>();

            CreateMap<PostEditDto, Post>();
        }
    }
}
