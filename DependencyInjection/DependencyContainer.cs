using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Interfaces;
using ApplicationCore.Mappers.Profiles;
using ApplicationCore.Services;
using ApplicationCore.ViewModels.DataTransferObjects;
using AutoMapper;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection
{
    public static class DependencyContainer
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(opt =>
                opt.UseSqlServer(configuration.GetConnectionString("BlogDbConnection")));

            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<IPostService<PostAddDto, PostEditDto, PostGetDto>, PostService>();

            services.AddAutoMapper();

            return services;
        }

        public static void AddAutoMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile(new PostProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}
