using Chronos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronos.Application.Tokens
{
    public interface IJwtTokenGenerator
    {
        TokenResult GenerateTokenForInternalUser(UsuarioInterno usuario);
        TokenResult GenerateTokenForExternalUser(UsuarioExterno usuario);
    }
}
