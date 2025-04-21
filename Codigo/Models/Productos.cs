using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using E_Commerce.Repositories.Interfaces;

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
        public int VendedorId { get; set; }
        public string UrlImagen { get; set; }

        [JsonIgnore]
        public Categorias? Categoria { get; set; } // <- permitir nulo
        [JsonIgnore]
        public ICollection<ProductosDescuento>? ProductosDescuento { get; set; } // <- permitir nulo


    }
}
