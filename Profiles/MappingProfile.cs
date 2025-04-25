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

    CreateMap<ReceitaCreateDto, Receita>().
    ForMember(dest => dest.ReceitaIngredientes, opt => opt
    .MapFrom(src => src.Ingredientes));

    CreateMap<ReceitaUpdateDto, Receita>()
       .ForMember(dest => dest.ReceitaId, opt => opt.MapFrom(src => src.ReceitaId))
       .ForMember(dest => dest.ReceitaIngredientes, opt => opt.Ignore());
    CreateMap<IngredienteQuantidadeDto, ReceitaIngrediente>()
        .ForMember(dest => dest.ReceitaId, opt => opt.Ignore())
        .ForMember(dest => dest.Ingrediente, opt => opt.Ignore());

    CreateMap<ReceitaIngrediente, IngredienteInfoDto>()
    .ForMember(dest => dest.IngredienteId, opt => opt
    .MapFrom(src => src.Ingrediente.IngredienteId))
    .ForMember(dest => dest.Nome, opt => opt
    .MapFrom(src => src.Ingrediente.Nome))
    .ForMember(dest => dest.UnidadeMedida, opt => opt
    .MapFrom(src => src.Ingrediente.UnidadeMedida))
    .ForMember(dest => dest.Quantidade, opt => opt
    .MapFrom(src => src.Quantidade));

    CreateMap<Ingrediente, IngredienteReadDto>();
    CreateMap<IngredienteCreateDto, Ingrediente>();
    CreateMap<IngredienteUpdateDto, Ingrediente>();

  }
}
