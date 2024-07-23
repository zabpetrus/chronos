using Chronos.Domain.Entities;
using Chronos.Domain.Entities._Base.Main;
using Chronos.Domain.Interfaces.Repository;
using Chronos.Infraestructure.Context;
using Chronos.Infraestructure.Repository._Base;
using Chronos.Infraestructure.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronos.Infraestructure.Repository
{
    public class EnderecoRepository : RepositoryBase<Endereco, Entity>, IEnderecoRepository
    {
        public EnderecoRepository(ApplicationDbContext context, ITokenService tokenService) : base(context, tokenService)
        {
        }
    }
}
