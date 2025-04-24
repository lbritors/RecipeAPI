using Microsoft.EntityFrameworkCore;
using RecipeApi.Models;

namespace RecipeApi.Data;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

  public DbSet<Receita> Receitas { get; set; } = null!;
  public DbSet<Ingrediente> Ingredientes { get; set; } = null!;
  public DbSet<ReceitaIngrediente> ReceitaIngredientes { get; set; } = null!;
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

    modelBuilder.Entity<Ingrediente>()
      .Property(i => i.UnidadeMedida)
      .HasConversion<string>()
      .HasMaxLength(50);
    modelBuilder.Entity<Ingrediente>()
      .Property(i => i.Nome)
      .HasMaxLength(100)
      .IsRequired();
    modelBuilder.Entity<Receita>()
      .Property(r => r.Nome)
      .HasMaxLength(100)
      .IsRequired();
    modelBuilder.Entity<Receita>()
      .Property(r => r.ModoPreparo)
      .HasMaxLength(5000)
      .IsRequired();
  }
}


