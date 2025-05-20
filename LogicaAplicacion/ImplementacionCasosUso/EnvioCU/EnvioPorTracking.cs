using Compartido.DTOs.Envios;
using Compartido.DTOs.Usuarios;
using Compartido.Mappers;
using LogicaAplicacion.InterfacesCasosUso.InterfacesEnvio;
using LogicaAplicacion.InterfacesCasosUso.InterfacesUsuario;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.EnvioCU
{
    public class EnvioPorTracking : IEnvioPorTracking
    {
        private IRepositorioEnvio RepoEnvio { get; set; }

        public EnvioPorTracking(IRepositorioEnvio repoEnvio)
        {
            RepoEnvio = repoEnvio;
        }

     

    
EnvioDTO IEnvioPorTracking.Ejecutar(int tracking)
        {
            EnvioDTO envioDTO = null;
            Envio envio = RepoEnvio.FindByTracking(tracking);
            if (envio != null)
            {
                envioDTO = MapperEnvio.EnvioDTOFromEnvio(envio);
            }
            else
            {
                throw new EnvioComunException("No se encontró un Envio con ese nuúmero de tracking");
            }

            return envioDTO;
        }
    }
}
