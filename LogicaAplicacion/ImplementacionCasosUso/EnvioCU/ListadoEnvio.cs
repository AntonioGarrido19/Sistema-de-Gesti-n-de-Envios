using LogicaAplicacion.InterfacesCasosUso.InterfacesEnvio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compartido.DTOs;
using Compartido.DTOs.Envios;
using Compartido.Mappers;
using LogicaNegocio.EntidadesNegocio;
namespace LogicaAplicacion.ImplementacionCasosUso.EnvioCU
{
    public class ListadoEnvio : IListadoEnvios
    {
        private IRepositorioEnvio RepositorioEnvio { get; set; }

        public ListadoEnvio(IRepositorioEnvio repositorioEnvio) 
        {
            RepositorioEnvio = repositorioEnvio;
        }

        IEnumerable<EnvioDTO> IListadoEnvios.Ejecutar()
        {
            List<Envio> listEnvio = RepositorioEnvio.FindEnProceso().ToList();
            return MapperEnvio.ListEnvioProcesoToListEnvioDTO(listEnvio);    
        }

    }
}
