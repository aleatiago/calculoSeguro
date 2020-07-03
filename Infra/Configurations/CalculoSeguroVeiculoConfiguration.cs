using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using teste.Models;

namespace teste.Infra.Configurations
{
    public class CalculoSeguroVeiculoConfiguration : IEntityTypeConfiguration<CalculoSeguroVeiculo>
    {
        public void Configure(EntityTypeBuilder<CalculoSeguroVeiculo> builder)
        {
            builder.ToTable("CalculoSeguroVeiculo");

            builder.Property(x => x.IdCalculo).IsRequired();
            builder.Property(x => x.DataCalculo).IsRequired();
            builder.Property(x => x.Lucro).IsRequired();
            builder.Property(x => x.Margem).IsRequired();
            builder.Property(x => x.PremioComercial).IsRequired();
            builder.Property(x => x.PremioPuro).IsRequired();
            builder.Property(x => x.TaxaRisco).IsRequired();
            builder.Property(x => x.Marca_Modelo).IsRequired();
            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x => x.ValorVeiculo).IsRequired();
            builder.Property(x => x.CPF).IsRequired();
            builder.Property(x => x.Idade).IsRequired();
            

            builder.HasKey(x => x.IdCalculo);
        }
    }
}
