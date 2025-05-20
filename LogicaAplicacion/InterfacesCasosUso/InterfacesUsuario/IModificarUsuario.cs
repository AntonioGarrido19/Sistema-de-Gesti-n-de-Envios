using Compartido.DTOs.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCasosUso.InterfacesUsuario
{
    public interface IModificarUsuario
    {
        void Ejecutar(DatoUsuarioDTO usuarioDTO);
    }
}
