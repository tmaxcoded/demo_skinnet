using System.Collections.Generic;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController:ControllerBase
    {
        private readonly IProductRepository  _product;

        public ProductsController(IProductRepository product)
        {
            _product = product;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts(){
          return  Ok(await _product.getProductsAsync());

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id){
            return await _product.GetProductByIdAsync(id);
           
        }
    }
}