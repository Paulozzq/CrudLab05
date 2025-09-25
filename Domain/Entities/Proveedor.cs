using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Proveedor
    {
        public int IdProveedor { get; set; }
        public string NombreCompañia { get; set; } = string.Empty;
        public string? NombreContacto { get; set; }
        public string? CargoContacto { get; set; }
        public string? Direccion { get; set; }
        public string? Ciudad { get; set; }
        public string? Region { get; set; }
        public string? CodPostal { get; set; }
        public string? Pais { get; set; }
        public string? Telefono { get; set; }
        public string? Fax { get; set; }
        public string? PaginaPrincipal { get; set; }
    }
}
