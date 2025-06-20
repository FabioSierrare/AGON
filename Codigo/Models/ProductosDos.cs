using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    public class ProductosDos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = " El campo {0} es requerido")]
        [Display(Name = " Nombre")]
        public string Nombre { get; set; }

        [Display(Name = " Descripcion del producto")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = " El campo {0} es requerido")]
        [Display(Name = " Precio del producto")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = " El campo {0} es requerido")]
        [Display(Name = " Stock del producto")]
        public int Stock { get; set; }

        [Required(ErrorMessage = " El campo {0} es requerido")]
        [Display(Name =  "Fecha de creacion")]
        [DataType(DataType.Date)]
        public DateTime FechaCreacion { get; set; }

        [Display(Name = " Id de la Categoria")]
        public int CategoriaId { get; set; }

        [Display(Name = " Id del Vendedor")]
        public int VendedorId { get; set; }

        [Display(Name = " UrlImagen")]
        public string UrlImagen { get; set; }
    }
}
