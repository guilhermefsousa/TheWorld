using System;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Logging;

namespace TheWorld.Models.Contexto
{
    public sealed class MundoContext : DbContext
    {
        public MundoContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Viagem> Viagens { get; set; }
        public DbSet<Parada> Paradas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connString = Startup.Configuracao["DataBase:MundoContextConnection"];

            optionsBuilder.UseSqlServer(connString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}