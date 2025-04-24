namespace RecipeApi.DTOs.Receita;
using RecipeApi.DTOs.Ingrediente;
using System.ComponentModel.DataAnnotations;

public class ReceitaUpdateDto
{
  [Required(ErrorMessage = "O ID da receita é obrigatório.")]
  public int Id { get; set; }

  [Required(ErrorMessage = "O nome da receita é obrigatório.")]
  [StringLength(100, MinimumLength = 1, ErrorMessage = "O nome da receita deve ter no máximo 100 caracteres.")]
  public string Nome { get; set; } = string.Empty;

  [Required(ErrorMessage = "A descrição da receita é obrigatória.")]
  [StringLength(5000, MinimumLength = 1, ErrorMessage = "A descrição da receita deve ter no máximo 500 caracteres.")]
  public string ModoPreparo { get; set; } = string.Empty;


  [Required(ErrorMessage = "A receita deve ter pelo menos um ingrediente.")]
  [MinLength(1, ErrorMessage = "A receita deve ter pelo menos um ingrediente.")]
  public required List<IngredienteQuantidadeDto> Ingredientes { get; set; }
}