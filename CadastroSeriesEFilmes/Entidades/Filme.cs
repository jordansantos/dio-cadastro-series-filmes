using System.ComponentModel.DataAnnotations;

namespace CadastroSeriesEFilmes.Entidades
{
  public class Filme : EntidadeBase
  {
    [Range(1, 600, ErrorMessage = "A duração deve ser um valor entre 1 e 600.")]
    public int Duração { get; set; }
  }
}