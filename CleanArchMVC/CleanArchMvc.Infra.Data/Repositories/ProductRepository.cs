using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class ProductRepository: IProductRepository
    {
        ApplicationDbContext _productcontext;
        public ProductRepository(ApplicationDbContext context)
        {
            _productcontext = context;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            _productcontext.Add(product);
            await _productcontext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> GetByIdAsync(int? id)
        {
            return await _productcontext.Products.Include(c => c.Category)
                .SingleOrDefaultAsync(p=>p.Id == id);
        }

        //public async Task<Product> GetProductCategoryAsync(int? id)
        //{
        //    return await _productcontext.Products.Include(c => c.Category)
        //        .SingleOrDefaultAsync(p=>p.Id == id);
        //}

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _productcontext.Products.ToListAsync();
        }

        public async Task<Product> RemoveAsync(Product product)
        {
            _productcontext.Remove(product);
            await _productcontext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            _productcontext.Update(product);
            await _productcontext.SaveChangesAsync();
            return product;
        }
    }
}
