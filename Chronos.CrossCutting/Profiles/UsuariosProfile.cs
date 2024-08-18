using AutoMapper;
using Chronos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronos_CrossCutting.Profiles
{
    public class UsuariosProfile : Profile
    {
        public UsuariosProfile()
        {
            CreateMap<Usuario, UsuarioExterno>();
            CreateMap<UsuarioExterno, Usuario>();
            CreateMap<Usuario, UsuarioInterno>();
            CreateMap<UsuarioInterno, Usuario>();
        }
    }
}
