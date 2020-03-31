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
    public class PostService : AsyncService<Post, PostAddDto, PostEditDto, PostGetDto>, IPostService<PostAddDto, PostEditDto, PostGetDto>
    {
        public PostService(IPostRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
