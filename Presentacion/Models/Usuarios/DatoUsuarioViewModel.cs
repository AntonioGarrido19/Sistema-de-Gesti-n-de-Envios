using LogicaNegocio.EntidadesNegocio;

namespace Presentacion.Models.Usuarios
{
    public class DatoUsuarioViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public EnumRol Rol { get; set; }
    }
}
