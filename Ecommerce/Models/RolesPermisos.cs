using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    public class RolesPermisos
    {
        public int Id { get; set; }
        public int RolId { get; set; }
        public Rol Rol { get; set; }
        public int PermisoId { get; set; }
        public Permiso Permiso { get; set; }
    }
}
