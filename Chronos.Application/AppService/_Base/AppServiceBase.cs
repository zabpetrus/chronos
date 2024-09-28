using AutoMapper;
using Chronos.Application.Interfaces._Base;
using Chronos.Domain.Interfaces.Services._Base;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Chronos.Application.AppService._Base
{
    /// <summary>
    /// Classe base para serviços de aplicação, fornecendo operações CRUD genéricas.
    /// </summary>
    /// <typeparam name="T"> Uma ViewModel </typeparam>
    /// <typeparam name="P"> Entidade do Dominio correspondente </typeparam>
    public class AppServiceBase<T, P> : IAppServiceBase<T> where T : class where P : class
    {
        private readonly IServiceBase<P> _serviceBase;
        private readonly IMapper _mapper;
        private readonly ILogger<AppServiceBase<T, P>> _logger;

        public AppServiceBase(IServiceBase<P> serviceBase, IMapper mapper, ILogger<AppServiceBase<T, P>> logger)
        {
            _serviceBase = serviceBase;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Cria um novo modelo.
        /// </summary>
        /// <param name="model">Modelo a ser criado.</param>
        /// <returns>Modelo criado.</returns>
        public T Create(T model)
        {
            try
            {
                _logger.LogInformation("Iniciando criação de um novo modelo.");

                P entity = _mapper.Map<P>(model);
                P createdEntity = _serviceBase.Create(entity);

                if (createdEntity == null)
                {
                    _logger.LogWarning("Falha ao criar o modelo. Entidade retornada nula.");
                    return null;
                }

                T createdModel = _mapper.Map<T>(createdEntity);
                _logger.LogInformation("Modelo criado com sucesso.");
                return createdModel;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar o modelo.");
                throw;
            }
        }

        /// <summary>
        /// Exclui um modelo pelo ID.
        /// </summary>
        /// <param name="id">ID do modelo a ser excluído.</param>
        /// <returns>Resultado da operação de exclusão.</returns>
        public int DeleteById(long id)
        {
            try
            {
                _logger.LogInformation($"Iniciando exclusão do modelo com ID {id}.");
                int result = _serviceBase.DeleteById(id);

                if (result == 0)
                {
                    _logger.LogWarning($"Modelo com ID {id} não encontrado para exclusão.");
                }
                else
                {
                    _logger.LogInformation($"Modelo com ID {id} excluído com sucesso.");
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao excluir o modelo com ID {id}.");
                throw;
            }
        }

        /// <summary>
        /// Obtém todos os modelos.
        /// </summary>
        /// <returns>Lista de todos os modelos.</returns>
        public List<T> GetAll()
        {
            try
            {
                _logger.LogInformation("Iniciando busca de todos os modelos.");

                List<P> entities = _serviceBase.GetAll();

                if (entities == null || entities.Count == 0)
                {
                    _logger.LogWarning("Nenhum modelo encontrado.");
                    return new List<T>(); // Retorna uma lista vazia se não houver entidades.
                }

                List<T> models = _mapper.Map<List<T>>(entities);
                _logger.LogInformation($"{models.Count} modelos encontrados com sucesso.");
                return models;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar todos os modelos.");
                throw;
            }
        }

        /// <summary>
        /// Obtém um modelo pelo ID.
        /// </summary>
        /// <param name="id">ID do modelo a ser obtido.</param>
        /// <returns>Modelo encontrado.</returns>
        public T GetById(long id)
        {
            try
            {
                _logger.LogInformation($"Iniciando busca do modelo com ID {id}.");

                P entity = _serviceBase.GetById(id);

                if (entity == null)
                {
                    _logger.LogWarning($"Modelo com ID {id} não encontrado.");
                    return null;
                }

                T model = _mapper.Map<T>(entity);
                _logger.LogInformation($"Modelo com ID {id} encontrado com sucesso.");
                return model;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao buscar o modelo com ID {id}.");
                throw;
            }
        }

        /// <summary>
        /// Atualiza um modelo existente.
        /// </summary>
        /// <param name="model">Modelo a ser atualizado.</param>
        /// <returns>Modelo atualizado.</returns>
        public T Update(T model)
        {
            try
            {
                _logger.LogInformation("Iniciando atualização do modelo.");

                P entity = _mapper.Map<P>(model);
                P updatedEntity = _serviceBase.Update(entity);

                if (updatedEntity == null)
                {
                    _logger.LogWarning("Falha ao atualizar o modelo. Entidade retornada nula.");
                    return null;
                }

                T updatedModel = _mapper.Map<T>(updatedEntity);
                _logger.LogInformation("Modelo atualizado com sucesso.");
                return updatedModel;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar o modelo.");
                throw;
            }
        }
    }
}
