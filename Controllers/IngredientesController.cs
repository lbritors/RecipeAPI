using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeApi.Data;
using RecipeApi.Models;

namespace RecipeApi.Controllers;

[ApiController]
[Route("[controller]")]

public class IngredientesController : ControllerBase
{
  private readonly AppDbContext _context;
  public IngredientesController(AppDbContext context)
  {
    _context = context;
  }
  [HttpGet]
  public async Task<ActionResult<IEnumerable<Ingrediente>>> GetIngredientes()
  {
    return await _context.Ingredientes.ToListAsync();
  }

  [HttpPost]
  public async Task<ActionResult<Ingrediente>> PostIngrediente(Ingrediente ingrediente)
  {
    _context.Ingredientes.Add(ingrediente);
    await _context.SaveChangesAsync();
    return CreatedAtAction(nameof(GetIngredientes), new { id = ingrediente.IngredienteId }, ingrediente);
  }
}