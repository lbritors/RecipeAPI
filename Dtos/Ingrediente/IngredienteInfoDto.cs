namespace RecipeApi.DTOs.Ingrediente;

public class IngredienteInfoDto
{
  public int IngredienteId { get; set; }
  public string Nome { get; set; }
  public string UnidadeMedida { get; set; }
  public decimal Quantidade { get; set; }
}