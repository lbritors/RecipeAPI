namespace RecipeApi.DTOs.Receita;
using RecipeApi.DTOs.Ingrediente;

public class ReceitaReadDto
{
  public int ReceitaId { get; set; }
  public string Nome { get; set; } = string.Empty;
  public string ModoPreparo { get; set; } = string.Empty;
  public required List<IngredienteInfoDto> Ingredientes { get; set; }
}
