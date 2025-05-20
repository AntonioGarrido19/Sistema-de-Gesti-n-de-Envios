using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.Envios
{
    public class ComentarioDTO
    {

        public int EmpleadoId { get; set; }

        public int TrackingEnvio { get; set; }
        public DateTime Fecha { get; set; }

        public string Contenido { get; set; }
    }
}
