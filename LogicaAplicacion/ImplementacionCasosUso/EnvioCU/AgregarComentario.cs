using Compartido.DTOs.Envios;
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
    public class AgregarComentario : IAgregarComentario

    {
        public IRepositorioEnvio RepositorioEnvio { get; set; }

        public AgregarComentario(IRepositorioEnvio repositorioEnvio) { 
        
            RepositorioEnvio = repositorioEnvio;
        }
        public void Ejecutar(ComentarioDTO comentarioDTO)
        {
            Envio envio = RepositorioEnvio.FindByTracking(comentarioDTO.TrackingEnvio);
            if (envio != null) { 
            Comentario comentario = MapperEnvio.ComentarioFromComentarioDTO(comentarioDTO);
            envio.Comentarios.Add(comentario);
            RepositorioEnvio.Update(envio);
            }
            else
            {
                throw new EnvioComunException("No hay un envio con ese numero de tracking");
            }
        }
    }
}
