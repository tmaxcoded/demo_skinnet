using System.Collections.Generic;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController:ControllerBase
    {
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IProductRepository  _product;

        public IGenericRepository<ProductBrand> _productsBrandRepo;
        public IGenericRepository<ProductType> _productsTypeRepo;

        public ProductsController(IGenericRepository<Product> productsRepo,
        IGenericRepository<ProductBrand> productsBrandRepo,
        IGenericRepository<ProductType> productsTypeRepo,

        IProductRepository product)
        {
            _productsRepo = productsRepo;
            _productsBrandRepo = productsBrandRepo;
            _productsTypeRepo = productsTypeRepo;
            _product = product;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts(){
          var spec = new ProductsWithTypesAndBrandsSpecification();
          return  Ok(await _productsRepo.ListAsync(spec));

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id){

          var spec = new ProductsWithTypesAndBrandsSpecification(id);
            return await _productsRepo.GetEntityWithSpec(spec);
           
        } 


        [HttpGet("brands")]
        public async Task<ActionResult<IEnumerable<ProductBrand>>> GetProductBrands(){
          return  Ok(await _productsBrandRepo.ListAllAsync());

        }


          [HttpGet("types")]
        public async Task<ActionResult<IEnumerable<ProductType>>> GetProductTypes(){
          return  Ok(await _productsTypeRepo.ListAllAsync());

        }
    }
}