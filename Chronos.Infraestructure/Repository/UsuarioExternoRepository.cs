using Chronos.Domain.Entities;
using Chronos.Domain.Interfaces.Repository;
using Chronos.Domain.Interfaces.Repository._Base;
using Chronos.Infraestructure.Context;
using Chronos.Infraestructure.Repository._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronos.Infraestructure.Repository
{
    public class UsuarioExternoRepository : RepositoryBase<ApplicationDbContext, UsuarioExterno>, IUsuarioExternoRepository
    {
        public UsuarioExternoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override UsuarioExterno Create(UsuarioExterno model)
        {
            try
            {
                // Adiciona a entidade ao DbContext
                var user = _databaseContext.Add(model).Entity;

                // Persiste a alteração no banco de dados
                _databaseContext.SaveChanges();

                // Retorna a entidade criada
                return user;
            }
            catch (Exception ex)
            {
                // Log de erro (opcional)
                // _logger.LogError(ex, "Erro ao criar o usuário externo");

                // Re-levanta a exceção para tratamento externo
                throw new Exception("Erro ao criar o usuário externo.", ex);
            }
        }
    }

}
