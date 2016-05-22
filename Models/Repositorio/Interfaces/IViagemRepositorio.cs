using System.Collections.Generic;

namespace TheWorld.Models.Repositorio.Interfaces
{
    public interface IViagemRepositorio
    {
        IEnumerable<Viagem> GetTodasViagens();
        IEnumerable<Viagem> GetTodasViagensComParadas();
        void PostViagem(Viagem viagem);
        bool ExisteAlgumaViagem();
        void SalvarAlteracoes();
    }
}