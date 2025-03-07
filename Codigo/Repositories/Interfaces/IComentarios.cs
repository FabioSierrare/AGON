﻿using E_Commerce.Models;

public interface IComentarios
{
    Task<List<Comentarios>> GetComentarios();
    Task<bool> PostComentarios(Comentarios comentarios);
    Task<bool> PutComentarios(Comentarios comentarios);
    Task<bool> DeleteComentarios(int id); // Cambiado para aceptar solo el ID
}
