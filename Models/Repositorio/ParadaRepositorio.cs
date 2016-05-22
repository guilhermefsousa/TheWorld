using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using TheWorld.Models.Contexto;
using TheWorld.Models.Repositorio.Interfaces;

namespace TheWorld.Models.Repositorio
{
    public class ParadaRepositorio : IParadaRepositorio
    {
        private readonly MundoContext _context;
        private readonly ILogger<ParadaRepositorio> _logger;

        public ParadaRepositorio(MundoContext context, ILogger<ParadaRepositorio> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void PostListaParadas(IEnumerable<Parada> paradas)
        {
            _context.Paradas.AddRange(paradas);
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