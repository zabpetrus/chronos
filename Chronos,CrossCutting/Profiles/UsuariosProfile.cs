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
            CreateMap<Usuario, UsuariosExternos>();
            CreateMap<UsuariosExternos, Usuario>();
            CreateMap<Usuario, UsuariosInternos>();
            CreateMap<UsuariosInternos, Usuario>();
        }
    }
}
