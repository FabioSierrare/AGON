using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/controlller")]
    [ApiController]
    public class ImagenProductoController : Controller
    {
        private readonly IImagenProducto _imagenProducto;
        public ImagenProductoController(IImagenProducto imgaenProducto)
        {
            _imagenProducto = imgaenProducto;
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

        [HttpPost(" PostEstadisticasVentas")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostImagenProducto([FromBody] ImagenProducto imagenProducto)
        {
            try
            {
                var response = await _imagenProducto.PostImagenProducto(imagenProducto);
                if (response == true)
                    return Ok("La imagen del producto a sido agregada correctamente");
                else
                    return BadRequest(response);
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
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutImagenProducto(int id, [FromBody] ImagenProducto imagenProducto)
        {
            if (imagenProducto == null || imagenProducto.Id != id)
                return BadRequest("El ID de la URL no coincide con el ID del modelo o el modelo es nulo.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var imagenProductoList = await _imagenProducto.GetImagenProducto();
                var exists = imagenProductoList.Any(a => a.Id == id);

                if (!exists)
                    return NotFound("El recurso no existe.");

                var response = await _imagenProducto.PutImagenProducto(imagenProducto);

                if (response)
                    return Ok("Actualizado correctamente.");
                else
                    return BadRequest("No se pudo actualizar el recurso.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error inesperado.");
            }
        }

        [HttpDelete("DeleteImagenProducto/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteImagenProducto(int id, [FromBody] ImagenProducto imagenProducto)
        {
            if (imagenProducto == null || imagenProducto.Id != id)
                return BadRequest("El ID de la URL no coincide con el ID del modelo o el modelo es nulo.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var imagenProductoList = await _imagenProducto.GetImagenProducto();
                var exists = imagenProductoList.Any(a => a.Id == id);

                if (!exists)
                    return NotFound("El recurso no existe.");

                var response = await _imagenProducto.DeleteImagenProducto(imagenProducto);

                if (response)
                    return Ok("Actualizado correctamente.");
                else
                    return BadRequest("No se pudo actualizar el recurso.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error inesperado.");
            }
        }
    }
}
