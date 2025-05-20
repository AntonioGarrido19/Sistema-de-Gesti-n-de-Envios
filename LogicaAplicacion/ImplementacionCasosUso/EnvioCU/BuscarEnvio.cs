
using Compartido.DTOs.Envios;
using Compartido.DTOs.Usuarios;
using Compartido.Mappers;
using LogicaAplicacion.InterfacesCasosUso.InterfacesEnvio;
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
    public class BuscarEnvio : IBuscarEnvio
    {
        private IRepositorioEnvio RepositorioEnvio { get; set; }

        public BuscarEnvio(IRepositorioEnvio repositorioEnvio)
        {
            RepositorioEnvio = repositorioEnvio;
        }

        public FinalizarEnvioDTO Ejecutar(int tracking)
        {
            FinalizarEnvioDTO envioDTO = null;
            Envio envio = RepositorioEnvio.FindByTracking(tracking);
            if (envio != null)
            {
                envioDTO = MapperEnvio.FinalizarEnvioDTOFromEnvio(envio);
            }
            else
            {
                throw new EnvioComunException("No se encontró un Envio con ese tracking");
            }

            return envioDTO; 
        }

        public EnvioDTO EjecutarComentarios(int tracking)
        {
            EnvioDTO envioDTO = null;
            Envio envio = RepositorioEnvio.FindByTracking(tracking);
            if (envio != null)
            {
                envioDTO = MapperEnvio.EnvioDTOFromEnvio(envio);
            }
            else
            {
                throw new EnvioComunException("No se encontró un Envio con ese tracking");
            }

            return envioDTO;
        }


        //public ComentarioDTO EjecutarComentario(int tracking)
        //{
        //    Envio envio = RepositorioEnvio.FindByTracking(tracking);
        //}
    }
}
