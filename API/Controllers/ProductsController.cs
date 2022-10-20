using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _context;
        public ProductsController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var Products = await _context.products!.ToListAsync();

            return Ok(Products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Core.Entities.Product>> GetProduct(int id)
        {
            var product = await _context.products!.FindAsync(id);
            return product!;
        }
    }
}