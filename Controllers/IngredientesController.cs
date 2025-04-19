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
  public IngredientesController(AppDbContext context, IMapper mapper)
  {
    _context = context;
    _mapper = mapper;
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
    var ingrediente = _mapper.Map<Ingrediente>(dto);
    await _context.Ingredientes.AddAsync(ingrediente);
    await _context.SaveChangesAsync();
    var readDto = _mapper.Map<IngredienteReadDto>(ingrediente);
    return CreatedAtAction(nameof(GetById), new { id = readDto.IngredienteId }, readDto);
  }

  [HttpPut("{id}")]
  public async Task<ActionResult<IngredienteReadDto>> Updaate(int id, IngredienteUpdateDto dto)
  {
    var ingrediente = await _context.Ingredientes.FindAsync(id);
    if (ingrediente == null) return NotFound();
    _mapper.Map(dto, ingrediente);
    await _context.SaveChangesAsync();
    return NoContent();
  }

  [HttpDelete("{id}")]
  public async Task<ActionResult<IngredienteReadDto>> Delete(int id)
  {
    var ingrediente = await _context.Ingredientes.FindAsync(id);
    if (ingrediente == null) return NotFound();
    _context.Ingredientes.Remove(ingrediente);
    await _context.SaveChangesAsync();

    return NoContent();
  }
}