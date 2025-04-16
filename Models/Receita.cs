public class Receita
{
  public required int ReceitaId { get; set; }
  public required string Nome { get; set; }
  public required string ModoPreparo { get; set; }

  public ICollection<ReceitaIngrediente> ReceitaIngredientes { get; set; }
}