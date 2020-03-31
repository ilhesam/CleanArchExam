using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.ViewModels.DataTransferObjects.Entities;
using AutoMapper;
using Domain.Entities;

namespace ApplicationCore.Mappers.Profiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<Post, PostGetDto>();

            CreateMap<PostAddDto, Post>();
        }
    }
}
