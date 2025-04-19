using AutoMapper;
using RecipeApi.DTOs.Ingrediente;
using RecipeApi.DTOs.Receita;
using RecipeApi.Models;
namespace RecipeApi.Profiles;

public class MappingProfile : Profile
{
  public MappingProfile()
  {
    CreateMap<Receita, ReceitaReadDto>()
    .ForMember(dest => dest.Ingredientes, opt => opt
    .MapFrom(src => src.ReceitaIngredientes));

    CreateMap<ReceitaCreateDto, Receita>();

    CreateMap<ReceitaIngrediente, IngredienteInfoDto>()
    .ForMember(dest => dest.IngredienteId, opt => opt
    .MapFrom(src => src.Ingrediente.IngredienteId))
    .ForMember(dest => dest.Nome, opt => opt
    .MapFrom(src => src.Ingrediente.Nome))
    .ForMember(dest => dest.UnidadeMedida, opt => opt
    .MapFrom(src => src.Ingrediente.UnidadeMedida))
    .ForMember(dest => dest.Quantidade, opt => opt
    .MapFrom(src => src.Quantidade));

    CreateMap<IngredienteQuantidadeDto, ReceitaIngrediente>();
    CreateMap<Ingrediente, IngredienteReadDto>();
    CreateMap<IngredienteCreateDto, Ingrediente>();
    CreateMap<IngredienteUpdateDto, Ingrediente>();

  }
}
