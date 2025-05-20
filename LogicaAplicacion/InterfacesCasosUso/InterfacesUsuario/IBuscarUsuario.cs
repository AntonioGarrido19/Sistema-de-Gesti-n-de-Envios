using Compartido.DTOs.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCasosUso.InterfacesUsuario
{
    public interface IBuscarUsuario
    {
        DatoUsuarioDTO EjecutarLogin(string email, string password);
        DatoUsuarioDTO Ejecutar(int id);
    }
}
