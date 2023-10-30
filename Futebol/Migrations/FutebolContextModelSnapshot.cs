﻿// <auto-generated />
using System;
using Futebol.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Futebol.Migrations
{
    [DbContext(typeof(FutebolContext))]
    partial class FutebolContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Futebol.Models.CampeonatoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataFim");

                    b.Property<DateTime>("DataInicio");

                    b.Property<string>("Nome");

                    b.Property<string>("Tipo");

                    b.Property<int>("Valor");

                    b.HasKey("Id");

                    b.ToTable("Campeonato");
                });
#pragma warning restore 612, 618
        }
    }
}
