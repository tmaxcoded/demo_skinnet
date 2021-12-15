using System.Collections.Generic;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using API.Dtos;
using AutoMapper;

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
        private readonly IMapper _autoMapper;

        public ProductsController(IGenericRepository<Product> productsRepo,
        IGenericRepository<ProductBrand> productsBrandRepo,
        IGenericRepository<ProductType> productsTypeRepo,
        IMapper autoMapper,

        IProductRepository product)
        {
            _productsRepo = productsRepo;
            _productsBrandRepo = productsBrandRepo;
            _productsTypeRepo = productsTypeRepo;
            _autoMapper = autoMapper;
            _product = product;
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts(){
          var spec = new ProductsWithTypesAndBrandsSpecification();
          var products = await _productsRepo.ListAsync(spec);
          return  Ok(_autoMapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products));

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id){

          var spec = new ProductsWithTypesAndBrandsSpecification(id);
          var product = await _productsRepo.GetEntityWithSpec(spec);
            

          return  Ok(_autoMapper.Map<Product,ProductToReturnDto>(product));
           
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