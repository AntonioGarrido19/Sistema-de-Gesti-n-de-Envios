using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compartido.DTOs.Agencias;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ValueObject;

namespace Compartido.Mappers
{
    public class MapperAgencia
    {
        public static Agencia AgenciaFromAgenciaDTO(AgenciaDTO agenciaDTO)
        {
            if (agenciaDTO == null)
            {
                throw new ArgumentNullException("Datos Incorrectos");
            }
            return new Agencia(agenciaDTO.Id,
                               agenciaDTO.Nombre);

        }

        public static List<AgenciaDTO> ListAgenciaToAgenciaDTO
        (List<Agencia> agencias)
        {
            List<AgenciaDTO> agenciaDTO = new List<AgenciaDTO>();
            foreach (Agencia a in agencias)
            {
                agenciaDTO.Add(new AgenciaDTO()
                {
                    Id = a.Id,
                    Nombre = a.Nombre
                });
            }
            return agenciaDTO;

        }


    }
}
