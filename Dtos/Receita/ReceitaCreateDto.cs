namespace RecipeApi.DTOs.Receita;
using RecipeApi.DTOs.Ingrediente;

public class ReceitaCreateDto
{
  public required string Nome { get; set; }
  public required string ModoPreparo { get; set; }
  public required List<IngredienteQuantidadeDto> Ingredientes { get; set; }
}