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
            if (tokens == null || tokens.Id != id)
                return BadRequest("El ID de la URL no coincide con el ID del modelo o el modelo es nulo.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var tokensList = await _tokens.GetTokens();
                var exists = tokensList.Any(a => a.Id == id);

                if (!exists)
                    return NotFound("El recurso no existe.");

                var response = await _tokens.PutTokens(tokens);

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

        [HttpDelete("DeleteTokens/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteTokens(int id, [FromBody] Tokens tokens)
        {
            if (tokens == null || tokens.Id != id)
                return BadRequest("El ID de la URL no coincide con el ID del modelo o el modelo es nulo.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var tokensList = await _tokens.GetTokens();
                var exists = tokensList.Any(a => a.Id == id);

                if (!exists)
                    return NotFound("El recurso no existe.");

                var response = await _tokens.DeleteTokens(tokens);

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
