using System;
using System.Collections.Generic;

namespace TheWorld.Models
{
    public class Viagem
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Criada { get; set; }
        public string NomeUsuario { get; set; }

        public ICollection<Parada> Paradas { get; set; }
    }
}