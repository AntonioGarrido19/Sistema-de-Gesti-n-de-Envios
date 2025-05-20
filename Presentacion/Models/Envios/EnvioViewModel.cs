using LogicaNegocio.EntidadesNegocio;
using Presentacion.Models.Usuarios;
using Presentacion.Models.Agencias;

namespace Presentacion.Models.Envios
{
    public class EnvioViewModel
    {
        //public string Cliente { get; set; }
        public string EmailCliente { get; set; }

        public int Tracking {  get; set; }
        public float Peso { get; set; }
        public int AgenciaId { get; set; }
        public IEnumerable<AgenciaViewModel> Agencias { get; set; } = new List<AgenciaViewModel>();
        public IEnumerable<UsuarioEmailViewModel> Usuarios { get; set; } = new List<UsuarioEmailViewModel>();
    }
}
