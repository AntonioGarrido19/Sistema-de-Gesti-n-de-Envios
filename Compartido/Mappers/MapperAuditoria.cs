using Compartido.DTOs.Auditorias;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.Mappers
{
    public class MapperAuditoria
    {
        public static Auditoria AuditoriaFromAuditoriaDTO(AuditoriaDTO auditoriaDTO)
        {
            if (auditoriaDTO == null)
            {
                throw new ArgumentNullException("Datos incorrectos");
            }
            return new Auditoria(auditoriaDTO.Id,
                               auditoriaDTO.Fecha,
                               auditoriaDTO.Accion,
                               auditoriaDTO.IdUsuario);

        }
    }
}
