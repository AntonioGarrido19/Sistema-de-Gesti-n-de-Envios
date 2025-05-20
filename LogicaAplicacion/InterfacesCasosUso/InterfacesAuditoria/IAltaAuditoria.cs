using Compartido.DTOs.Auditorias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCasosUso.InterfacesAuditoria
{
    public interface IAltaAuditoria
    {
        void Ejecutar(AuditoriaDTO auditoriaDTO);
    }
}

