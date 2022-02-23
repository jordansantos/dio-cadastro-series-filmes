using System.Collections.Generic;
using System.Linq;
using CadastroSeriesEFilmes.Entidades;
using CadastroSeriesEFilmes.Interface;
using CadastroSeriesEFilmes.Persistencia;

namespace CadastroSeriesEFilmes.Repository
{
  public class SerieRepository : IRepository<Serie>
  {
    public List<Serie> BuscarTodos()
    {
      using (var _context = new AppContext())
      {
        return _context.Series.Where(s => s.IsExcluido == false).ToList();
      }
    }

    public Serie BuscarPeloId(int id)
    {
      using (var _context = new AppContext())
      {
        return _context.Series.FirstOrDefault(f => f.Id == id && f.IsExcluido == false);
      }
    }

    public void Inserir(Serie entity)
    {
      using (var _context = new AppContext())
      {
        _context.Series.Add(entity);
        _context.SaveChanges();
      }
    }

    public bool Atualizar(int id, Serie entity)
    {
      using (var _context = new AppContext())
      {
        var serie = this.BuscarPeloId(id);

        serie.Titulo = entity.Titulo;
        serie.AnoLancamento = entity.AnoLancamento;
        serie.Descricao = entity.Descricao;
        serie.Temporadas = entity.Temporadas;

        _context.Series.Update(serie);
        _context.SaveChanges();

        return true;
      }
    }

    public bool Deletar(int id)
    {
      using (var _context = new AppContext())
      {
        var serie = this.BuscarPeloId(id);
        serie.IsExcluido = true;

        _context.Series.Update(serie);
        _context.SaveChanges();

        return true;
      }
    }
  }
}