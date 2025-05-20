using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compartido.DTOs.Usuarios;

namespace LogicaAplicacion.InterfacesCasosUso.InterfacesUsuario
{
    public interface IListadoClientes
    {
        IEnumerable<EmailUsuarioDTO> Ejecutar();
    }
}
