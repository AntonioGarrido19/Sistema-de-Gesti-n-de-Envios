using Compartido.DTOs.Usuarios;
using Compartido.Mappers;
using LogicaAplicacion.InterfacesCasosUso.InterfacesUsuario;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.UsuarioCU
{
    public class ListadoUsuario : IListadoUsuario
    {
        //Defino variable global de tipo RepositorioCarrera para comunicarme con ese repositorio
        private IRepositorioUsuario RepoUsuario { get; set; }

        public ListadoUsuario(IRepositorioUsuario repoUsuario)
        {
            RepoUsuario = repoUsuario;
        }


        IEnumerable<DatoUsuarioDTO> IListadoUsuario.Ejecutar()
        {
            List<Usuario> listUsuario = RepoUsuario.FindAll().ToList();
            return MapperUsuario.ListUsuarioToListadoUsuarioDTO(listUsuario);
        }
    }
}
