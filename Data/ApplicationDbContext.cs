using Estacionamento.Models;
using Microsoft.EntityFrameworkCore;

namespace Estacionamento.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<VeiculoModel> Veiculos { get; set; } 
        public DbSet<TabelaPrecoModel> TabelasPreco { get; set; }
    }
}
