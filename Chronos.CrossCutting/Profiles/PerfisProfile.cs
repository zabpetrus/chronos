using AutoMapper;
using Chronos.Domain.Entities;
using Chronos.Domain.Entities._Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronos_CrossCutting.Profiles
{
    public class PerfisProfile : Profile
    {
        public PerfisProfile()
        {
            CreateMap<Perfil, PerfilInterno>();
            CreateMap<PerfilInterno, Perfil>();
            CreateMap<Perfil, PerfilExterno>();
            CreateMap<PerfilExterno, Perfil>();
        }
    }
}
