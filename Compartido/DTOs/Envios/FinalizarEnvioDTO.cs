using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.Envios
{
  public class FinalizarEnvioDTO
    {
        public string EmailCliente { get; set; }
        public string EmailEmpleado { get; set; }
        public int Tracking { get; set; }
        public float Peso { get; set; }
        public DateTime Fecha { get; set; }
        public EnumEstadoEnvio Estado { get; set; }
    }
}
