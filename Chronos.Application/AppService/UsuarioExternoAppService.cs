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
    public class UsuarioExternoAppService : AppServiceBase<UsuarioExternoViewModel, UsuarioExterno>, IUsuarioExternoAppService
    {
          private readonly IUsuarioExternoService _usuarioExternoService;

        public UsuarioExternoAppService(IUsuarioExternoService serviceBase, IMapper mapper, ILogger<AppServiceBase<UsuarioExternoViewModel, UsuarioExterno>> logger) : base(serviceBase, mapper, logger)
        {
            _usuarioExternoService = serviceBase;
        }
    }

}
