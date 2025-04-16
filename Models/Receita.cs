namespace RecipeApi.Models
{
  public class Receita
  {
    public required int ReceitaId { get; set; }
    public required string Nome { get; set; }
    public required string ModoPreparo { get; set; }

    public required ICollection<ReceitaIngrediente> ReceitaIngredientes { get; set; }
  }
}