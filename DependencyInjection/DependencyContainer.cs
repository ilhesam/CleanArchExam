using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using ApplicationCore.ViewModels.DataTransferObjects;
using AutoMapper;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddInfrastructure<TStartup>(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(opt =>
                opt.UseSqlServer(configuration.GetConnectionString("BlogDbConnection")));

            services.AddTransient<IPostService<PostAddDto, PostEditDto, PostGetDto>, PostService>();

            services.AddAutoMapper(typeof(TStartup));

            return services;
        }
    }
}
