using Compartido.DTOs.Auditorias;
using Compartido.Mappers;
using LogicaAplicacion.InterfacesCasosUso.InterfacesAuditoria;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.AuditoriaCU
{
    public class AltaAuditoria : IAltaAuditoria
    {
        private IRepositorioAuditoria RepositorioAuditoria { get; set; }

        public AltaAuditoria(IRepositorioAuditoria repositorioAuditoria)
        {
            RepositorioAuditoria = repositorioAuditoria;
        }


        public void Ejecutar(AuditoriaDTO auditoriaDTO)
        {
            //validar el argumento que recibe
            //llamar al mapper para convertir el DTO a entidad de negocio Carrera
            //llamar al Repositorio de carrera pasando por parametro la entidad creada 
            if (auditoriaDTO == null)
            {
                throw new ArgumentNullException("Datos incorrectos");
            }
            Auditoria auditoria = MapperAuditoria.AuditoriaFromAuditoriaDTO(auditoriaDTO);
            RepositorioAuditoria.Add(auditoria);
        }

    }
}
