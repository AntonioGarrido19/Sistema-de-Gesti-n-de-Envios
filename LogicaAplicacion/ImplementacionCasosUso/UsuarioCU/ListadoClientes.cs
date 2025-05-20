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
    public class ListadoClientes : IListadoClientes
    {
        private IRepositorioUsuario RepoUsuario { get; set; }

        public ListadoClientes(IRepositorioUsuario repoUsuario)
        {
            RepoUsuario = repoUsuario;
        }


        IEnumerable<EmailUsuarioDTO> IListadoClientes.Ejecutar()
        {
            List<Usuario> listUsuario = RepoUsuario.FindClientes().ToList();
            return MapperUsuario.ListCLientesToClientesDTO(listUsuario);
        }
    }
}
