using AutoMapper;
using BLL.Interfaces;
using BLL.Services;
using DAL.Interfaces;
using DAL.UnitsOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;


namespace PL.Extentions
{
    public static class ServiceExtensions
    {
        public static void ConfigureUnitOfWork(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["libraryConnection:DefaultConnection"];
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

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Students' library API",
                    Version = "v1",
                    Description = "Web API designed to simplify interaction between libraries and students.",
                    Contact = new OpenApiContact
                    {
                        Name = "Bolshoi Oleksandr",
                        Email = "alexboliam@gmail.com",
                        Url = new Uri("https://t.me/boliam")
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

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
