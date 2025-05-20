using Compartido.DTOs.Usuarios;
using Compartido.Mappers;
using LogicaAccesoDatos.Repositorios;
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
    public class ModificarUsuario : IModificarUsuario
    {
        private IRepositorioUsuario RepositorioUsuario { get; set; }

        public ModificarUsuario(IRepositorioUsuario repositorioUsuario)
        {
            RepositorioUsuario = repositorioUsuario;
        }

        public void Ejecutar(DatoUsuarioDTO usuarioDTO)
        {
            Usuario usuario = MapperUsuario.DatoUsuarioDTOToUsuario(usuarioDTO);
            usuario.Id = usuarioDTO.Id;
            RepositorioUsuario.Update(usuario);
        }
    }
}
