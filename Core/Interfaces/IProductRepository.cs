
using System.Threading.Tasks;
using Core.Entities;
using System.Collections.Generic;
namespace Core.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int id);
        
        Task<IReadOnlyList<Product>> getProductsAsync();

         Task<IReadOnlyList<ProductBrand>> getProductBrandsAsync();

         Task<IReadOnlyList<ProductType>> getProductTypesAsync();
    }
}