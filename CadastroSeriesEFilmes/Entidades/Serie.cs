using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroSeriesEFilmes.Entidades
{
  public class Serie : EntidadeBase
  {
    [Range(1, 25, ErrorMessage = "As temporadas devem ser um valor entre 1 e 25.")]
    public int Temporadas { get; set; }
  }
}