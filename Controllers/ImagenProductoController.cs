using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/controller/imagenproducto")]
    [ApiController]
    public class ImagenProductoController : Controller
    {
        private readonly IImagenProducto _imagenProducto;

        public ImagenProductoController(IImagenProducto imagenProducto)
        {
            _imagenProducto = imagenProducto;
        }

        [HttpGet("GetImagenProducto")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetImagenProducto()
        {
            var response = await _imagenProducto.GetImagenProducto();
            return Ok(response);
        }

        [HttpPost("PostImagenProducto")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostImagenProducto([FromBody] ImagenProducto imagenProducto)
        {
            try
            {
                var response = await _imagenProducto.PostImagenProducto(imagenProducto);
                if (response)
                    return Ok("La imagen del producto ha sido agregada correctamente.");
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // Other actions
    }
}
