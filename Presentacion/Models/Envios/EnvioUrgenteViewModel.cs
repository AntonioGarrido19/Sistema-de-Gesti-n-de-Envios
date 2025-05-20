using Presentacion.Models.Agencias;
using Presentacion.Models.Usuarios;

namespace Presentacion.Models.Envios
{
    public class EnvioUrgenteViewModel
    {
        public string EmailCliente { get; set; }
        public int Tracking { get; set; }
        public float Peso { get; set; }
        public string DireccionPostal { get; set; }
        public IEnumerable<UsuarioEmailViewModel> Usuarios { get; set; } = new List<UsuarioEmailViewModel>();
    }
}
