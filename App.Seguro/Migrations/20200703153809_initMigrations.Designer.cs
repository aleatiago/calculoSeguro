﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;
using teste.Infra.Data;

namespace App.Seguro.Migrations
{
    [DbContext(typeof(SeguroDbContext))]
    [Migration("20200703153809_initMigrations")]
    partial class initMigrations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            modelBuilder.Entity("teste.Models.CalculoSeguroVeiculo", b =>
                {
                    b.Property<Guid>("IdCalculo")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataCalculo");

                    b.Property<double>("Lucro");

                    b.Property<double>("Margem");

                    b.Property<double>("PremioComercial");

                    b.Property<double>("PremioPuro");

                    b.Property<double>("TaxaRisco");

                    b.HasKey("IdCalculo");

                    b.ToTable("CalculoSeguroVeiculo");
                });
#pragma warning restore 612, 618
        }
    }
}
