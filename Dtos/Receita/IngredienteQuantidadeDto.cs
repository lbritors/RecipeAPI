namespace RecipeApi.DTOs.Ingrediente;
using System.ComponentModel.DataAnnotations;

public class IngredienteQuantidadeDto
{
  [Required(ErrorMessage = "O ID do ingrediente é obrigatório.")]
  public int IngredienteId { get; set; }

  [Range(0.01, double.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero.")]
  public decimal Quantidade { get; set; }
}
