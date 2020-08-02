﻿using AutoMapper;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VotadorWeb.ViewModels;

namespace VotadorWeb.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Funcionario, FuncionarioViewModel>();
            CreateMap<Recurso, RecursoViewModel>();
            CreateMap<RegistroVotacao, RegistroVotacaoViewModel>();
        }
    }
}
