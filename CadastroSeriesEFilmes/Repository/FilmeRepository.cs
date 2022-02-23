using System.Collections.Generic;
using System.Linq;
using CadastroSeriesEFilmes.Entidades;
using CadastroSeriesEFilmes.Interface;
using CadastroSeriesEFilmes.Persistencia;

namespace CadastroSeriesEFilmes.Repository
{
  public class FilmeRepository : IRepository<Filme>
  {
    public FilmeRepository() { }

    public List<Filme> BuscarTodos()
    {
      using (var _context = new AppContext())
      {
        return _context.Filmes.Where(f => f.IsExcluido == false).ToList();
      }
    }

    public Filme BuscarPeloId(int id)
    {
      using (var _context = new AppContext())
      {
        var filme = _context.Filmes.FirstOrDefault(f => f.Id == id && f.IsExcluido == false);

        return filme;
      }
    }

    public bool Atualizar(int id, Filme entity)
    {
      using (var _context = new AppContext())
      {
        var filme = this.BuscarPeloId(id);

        _context.Filmes.Update(filme);
        _context.SaveChanges();

        return true;
      }
    }

    public bool Deletar(int id)
    {
      using (var _context = new AppContext())
      {
        var filme = this.BuscarPeloId(id);
        filme.IsExcluido = true;

        _context.Filmes.Update(filme);
        _context.SaveChanges();

        return true;
      }
    }

    public void Inserir(Filme entity)
    {
      using (var _context = new AppContext())
      {
        _context.Filmes.Add(entity);
        _context.SaveChanges();
      }
    }
  }
}