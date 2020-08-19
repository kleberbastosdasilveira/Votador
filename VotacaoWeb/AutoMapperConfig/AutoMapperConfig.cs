using AutoMapper;
using Business.Models;
using VotacaoWeb.ViewModels;

namespace VotacaoWeb.AutoMapperConfig
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Funcionario, FuncionarioViewModel>().ReverseMap();
            CreateMap<Recurso, RecursoViewModel>().ReverseMap();
            CreateMap<RegistroVotacao, RegistroVotacaoViewModel>().ReverseMap();
        }
    }
}