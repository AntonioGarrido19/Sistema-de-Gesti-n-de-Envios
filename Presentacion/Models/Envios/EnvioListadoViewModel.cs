namespace Presentacion.Models.Envios
{
    public class EnvioListadoViewModel
    {
        public string EmailCliente { get; set; }
        public string EmailEmpleado { get; set; }
        public int Tracking { get; set; }
        public float Peso { get; set; }
        public DateTime Fecha { get; set; }
    }
}
