using System.ComponentModel.DataAnnotations;

namespace CadastroSeriesEFilmes.Entidades
{
  public class Filme : EntidadeBase
  {
    public Filme() { }
    public Filme(string titulo, string descricao, int anoLancamento, int duracao, bool isExcluido = false)
    : base(titulo, descricao, anoLancamento, isExcluido)
    {
      this.Duracao = duracao;
    }


    [Range(1, 600, ErrorMessage = "A duração deve ser um valor entre 1 e 600.")]
    public int Duracao { get; set; }
  }
}