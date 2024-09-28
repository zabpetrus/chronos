using AutoMapper;
using Chronos.Application.ViewModel;
using Chronos.Domain.Entities;
using Chronos.Domain.Entities._Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronos_CrossCutting.Services
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // Definição dos mapeamentos aqui
            CreateMap<UsuarioExterno, UsuarioExternoViewModel>(); 
            CreateMap<UsuarioExternoViewModel, UsuarioExterno>(); 
            CreateMap<UsuarioInterno, UsuarioInternoViewModel>();
            CreateMap<UsuarioInternoViewModel, UsuarioInterno>();
            CreateMap<PerfilInternoViewModel, PerfilInterno>();
            CreateMap<PerfilInterno, PerfilInternoViewModel>();
            CreateMap<PerfilExternoViewModel, PerfilExterno>();
            CreateMap<PerfilExterno, PerfilExternoViewModel>();
        }

   
    }
}
