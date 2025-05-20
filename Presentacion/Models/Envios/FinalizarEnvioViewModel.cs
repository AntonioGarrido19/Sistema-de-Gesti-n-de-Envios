using LogicaNegocio.EntidadesNegocio;

namespace Presentacion.Models.Envios
{
    public class FinalizarEnvioViewModel
    {
        public string EmailCliente { get; set; }
        public string EmailEmpleado { get; set; }
        public int Tracking { get; set; }
        public DateTime Fecha { get; set; }

        public EnumEstadoEnvio Estado { get; set; }
    }
}
