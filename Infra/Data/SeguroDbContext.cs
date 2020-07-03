using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using teste.Infra.Configurations;
using teste.Models;
using teste.Shared;

namespace teste.Infra.Data
{
    public class SeguroDbContext : DbContext, IContext
    {
        public SeguroDbContext(DbContextOptions<SeguroDbContext> options) : base(options) { }

        public DbSet<CalculoSeguroVeiculo> CalculoSeguroVeiculo { get { return this.Set<CalculoSeguroVeiculo>(); } }

        public int Commit()
        {
            return this.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return this.SaveChangesAsync();
        }

        public DbSet<T> DbSet<T>() where T : class
        {
            return this.DbSet<T>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CalculoSeguroVeiculoConfiguration());
        }
    }
}
