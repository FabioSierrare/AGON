﻿using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/controlller")]
    [ApiController]
    public class UsuariosNotificadosContoller : Controller
    {
        private readonly IUsuariosNotificados _usuariosNotificados;
        public UsuariosNotificadosContoller(IUsuariosNotificados usuariosNotificados)
        {
            _usuariosNotificados = usuariosNotificados;
        }

        [HttpGet("GetUsuariosNotificados")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetUsuariosNotificados()
        {
            var response = await _usuariosNotificados.GetUsuariosNotificados();
            return Ok(response);
        }

        [HttpPost("PostUsuariosNotificados")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostUsuariosNotificados([FromBody] UsuariosNotificados usuariosNotificados)
        {
            try
            {
                var response = await _usuariosNotificados.PostUsuariosNotificados(usuariosNotificados);
                if (response == true)
                    return Ok("Se ha agregado a una Notificacion a los usuarios correctamente");
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("PutUsuariosNotificados/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutUsuariosNotificados(int id, [FromBody]UsuariosNotificados usuariosNotificados)
        {
            try
            {
                var response = await _usuariosNotificados.PutUsuariosNotificados(usuariosNotificados);
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

        [HttpDelete("DeleteUsuariosNotificados/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteUsuariosNotificados(int id)
        {
            try
            {
                // Verificar si el usuario notificado existe
                var usuariosNotificadosList = await _usuariosNotificados.GetUsuariosNotificados();
                var exists = usuariosNotificadosList.Any(a => a.Id == id);

                if (!exists)
                    return NotFound("El recurso no existe.");

                // Llamar al repositorio para eliminar el usuario notificado
                var response = await _usuariosNotificados.DeleteUsuariosNotificados(id);

                if (response)
                    return Ok("Usuario notificado eliminado correctamente.");
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
