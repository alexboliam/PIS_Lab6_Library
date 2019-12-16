using AutoMapper;
using BLL.Interfaces;
using BLL.Services;
using DAL.Interfaces;
using DAL.UnitsOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PL.Extentions
{
    public static class ServiceExtensions
    {
        public static void ConfigureUnitOfWork(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["libraryConnection:connectionString"];
            services.AddScoped<IUnitOfWork, UnitOfWork>(ServiceProvider =>
            {
                return new UnitOfWork(connectionString);
            });

        }
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
        }
        public static void ConfigureBLLServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentsService, StudentsService>();
            services.AddScoped<IBooksService, BooksService>();
            services.AddScoped<ILibraryCardsService, LibraryCardsService>();
            services.AddScoped<IAuthorsService, AuthorsService>();
        }



        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }
        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }

    }
}
