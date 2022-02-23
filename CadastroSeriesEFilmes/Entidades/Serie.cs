using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroSeriesEFilmes.Entidades
{
  public class Serie : EntidadeBase
  {
    public Serie() { }
    public Serie(string titulo, string descricao, int anoLancamento, int temporada, bool isExcluido = false)
    : base(titulo, descricao, anoLancamento, isExcluido)
    {
      this.Temporadas = temporada;
    }

    [Range(1, 25, ErrorMessage = "As temporadas devem ser um valor entre 1 e 25.")]
    public int Temporadas { get; set; }
  }
}