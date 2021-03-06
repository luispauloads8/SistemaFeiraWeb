using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ControleFeiraWeb.Models;

namespace ControleFeiraWeb.Data
{
    public class ControleFeiraWebContext : DbContext
    {
        public ControleFeiraWebContext (DbContextOptions<ControleFeiraWebContext> options)
            : base(options)
        {
        }

        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Lancamento> Lancamento { get; set; }


    }
}
