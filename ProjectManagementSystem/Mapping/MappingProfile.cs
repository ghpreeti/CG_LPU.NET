using AutoMapper;
using System.Text.Json;
using ProjectManagementSystem.DTOs;
using ProjectManagementSystem.Entities;

namespace ProjectManagementSystem.Mapping
{
    public class MappingProfile : Profile
    {
        private static readonly JsonSerializerOptions _jsonOptions = new();

        private static string SerializeTags(List<string> tags)
            => JsonSerializer.Serialize(tags, _jsonOptions);

        private static string SerializeSpecs(Dictionary<string, string> specs)
            => JsonSerializer.Serialize(specs, _jsonOptions);

        public MappingProfile()
        {
            // ── Create DTO → Entity ────────────────────────────────────────
            CreateMap<CreateProductDto, Product>()
                .ForMember(dest => dest.SKU,
                    opt => opt.MapFrom(src => src.Sku))
                .ForMember(dest => dest.CreatedAt,
                    opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.IsActive,
                    opt => opt.MapFrom(_ => true))
                // Serialize complex types to JSON strings for storage
                .ForMember(dest => dest.Tags,
                    opt => opt.MapFrom(src => SerializeTags(src.Tags)))
                .ForMember(dest => dest.Specifications,
                    opt => opt.MapFrom(src => SerializeSpecs(src.Specifications ?? new())));

            // ── Update DTO → Entity ────────────────────────────────────────
            // Skip null values so unset fields are not overwritten
            CreateMap<UpdateProductDto, Product>()
                .ForMember(dest => dest.UpdatedAt,
                    opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.Tags, opt =>
                {
                    opt.Condition(src => src.Tags != null);
                    opt.MapFrom(src => SerializeTags(src.Tags!));
                })
                .ForMember(dest => dest.Specifications, opt =>
                {
                    opt.Condition(src => src.Specifications != null);
                    opt.MapFrom(src => SerializeSpecs(src.Specifications!));
                })
                .ForAllMembers(opts =>
                    opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
