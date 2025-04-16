public class Ingrediente
{
  public required int IngredienteId { get; set; }
  public required string Nome { get; set; }
  public required string UnidadeMedida { get; set; }

  public ICollection<ReceitaIngrediente> ReceitaIngredientes {get; set;}

}