namespace RecipeApi.Models;

public enum UnidadeMedida
{
  Gramas,
  Quilogramas,
  Litros,
  Mililitros,
  ColherSopa,
  ColherChá,
  Xicara,
  Unidade,

  Pitada
}

public class Ingrediente
{
  public required int IngredienteId { get; set; }
  public required string Nome { get; set; }
  public required UnidadeMedida UnidadeMedida { get; set; }

  public required ICollection<ReceitaIngrediente> ReceitaIngredientes { get; set; } = [];

}
