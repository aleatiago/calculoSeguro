﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using teste.Models;

namespace teste.Shared
{
    public interface IContext : IDisposable
    {

        DbSet<CalculoSeguroVeiculo> CalculoSeguroVeiculo { get; }
        DatabaseFacade Database { get; }
        DbSet<T> DbSet<T>() where T : class;
        Task<int> CommitAsync();
        int Commit();
    }
}
