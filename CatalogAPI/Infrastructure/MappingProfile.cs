using AutoMapper;
using CatalogAPI.DAL.Model;
using CatalogAPI.Dtos;

namespace CatalogAPI.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CatalogItem, CreateCatalogItemDto>();
            CreateMap<CatalogItem, CatalogItemDto>();
            CreateMap<CreateCatalogItemDto, CatalogItem>();
        }
    }
}