using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImgPerfilController : ControllerBase
    {

        private readonly IImgPerfil _imgPerfil;
        public ImgPerfilController(IImgPerfil imgPerfil)
        {
            _imgPerfil = imgPerfil;
        }

        [HttpGet("GetImgPerfil")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetImgPerfil()
        {
            var response = await _imgPerfil.GetImgPerfil();
            return Ok(response);
        }

        [HttpPost("PostImgPerfil")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostCategoria([FromBody] ImgPerfil imgPerfil)
        {
            try
            {
                var response = await _imgPerfil.PostImgPerfil(imgPerfil);
                if (response == true)
                    return Ok("Imagen perfil Insertada correctamente");
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("PutImgPerfil/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutAdministrador([FromBody] ImgPerfil imgPerfil)
        {


            try
            {
                var response = await _imgPerfil.PutImgPerfil(imgPerfil);
                if (response)
                    return Ok("Imagen perfil actualizado correctamente.");
                else
                    return NotFound("Imagen perfil no encontrado.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("DeleteImgPerfil/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCategorias(int id)
        {
            try
            {
                var response = await _imgPerfil.DeleteImgPerfil(id);

                if (response)
                    return Ok("Imagen perfil eliminada con éxito.");
                else
                    return NotFound("La Imagen perfil no fue encontrada.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
