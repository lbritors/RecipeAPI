using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeApi.Data;
using RecipeApi.DTOs.Ingrediente;
using RecipeApi.DTOs.Receita;
using RecipeApi.Models;
namespace RecipeApi.Controllers;

[ApiController]
[Route("[controller]")]

public class ReceitasController : ControllerBase
{
  private readonly AppDbContext _context;
  private readonly IMapper _mapper;
  public ReceitasController(AppDbContext context, IMapper mapper)
  {
    _context = context;
    _mapper = mapper;
  }

  [HttpGet]
  public async Task<ActionResult<IEnumerable<ReceitaReadDto>>> GetAll()
  {
    var receitas = await _context.Receitas
    .Include(r => r.ReceitaIngredientes)
    .ThenInclude(ri => ri.Ingrediente)
    .ToListAsync();
    return Ok(_mapper.Map<IEnumerable<ReceitaReadDto>>(receitas));
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<ReceitaReadDto>> GetById(int id)
  {
    var receita = await _context.Receitas
    .Include(r => r.ReceitaIngredientes)
    .ThenInclude(ri => ri.Ingrediente)
    .FirstOrDefaultAsync(r => r.ReceitaId == id);
    if (receita == null) return NotFound();
    return Ok(_mapper.Map<ReceitaReadDto>(receita));
  }

  [HttpPost]
  public async Task<ActionResult<ReceitaReadDto>> Create(ReceitaCreateDto dto)
  {
    if (!ModelState.IsValid) return BadRequest(ModelState);
    var ingredienteIds = dto.Ingredientes.Select(i => i.IngredienteId).ToList();
    var ingredientesExist = await _context.Ingredientes
    .Where(i => ingredienteIds.Contains(i.IngredienteId))
    .Select(i => i.IngredienteId)
    .ToListAsync();

    if (ingredienteIds.Count != ingredientesExist.Count)
    {
      return BadRequest("Um ou mais ingredientes não existem");
    }

    var receita = _mapper.Map<Receita>(dto);
    await _context.Receitas.AddAsync(receita);
    await _context.SaveChangesAsync();

    receita = await _context.Receitas
    .Include(r => r.ReceitaIngredientes)
    .ThenInclude(ri => ri.Ingrediente)
    .FirstOrDefaultAsync(r => r.ReceitaId == receita.ReceitaId);

    var readDto = _mapper.Map<ReceitaReadDto>(receita);
    return CreatedAtAction(nameof(GetById), new { id = readDto.ReceitaId }, readDto);

  }

  [HttpPut("{id}")]
  public async Task<IActionResult> Update(int id, ReceitaUpdateDto dto)
  {
    if (id != dto.Id) return BadRequest("Ids não coincidem");
    if (!ModelState.IsValid) return BadRequest(ModelState);
    var ingredienteIds = dto.Ingredientes.Select(i => i.IngredienteId).ToList();
    var ingredientesExist = await _context.Ingredientes
    .Where(i => ingredienteIds.Contains(i.IngredienteId))
    .Select(i => i.IngredienteId)
    .ToListAsync();

    if (ingredienteIds.Count != ingredientesExist.Count)
    {
      return BadRequest("Um ou mais ingredientes não existem");
    }

    var receita = await _context.Receitas
    .Include(r => r.ReceitaIngredientes)
    .FirstOrDefaultAsync(r => r.ReceitaId == id);
    if (receita == null) return NotFound();

    _mapper.Map(dto, receita);
    _context.ReceitaIngredientes.RemoveRange(receita.ReceitaIngredientes);
    receita.ReceitaIngredientes = _mapper.Map<List<ReceitaIngrediente>>(dto.Ingredientes);

    await _context.SaveChangesAsync();
    return NoContent();
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(int id)
  {
    var receita = await _context.Receitas.FindAsync(id);
    if (receita == null) return NotFound();

    _context.Receitas.Remove(receita);
    await _context.SaveChangesAsync();
    return NoContent();

  }

}