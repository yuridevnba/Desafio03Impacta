using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ControleVendas.Models;

namespace ControleVendas.Data
{
    public class ControleVendasContext : DbContext
    {
        public ControleVendasContext (DbContextOptions<ControleVendasContext> options)
            : base(options)
        {
        }

        public DbSet<ControleVendas.Models.Funcionario> Funcionario { get; set; } = default!;
        public DbSet<ControleVendas.Models.Adm> Adm { get; set; } = default!;
        public DbSet<ControleVendas.Models.Produto> Produto { get; set; } = default!;
        public DbSet<ControleVendas.Models.Vendas> Vendas { get; set; } = default!;
    }
}
