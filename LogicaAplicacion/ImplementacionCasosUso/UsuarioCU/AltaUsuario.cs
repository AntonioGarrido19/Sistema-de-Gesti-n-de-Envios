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
    public class AltaUsuario : IAltaUsuario
    {
        private IRepositorioUsuario RepositorioUsuario { get; set; }

        public AltaUsuario(IRepositorioUsuario repositorioUsuario)
        {
            RepositorioUsuario = repositorioUsuario;
        }


        public void Ejecutar(UsuarioDTO usuarioDTO)
        {
            //validar el argumento que recibe
            //llamar al mapper para convertir el DTO a entidad de negocio Carrera
            //llamar al Repositorio de carrera pasando por parametro la entidad creada 
            if (usuarioDTO == null)
            {
                throw new ArgumentNullException("Datos incorrectos");
            }
            Usuario usuario = MapperUsuario.UsuarioFromUsuarioDTO(usuarioDTO);
            RepositorioUsuario.Add(usuario);
        }
    }
}
