using ETicaretAPI.Application.Abstraction;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductWriteRpository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;

        public ProductsController(IProductReadRepository productReadRepository, IProductWriteRpository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }
        [HttpGet]
        public async Task Get()
        {
            /*   await _productWriteRepository.AddRangeAsync(new()
               {
                   new(){Id=Guid.NewGuid(),Name="Product 1",Stock=10,Price=100,CreateDate=DateTime.UtcNow},
                   new(){Id=Guid.NewGuid(),Name="Product 2",Stock=15,Price=50,CreateDate=DateTime.UtcNow},
                   new(){Id=Guid.NewGuid(),Name="Product 3",Stock=20,Price=120,CreateDate=DateTime.UtcNow},
                   new(){Id=Guid.NewGuid(),Name="Product 4",Stock=40,Price=160,CreateDate=DateTime.UtcNow}
               });*/
            Product p = await _productReadRepository.GetByIdAsync("0e00ee1d-20fb-4efb-9c35-89019a5260bd",false);
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
