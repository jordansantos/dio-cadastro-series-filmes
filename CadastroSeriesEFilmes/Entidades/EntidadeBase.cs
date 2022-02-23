using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroSeriesEFilmes.Entidades
{
  public abstract class EntidadeBase
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    [Display(Name = "Título")]
    public string Titulo { get; set; }

    [Required]
    [MaxLength(255)]
    [Display(Name = "Descrição")]
    public string Descricao { get; set; }

    [Required]
    public int AnoLancamento { get; set; }

    public bool IsExcluido { get; set; }

    public EntidadeBase() { }

    public EntidadeBase(string titulo, string descricao, int anoLancamento, bool isExcluido)
    {
      this.Titulo = titulo;
      this.Descricao = descricao;
      this.AnoLancamento = anoLancamento;
      this.IsExcluido = isExcluido;
    }
  }
}