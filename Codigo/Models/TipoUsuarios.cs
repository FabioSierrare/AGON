namespace E_Commerce.Models
{
    public class TipoUsuarios
    {
        public int Id { get; set; }           // Correspondiente a la PK INT en la tabla
        public string Nombre { get; set; }    // Nombre del tipo de usuario (VARCHAR/NVARCHAR)

        // Si en tu base de datos hay más columnas, agrégalas aquí con su tipo correcto.
    }
}
