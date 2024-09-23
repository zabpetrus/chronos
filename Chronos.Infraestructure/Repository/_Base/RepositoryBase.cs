using Chronos.Domain.Entities;
using Chronos.Domain.Entities._Base;
using Chronos.Domain.Interfaces.Repository._Base;
using Chronos.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chronos.Infraestructure.Repository._Base
{
    /// <summary>
    /// Classe base para repositórios, fornecendo operações CRUD genéricas.
    /// </summary>
    /// <typeparam name="TDatabaseContext">Tipo do contexto de banco de dados.</typeparam>
    /// <typeparam name="TEntity">Tipo da entidade a ser manipulada.</typeparam>
    public class RepositoryBase<TDatabaseContext, TEntity> : IRepositoryBase<TEntity>
        where TEntity : Entity
        where TDatabaseContext : DbContext
    {
        protected readonly TDatabaseContext _databaseContext;

        public RepositoryBase(TDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        /// <summary>
        /// Cria uma nova entidade.
        /// </summary>
        /// <param name="model">Entidade a ser criada.</param>
        /// <returns>Entidade criada.</returns>
        public virtual TEntity Create(TEntity model)
        {
            _databaseContext.Set<TEntity>().Add(model);
            _databaseContext.SaveChanges();
            return model;
        }

        /// <summary>
        /// Exclui uma entidade pelo ID.
        /// </summary>
        /// <param name="id">ID da entidade a ser excluída.</param>
        public virtual int DeleteById(long id)
        {
            if (id <= 0)
                throw new ArgumentException("ID inválido.", nameof(id));

            try
            {
                var entity = _databaseContext.Set<TEntity>().Find(id);
                if (entity == null){
                    throw new KeyNotFoundException($"Entidade com ID {id} não encontrada.");
                }


                if (_databaseContext.Set<TEntity>().Remove(entity) != null)
                {
                    _databaseContext.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
               
            }
            catch (DbUpdateException dbEx)
            {
                throw new InvalidOperationException("Erro ao tentar excluir a entidade no banco de dados.", dbEx);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao excluir a entidade: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Obtém todas as entidades.
        /// </summary>
        /// <returns>Lista de entidades.</returns>
        public virtual List<TEntity> GetAll()
        {
            return _databaseContext.Set<TEntity>().AsNoTracking().ToList();
        }

        /// <summary>
        /// Obtém uma entidade pelo ID.
        /// </summary>
        /// <param name="id">ID da entidade a ser obtida.</param>
        /// <returns>Entidade encontrada.</returns>
        public virtual TEntity GetById(long id)
        {
            return _databaseContext.Set<TEntity>().Find(id);
        }

        /// <summary>
        /// Atualiza uma entidade existente.
        /// </summary>
        /// <param name="model">Entidade a ser atualizada.</param>
        /// <returns>Entidade atualizada.</returns>
        public virtual TEntity Update(TEntity model)
        {
            try
            {
                var existingEntity = _databaseContext.Set<TEntity>().Find(model.Id);
                if (existingEntity == null)
                    throw new KeyNotFoundException($"Entidade com ID {model.Id} não encontrada.");

                var entityEntry = _databaseContext.Entry(existingEntity);
                var entityProperties = entityEntry.Properties.ToDictionary(p => p.Metadata.Name, p => p);

                // Atualiza apenas as propriedades que não são chaves
                foreach (var property in typeof(TEntity).GetProperties())
                {
                    if (entityProperties.ContainsKey(property.Name))
                    {
                        var propertyEntry = entityProperties[property.Name];
                        var propertyMetaData = propertyEntry.Metadata;

                        if (!propertyMetaData.IsPrimaryKey() && !propertyMetaData.IsForeignKey())
                        {
                            var newValue = property.GetValue(model);
                            propertyEntry.CurrentValue = newValue;
                            propertyEntry.IsModified = true;
                        }
                    }
                }

                bool saveFailed;
                do
                {
                    saveFailed = false;
                    try
                    {
                        _databaseContext.SaveChanges();
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        saveFailed = true;
                        var dbEntry = ex.Entries.Single();
                        var databaseEntry = dbEntry.GetDatabaseValues();
                        if (databaseEntry == null)
                            throw new InvalidOperationException("A entidade foi excluída por outro usuário.");

                        dbEntry.OriginalValues.SetValues(databaseEntry);
                    }
                } while (saveFailed);

                return existingEntity; // Retorna a entidade atualizada
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao atualizar a entidade: " + ex.Message, ex);
            }
        }

    }
}
