using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    public class Productos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public DateTime FechaCreacion { get; set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        public int VendedorId { get; set; }     
        public Usuarios Vendedor { get; set; }

        public ICollection<ImagenProducto> Imagenes { get; set; }
    }
}
