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
    public string Título { get; set; }
    [Required]
    [MaxLength(255)]
    [Display(Name = "Descrição")]
    public string Descrição { get; set; }
    [Required]
    public int AnoLançamento { get; set; }
    public bool IsExcluido { get; set; }
  }
}