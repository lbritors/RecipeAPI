namespace RecipeApi.Models;

public class ReceitaIngrediente
{
  public required int ReceitaIngredienteId { get; set; }
  public required decimal Quantidade { get; set; }

  public int ReceitaId { get; set; }
  public required Receita Receita { get; set; }

  public int IngredienteId { get; set; }
  public required Ingrediente Ingrediente { get; set; }


}
