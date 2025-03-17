using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Application.Mappigns
{
    public class DomainToDTOMappingProfile: Profile
    {
        public DomainToDTOMappingProfile() 
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();       
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
