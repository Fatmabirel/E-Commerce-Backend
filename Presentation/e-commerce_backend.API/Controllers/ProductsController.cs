using e_commerce_backend.Application.Repositories;
using e_commerce_backend.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce_backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;

        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        [HttpGet]
        public async Task Get()
        {
            //_productWriteRepository.AddRangeAsync(new()
            //{
            //    new() {Id = Guid.NewGuid(), Name = "Product1", Price= 100, CreatedDate = DateTime.UtcNow, Stock = 10},
            //    new() {Id = Guid.NewGuid(), Name = "Product2", Price= 180, CreatedDate = DateTime.UtcNow, Stock = 20},
            //    new() {Id = Guid.NewGuid(), Name = "Product2", Price= 140, CreatedDate = DateTime.UtcNow, Stock = 50},
            //});
            //await _productWriteRepository.SaveAsync();

            Product p = await _productReadRepository.GetByIdAsync("7001dda5-7d72-4bf7-bbbe-d59da1ea53fd");
            p.Name = "Mehmet";
            await _productWriteRepository.SaveAsync();
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Product product = await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }
    }
}
