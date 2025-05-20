using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compartido.DTOs.Agencias;

namespace LogicaAplicacion.InterfacesCasosUso.InterfacesAgencia
{
    public interface IListadoAgencias
    {
        IEnumerable<AgenciaDTO> Ejecutar();
    }
}
