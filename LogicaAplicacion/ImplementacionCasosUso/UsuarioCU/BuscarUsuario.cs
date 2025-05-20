using Compartido.DTOs.Usuarios;
using Compartido.Mappers;
using LogicaAplicacion.InterfacesCasosUso.InterfacesUsuario;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.UsuarioCU
{
    public class BuscarUsuario : IBuscarUsuario
    {
        private IRepositorioUsuario RepoUsuario { get; set; }

        public BuscarUsuario(IRepositorioUsuario repoUsuario)
        {
            RepoUsuario = repoUsuario;
        }

        public DatoUsuarioDTO Ejecutar(int id)
        {
            DatoUsuarioDTO datoUsuario = null;
            Usuario usuario = RepoUsuario.FindById(id);
            if (usuario != null)
            {
                datoUsuario = MapperUsuario.DatoUsuarioDTOFromUsuario(usuario);
            }
            else
            {
                throw new UsuarioException("No se encontró un Usuario con ese id");
            }

            return datoUsuario;
        }

        public DatoUsuarioDTO EjecutarLogin(string email, string password)
        {
            DatoUsuarioDTO datoUsuario = null;
            Usuario usuario = RepoUsuario.FindByEmailAndPassword(email, password);
            if (usuario != null)
            {
                datoUsuario = MapperUsuario.DatoUsuarioDTOFromUsuario(usuario);

            }
            else
            {
                throw new UsuarioException("Los datos ingresados son erroneos");
            }

            return datoUsuario;
        }
    }
}
