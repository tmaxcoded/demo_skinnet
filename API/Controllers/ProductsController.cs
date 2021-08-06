using System.Collections.Generic;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Core.Entities;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController:ControllerBase
    {
        private readonly Storecontext _context;

        public ProductsController(Storecontext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts(){
          return  Ok(await _context.Products.ToListAsync());

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id){
            return await _context.Products.FindAsync(id);
           
        }
    }
}