using Compartido.DTOs.Envios;
using Compartido.DTOs.Usuarios;
using Compartido.Mappers;
using LogicaAccesoDatos.Repositorios;
using LogicaAplicacion.InterfacesCasosUso.InterfacesEnvio;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.EnvioCU
{
    public class FinalizarEnvio : IFinalizarEnvio
    {
        private IRepositorioEnvio RepositorioEnvio { get; set; }

        public FinalizarEnvio(IRepositorioEnvio repositorioEnvio)
        {
            RepositorioEnvio = repositorioEnvio;
        }
    

        public void Ejecutar(FinalizarEnvioDTO finalizarEnvioDTO)
        {
            Envio envioModificar = RepositorioEnvio.FindByTracking(finalizarEnvioDTO.Tracking);
            Envio envio = MapperEnvio.FinalizarEnvioDTOToEnvio(finalizarEnvioDTO, envioModificar);
            envio.Tracking = finalizarEnvioDTO.Tracking;
            RepositorioEnvio.Update(envio);
        }
    }
}
