using CadastroSeriesEFilmes.Entidades;
using Microsoft.EntityFrameworkCore;

namespace CadastroSeriesEFilmes.Persistencia
{
  public class AppContext : DbContext
  {
    private static bool _bancoCriado = false;

    public AppContext()
    {
      /*if (!_bancoCriado)
      {
        _bancoCriado = true;
        Database.EnsureDeleted();
        Database.EnsureCreated();
      }*/
    }

    public DbSet<EntidadeBase> Entidades { get; set; }

    public DbSet<Filme> Filmes { get; set; }

    public DbSet<Serie> Series { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      => optionsBuilder.UseSqlite("Data Source=locadora.db");
  }
}