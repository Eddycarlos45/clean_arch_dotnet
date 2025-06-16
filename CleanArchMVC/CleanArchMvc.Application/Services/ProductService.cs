﻿using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Application.Products.Queries;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ProductService(IMediator mediator, IMapper mapper) 
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productsQuery = new GetProductsQuery();

            if (productsQuery == null) {
                throw new Exception($"Entity could not be loaded.");
            }

            var productsEntity = await _mediator.Send(productsQuery);
  
            return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);
        }

        public async Task<ProductDTO> GetById(int? id)
        {
            var productByIdQuery = new GetProductByIdQuery(id.Value);

            if (productByIdQuery == null)
            {
                throw new Exception($"Entity could not be loaded.");
            }

            var result = await _mediator.Send(productByIdQuery);

            return _mapper.Map<ProductDTO>(result);
        }

        //public async Task<ProductDTO> GetProductCategory(int? id)
        //{
        //    var productByIdQuery = new GetProductByIdQuery(id.Value);

        //    if (productByIdQuery == null)
        //    {
        //        throw new Exception($"Entity could not be loaded.");
        //    }

        //    var result = await _mediator.Send(productByIdQuery);

        //    return _mapper.Map<ProductDTO>(result);
        //}

        public async Task Add(ProductDTO productDTo)
        {
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDTo);
            await _mediator.Send(productCreateCommand);
        }

        public async Task Update(ProductDTO productDTo)
        {
            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDTo);
            await _mediator.Send(productUpdateCommand);
        }

        public async Task Remove(int? id)
        {
            var productRemoveCommand = new ProductRemoveCommand(id.Value);


            if (productRemoveCommand == null)
            {
                throw new Exception($"Entity could not be loaded.");
            }

            await _mediator.Send(productRemoveCommand);
        }
    }
}
