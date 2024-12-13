using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/controller/imagenproducto")]
    [ApiController]
    public class ImagenProductoController : ControllerBase
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
                    return BadRequest("Hubo un error al agregar la imagen del producto.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("PutImagenProducto/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutImagenProducto( [FromBody] ImagenProducto imagenProducto)
        {


            try
            {
                var response = await _imagenProducto.PutImagenProducto(imagenProducto);
                if (response)
                    return Ok("Comentario actualizado correctamente.");
                else
                    return NotFound("Comentario no encontrado.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteImagenProducto/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteImagenProducto(int id)
        {
            try
            {
                var imagenProductoList = await _imagenProducto.GetImagenProducto();
                var exists = imagenProductoList.Any(a => a.Id == id);

                if (!exists)
                    return NotFound("El recurso no existe.");

                var response = await _imagenProducto.DeleteImagenProducto(id);

                if (response)
                    return Ok("La imagen del producto ha sido eliminada correctamente.");
                else
                    return BadRequest("No se pudo eliminar el recurso.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}