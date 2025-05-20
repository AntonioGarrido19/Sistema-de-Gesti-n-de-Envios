namespace Presentacion.Models.Envios
{
    public class ComentarioViewModel
    {
        public int TrackingEnvio { get; set; }
        public int EmpleadoId { get; set; }

        public DateTime Fecha { get; set; }

        public string Contenido { get; set; }
    }
}
