using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Logging;
using TheWorld.Models.Contexto;
using TheWorld.Models.Repositorio.Interfaces;

namespace TheWorld.Models.Repositorio
{
    public class ViagemRepositorio : IViagemRepositorio
    {
        private readonly MundoContext _context;
        private readonly ILogger<ParadaRepositorio> _logger;

        public ViagemRepositorio(MundoContext context, ILogger<ParadaRepositorio> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<Viagem> GetTodasViagens()
        {
            try
            {
                return _context.Viagens.OrderBy(v => v.Nome).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Não foi possivel buscar viagens no banco de dados", ex);
                return null;
            }
        }

        public IEnumerable<Viagem> GetTodasViagensComParadas()
        {
            try
            {
                return _context.Viagens.Include(v => v.Paradas).OrderBy(v => v.Nome).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Não foi possivel buscar viagens com paradas no banco de dados", ex);
                return null;
            }
        }

        public void PostViagem(Viagem viagem)
        {
            try
            {
                _context.Viagens.Add(viagem);
            }
            catch (Exception ex)
            {
                _logger.LogError("Não foi possivel inserir a viagem no banco de dados", ex);
            }
        }

        public bool ExisteAlgumaViagem()
        {
            try
            {
                return _context.Viagens.Any();
            }
            catch (Exception ex)
            {
                _logger.LogError("Não foi possivel verificar viagens no banco de dados", ex);
                return true;
            }
        }

        public void SalvarAlteracoes()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError("Não foi possivel salvar os dados no banco", ex);
            }
        }

    }
}