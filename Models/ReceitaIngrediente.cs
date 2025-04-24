using System.ComponentModel.DataAnnotations;
namespace RecipeApi.Models;

public class ReceitaIngrediente
{
  public required int ReceitaId { get; set; }
  public Receita Receita { get; set; } = null!;
  public int IngredienteId { get; set; }
  public required Ingrediente Ingrediente { get; set; } = null!;

  [Range(0.01, double.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero.")]
  public required decimal Quantidade { get; set; }
}
