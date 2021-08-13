using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRespository : IProductRepository
    {
        private readonly Storecontext _context;

        public ProductRespository(Storecontext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<ProductBrand>> getProductBrandsAsync()
        {
            return await _context.ProductBrands.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products
            .Include(p => p.ProductType)
             .Include(p => p.ProductBrand).FirstOrDefaultAsync(x => x.ProductBrand.Id == id);
        }

        public async Task<IReadOnlyList<Product>> getProductsAsync()
        {
            return await _context.Products
            .Include(p => p.ProductType)
             .Include(p => p.ProductBrand).ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> getProductTypesAsync()
        {
           return await _context.productTypes.ToListAsync();
        }
    }
}