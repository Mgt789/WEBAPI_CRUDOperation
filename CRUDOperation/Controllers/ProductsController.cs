using CRUDOperation.Model;
using CRUDOperation.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;

namespace CRUDOperation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
       
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        public IEnumerable<Production> Get()
        {
            return _productRepository.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Production> Get(int id)
        {
            var production = _productRepository.GetById(id);
            if (production == null)
            {
                return NotFound();
            }
            return production;
        }

        [HttpPost]
        public IActionResult post([FromBody] Production production)
        {
            if (production == null)
            {
                return BadRequest();
            }
            _productRepository.Add(production);
            return CreatedAtAction(nameof(Get), new { id = production.brand_id }, production);
        }
    }
}
