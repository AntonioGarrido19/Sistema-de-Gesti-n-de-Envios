using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.Auditorias
{
    public class AuditoriaDTO
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Accion { get; set; }

        public int IdUsuario { get; set; }
    }
}
