using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        // Acción GET para obtener una lista de productos (puedes modificarla según tus necesidades)
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(new { message = "Hello, world!" });
        }

        // Acción GET para obtener un producto por ID
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            return Ok(new { id = id, name = "Product " + id });
        }
    }
}
