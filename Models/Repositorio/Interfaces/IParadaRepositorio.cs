using System.Collections.Generic;

namespace TheWorld.Models.Repositorio.Interfaces
{
    public interface IParadaRepositorio
    {
        void PostListaParadas(IEnumerable<Parada> paradas);
        void SalvarAlteracoes();
    }
}