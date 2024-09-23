using AutoMapper;
using Chronos.Application.ViewModel;
using Chronos.Domain.Entities;
using Chronos_CrossCutting.Profiles;
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
        }

   
    }
}
