using AutoMapper;
using Business.Models;
using VotacaoAPI.ViewModels;

namespace VotacaoAPI.AudoMapperConfig
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