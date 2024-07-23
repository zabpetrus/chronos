using AutoMapper;
using Chronos.Domain.Entities;
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
            CreateMap<Perfis, PerfisInternos>();
            CreateMap<PerfisInternos, Perfis>();
            CreateMap<Perfis, PerfisExternos>();
            CreateMap<PerfisExternos, Perfis>();
        }
    }
}
