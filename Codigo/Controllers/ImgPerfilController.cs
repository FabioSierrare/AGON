using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Controllers
{
    /// <summary>
    /// Controlador para gestionar operaciones relacionadas con la imagen de perfil del usuario.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ImgPerfilController : ControllerBase
    {
        private readonly IImgPerfil _imgPerfil;

        /// <summary>
        /// Constructor que inyecta la dependencia del repositorio de imagen de perfil.
        /// </summary>
        /// <param name="imgPerfil">Repositorio de imagen de perfil</param>
        public ImgPerfilController(IImgPerfil imgPerfil)
        {
            _imgPerfil = imgPerfil;
        }

        /// <summary>
        /// Obtiene todas las imágenes de perfil registradas.
        /// </summary>
        /// <returns>Lista de imágenes de perfil</returns>
        [HttpGet("GetImgPerfil")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetImgPerfil()
        {
            var response = await _imgPerfil.GetImgPerfil();
            return Ok(response);
        }

        /// <summary>
        /// Agrega una nueva imagen de perfil.
        /// </summary>
        /// <param name="imgPerfil">Datos de la imagen de perfil a insertar</param>
        /// <returns>Resultado de la operación</returns>
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

        /// <summary>
        /// Actualiza una imagen de perfil existente.
        /// </summary>
        /// <param name="imgPerfil">Datos actualizados de la imagen de perfil</param>
        /// <returns>Resultado de la operación</returns>
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

        /// <summary>
        /// Elimina una imagen de perfil por su ID.
        /// </summary>
        /// <param name="id">ID de la imagen de perfil</param>
        /// <returns>Resultado de la operación</returns>
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
