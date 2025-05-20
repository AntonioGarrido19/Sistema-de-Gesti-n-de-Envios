using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compartido.DTOs.Agencias;
using Compartido.Mappers;
using LogicaAplicacion.InterfacesCasosUso.InterfacesAgencia;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.ImplementacionCasosUso.AgenciaCU
{
    public class ListadoAgencias : IListadoAgencias
    {
        private IRepositorioAgencia RepoAgencia { get; set; }

        public ListadoAgencias(IRepositorioAgencia repoAgencia)
        {
            RepoAgencia = repoAgencia;
        }

         IEnumerable<AgenciaDTO> IListadoAgencias.Ejecutar()
        {
            List<Agencia> listAgencia = RepoAgencia.FindAll().ToList();
            return MapperAgencia.ListAgenciaToAgenciaDTO(listAgencia);
        }
    }
}
