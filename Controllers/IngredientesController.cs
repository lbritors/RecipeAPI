using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeApi.Data;
using RecipeApi.Models;
using RecipeApi.DTOs.Ingrediente;

namespace RecipeApi.Controllers;

[ApiController]
[Route("[controller]")]

public class IngredientesController : ControllerBase
{
  private readonly AppDbContext _context;
  private readonly IMapper _mapper;

  private readonly ILogger<IngredientesController> _logger;
  public IngredientesController(AppDbContext context, IMapper mapper, ILogger<IngredientesController> logger)
  {
    _context = context;
    _mapper = mapper;
    _logger = logger;
  }

  [HttpGet]
  public async Task<ActionResult<IEnumerable<IngredienteReadDto>>> GetAll()
  {
    var ingredientes = await _context.Ingredientes.ToListAsync();
    return Ok(_mapper.Map<IEnumerable<IngredienteReadDto>>(ingredientes));
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<IngredienteReadDto>> GetById(int id)
  {
    var ingrediente = await _context.Ingredientes.FindAsync(id);
    if (ingrediente == null) return NotFound();
    return Ok(_mapper.Map<IngredienteReadDto>(ingrediente));
  }


  [HttpPost]
  public async Task<ActionResult<IngredienteReadDto>> Create(IngredienteCreateDto dto)
  {
    if (!ModelState.IsValid)
    {
      _logger.LogWarning("Model state não válido {Errors}", ModelState);

      return BadRequest(ModelState);
    }
    var ingrediente = _mapper.Map<Ingrediente>(dto);
    await _context.Ingredientes.AddAsync(ingrediente);
    await _context.SaveChangesAsync();
    var readDto = _mapper.Map<IngredienteReadDto>(ingrediente);
    return CreatedAtAction(nameof(GetById), new { id = readDto.IngredienteId }, readDto);
  }

  [HttpPut("{id}")]
  public async Task<ActionResult> Update(int id, IngredienteUpdateDto dto)
  {

    if (id != dto.Id)
    {
      _logger.LogWarning("Ingrediente {id} não encontrado", id);
      return BadRequest("IDs não coincidem");
    }
    if (!ModelState.IsValid) return BadRequest(ModelState);

    var ingrediente = await _context.Ingredientes.FindAsync(id);
    if (ingrediente == null) return NotFound();

    _mapper.Map(dto, ingrediente);
    await _context.SaveChangesAsync();
    _logger.LogInformation("Ingrediente {id} atualizado com sucesso", id);
    return NoContent();
  }

  [HttpDelete("{id}")]
  public async Task<ActionResult> Delete(int id)
  {
    _logger.LogInformation("Tenteando excluir ingrediente com id: {id}", id);
    var ingrediente = await _context.Ingredientes.
      Include(i => i.ReceitaIngredientes)
      .FirstOrDefaultAsync(i => i.IngredienteId == id);
    if (ingrediente == null) return NotFound();
    if (ingrediente.ReceitaIngredientes.Count > 0)
    {
      _logger.LogWarning("Ingrediente com {id} não encontrado", id);
      return BadRequest("Não é possível excluir o ingrediente, pois ele está associado a uma receita.");
    }
    _context.Ingredientes.Remove(ingrediente);
    await _context.SaveChangesAsync();
    _logger.LogInformation("Ingrediente com {id} excluído com sucesso", id);
    return NoContent();
  }
}