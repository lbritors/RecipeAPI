using System.ComponentModel.DataAnnotations;

namespace RecipeApi.DTOs.Ingrediente;

public class IngredienteUpdateDto
{
  [Required(ErrorMessage = "O ID do ingrediente é obrigatório.")]
  public int IngredienteId { get; set; }

  [Required(ErrorMessage = "O nome do ingrediente é obrigatório.")]
  [StringLength(100, ErrorMessage = "O nome do ingrediente deve ter no máximo 100 caracteres.")]
  public string Nome { get; set; } = string.Empty;

  [Required(ErrorMessage = "A unidade de medida é obrigatória.")]
  [StringLength(50, ErrorMessage = "A unidade de medida deve ter no máximo 50 caracteres.")]
  public string UnidadeMedida { get; set; } = string.Empty;
}