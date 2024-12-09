using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/controlller")]
    [ApiController]
    public class TokensController : ControllerBase
    {
        private readonly ITokens _tokens;
        public TokensController(ITokens tikectsSoporte)
        {
            _tokens = tikectsSoporte;
        }

        [HttpGet("GetTokens")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetTokens()
        {
            var response = await _tokens.GetTokens();
            return Ok(response);
        }

        [HttpPost("PostTokens")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostTokens([FromBody] Tokens tokens)
        {
            try
            {
                var response = await _tokens.PostTokens(tokens);
                if (response == true)
                    return Ok("Se ha agregado un token correctamente");
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("PutTokens/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutTokens(int id, [FromBody] Tokens tokens)
        {
            try
            {
                var response = await _tokens.PutTokens(tokens);
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

        [HttpDelete("DeleteTokens/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteTokens(int id)
        {
            try
            {
                // Obtener la lista de tokens
                var tokensList = await _tokens.GetTokens();
                var exists = tokensList.Any(a => a.Id == id);

                // Verificar si el token existe
                if (!exists)
                    return NotFound("El recurso no existe.");

                // Llamar al método para eliminar el token
                var response = await _tokens.DeleteTokens(id);

                // Verificar si la eliminación fue exitosa
                if (response)
                    return Ok("Token eliminado correctamente.");
                else
                    return BadRequest("No se pudo eliminar el recurso.");
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error inesperado.");
            }
        }
    }
}
