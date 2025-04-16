using Microsoft.EntityFrameworkCore;
using RecipeApi.Models;

namespace RecipeApi.Data
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Receita> Receitas { get; set; }
    public DbSet<Ingrediente> Ingredientes { get; set; }
    public DbSet<ReceitaIngrediente> ReceitaIngredientes { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<ReceitaIngrediente>()
        .HasKey(ri => new { ri.ReceitaId, ri.IngredienteId });

      modelBuilder.Entity<ReceitaIngrediente>()
        .HasOne(ri => ri.Receita)
        .WithMany(r => r.ReceitaIngredientes)
        .HasForeignKey(ri => ri.ReceitaId);

      modelBuilder.Entity<ReceitaIngrediente>()
        .HasOne(ri => ri.Ingrediente)
        .WithMany(i => i.ReceitaIngredientes)
        .HasForeignKey(ri => ri.IngredienteId);
    }
  }
}

