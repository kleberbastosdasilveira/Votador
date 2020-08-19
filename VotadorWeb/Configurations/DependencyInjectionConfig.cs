using AutoMapper;
using Business.Interfaces;
using Date.Context;
using Date.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace VotadorWeb.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();
            services.AddControllersWithViews();

            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
            services.AddScoped<IRecursoRepository, RecursoRepository>();
            services.AddScoped<IRegistroVotacaoRepository, RegistroVotacaoRepository>();

            services.AddAutoMapper(typeof(Startup));
            return services;
        }
    }
}