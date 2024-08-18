using AutoMapper;
using Chronos_CrossCutting.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronos_CrossCutting.Services
{
    public class AutoMapperProfiles
    {
        public static void RegisterProfiles(IMapperConfigurationExpression cfg)
        {
            cfg.AddProfile<UsuariosProfile>();
            cfg.AddProfile<PerfisProfile>(); 
        }
    }
}
