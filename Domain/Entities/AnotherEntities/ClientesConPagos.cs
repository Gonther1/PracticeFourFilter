using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities.AnotherEntities
{
    public class ClientesConPagos
    {
        public int CodigoCliente { get; set; }
        public int ClientePagoFk { get; set; }
        public string NombreCliente { get; set; }
        public string NombreRepresentante { get; set; }
        public string CiudadOficina { get; set; }
    }
}