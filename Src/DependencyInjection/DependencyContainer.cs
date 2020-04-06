using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Interfaces;
using ApplicationCore.Mappers.Profiles;
using ApplicationCore.Services;
using ApplicationCore.Validators;
using ApplicationCore.ViewModels.DataTransferObjects;
using AutoMapper;
using Domain.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection
{
    public static class DependencyContainer
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration, IMvcBuilder builder)
        {
            services.AddDbContext<ApplicationDbContext>(opt =>
                opt.UseSqlServer(configuration.GetConnectionString("BlogDbConnection")));

            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<IPostService<PostAddDto, PostEditDto, PostGetDto>, PostService>();

            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IAuthorService<AuthorAddDto, AuthorEditDto, AuthorGetDto>, AuthorService>();

            services.AddAutoMapper();

            services.AddFluentValidation(builder);

            return services;
        }

        public static void AddAutoMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile(new PostProfile());
                config.AddProfile(new AuthorProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);
        }

        public static void AddFluentValidation(this IServiceCollection services, IMvcBuilder builder)
        {
            builder.AddFluentValidation();

            services.AddTransient<IValidator<PostAddDto>, PostAddDtoValidator>();
            services.AddTransient<IValidator<PostEditDto>, PostEditDtoValidator>();

            services.AddTransient<IValidator<AuthorAddDto>, AuthorAddDtoValidator>();
            services.AddTransient<IValidator<AuthorLoginDto>, AuthorLoginDtoValidator>();
        }
    }
}
