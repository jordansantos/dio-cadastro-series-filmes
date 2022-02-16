using CadastroSeriesEFilmes.Entidades;
using Microsoft.EntityFrameworkCore;

namespace CadastroSeriesEFilmes.Persistencia
{
  public class AppContext : DbContext
  {
    public DbSet<EntidadeBase> Entidades { get; set; }

    public DbSet<Filme> Filmes { get; set; }

    public DbSet<Serie> Series { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlite("Data Source=locadora.db");
    }
  }
}