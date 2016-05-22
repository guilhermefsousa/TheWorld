using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using TheWorld.Models;
using TheWorld.Models.Contexto;

namespace TheWorld.Migrations
{
    [DbContext(typeof(MundoContext))]
    [Migration("20160522184320_InitialDataBase")]
    partial class InitialDataBase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TheWorld.Models.Parada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Chegada");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<string>("Nome");

                    b.Property<int>("Ordem");

                    b.Property<int?>("ViagemId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("TheWorld.Models.Viagem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Criada");

                    b.Property<string>("Nome");

                    b.Property<string>("NomeUsuario");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("TheWorld.Models.Parada", b =>
                {
                    b.HasOne("TheWorld.Models.Viagem")
                        .WithMany()
                        .HasForeignKey("ViagemId");
                });
        }
    }
}
