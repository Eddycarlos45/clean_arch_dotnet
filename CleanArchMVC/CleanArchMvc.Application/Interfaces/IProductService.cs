﻿using CleanArchMvc.Application.DTOs;

namespace CleanArchMvc.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts();
        Task<ProductDTO> GetById(int? id);
        // Task<ProductDTO> GetProductCategory(int? id);
        Task Add(ProductDTO productDTo);
        Task Update(ProductDTO productDTo);
        Task Remove(int? id);
    }
}
