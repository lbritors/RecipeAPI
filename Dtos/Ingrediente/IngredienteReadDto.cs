namespace RecipeApi.DTOs.Ingrediente;

public class IngredienteReadDto
{
  public int IngredienteId { get; set; }
  public string Nome { get; set; } = string.Empty;
  public string UnidadeMedida { get; set; } = string.Empty;
}