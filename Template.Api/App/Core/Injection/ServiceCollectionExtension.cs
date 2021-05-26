using Autofac;
using System.Reflection;
using System;
using System.IO;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Template.Api.Domain.Aggregates;
using Template.Api.Infrastructure.Data;

namespace Template.Api.App.Core.Injection {

    public static class ServiceCollectionExtensions 
    {
        public static void RegisterDependencies(this IServiceCollection services, IConfiguration configuration) {
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<INotesRepository, NotesRepository>();
        }
    }
}