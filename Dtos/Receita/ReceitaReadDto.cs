namespace RecipeApi.DTOs.Receita;
using RecipeApi.DTOs.Ingrediente;

public class ReceitaReadDto
{
  public int ReceitaId { get; set; }
  public string Nome { get; set; }
  public string ModoPreparo { get; set; }
  public List<IngredienteInfoDto> Ingredientes { get; set; }
}
