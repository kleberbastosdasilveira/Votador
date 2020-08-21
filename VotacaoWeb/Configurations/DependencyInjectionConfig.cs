using AutoMapper;
using Business.Interfaces;
using Business.Interfaces.IService;
using Business.Notificacoes;
using Business.Services;
using Date.Context;
using Date.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace VotacaoWeb.Configurations
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
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IRegistroVotacaoService, RegistroVotacaoService>();
            services.AddScoped<IRecursoService, RecursoService>();
            
            services.AddAutoMapper(typeof(Startup));
            return services;
        }
    }
}