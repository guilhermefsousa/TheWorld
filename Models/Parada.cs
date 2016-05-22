using System;

namespace TheWorld.Models
{
    public class Parada
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public DateTime Chegada { get; set; }
        public int Ordem { get; set; }
    }
}