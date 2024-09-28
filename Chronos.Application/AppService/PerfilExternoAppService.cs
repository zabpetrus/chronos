using AutoMapper;
using Chronos.Application.AppService._Base;
using Chronos.Application.Interfaces;
using Chronos.Application.ViewModel;
using Chronos.Domain.Entities;
using Chronos.Domain.Interfaces.Services;
using Chronos.Domain.Interfaces.Services._Base;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronos.Application.AppService
{
    public class PerfilExternoAppService : AppServiceBase<PerfilExternoViewModel, PerfilExterno>, IPerfilExternoAppService
    {
        private readonly IPerfilExternoService _perfilExternoService;
        public PerfilExternoAppService(IPerfilExternoService serviceBase, IMapper mapper, ILogger<AppServiceBase<PerfilExternoViewModel, PerfilExterno>> logger) : base(serviceBase, mapper, logger)
        {
            _perfilExternoService = serviceBase;
        }
    }
}
