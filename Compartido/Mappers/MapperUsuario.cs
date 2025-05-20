using Compartido.DTOs.Usuarios;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.Mappers
{
    public class MapperUsuario
    {
        public static Usuario UsuarioFromUsuarioDTO(UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null)
            {
                throw new ArgumentNullException("Datos incorrectos");
            }
            return new Usuario(usuarioDTO.Nombre, 
                               usuarioDTO.Apellido, 
                               usuarioDTO.Cedula, 
                               usuarioDTO.Email, 
                               usuarioDTO.Password, 
                               usuarioDTO.Rol);
        }


        public static List<DatoUsuarioDTO> ListUsuarioToListadoUsuarioDTO
        (List<Usuario> usuarios)
        {
            List<DatoUsuarioDTO> usuarioDTO = new List<DatoUsuarioDTO>();
            foreach (Usuario u in usuarios)
            {
                usuarioDTO.Add(new DatoUsuarioDTO()
                {
                    Id = u.Id,
                    Nombre = u.Nombre.NombreUsuario,
                    Apellido = u.Apellido,
                    Cedula = u.Cedula.CedulaUsuario,
                    Email = u.Email.EmailUsuario,
                    Password = u.Password.PasswordUsuario,
                    Rol = u.Rol
                });
            }
            return usuarioDTO;
        }

        public static List<EmailUsuarioDTO> ListCLientesToClientesDTO
            (List<Usuario> usuarios)
        {
            List<EmailUsuarioDTO> usuarioDTO = new List<EmailUsuarioDTO>();
            foreach (Usuario u in usuarios)
            {
                usuarioDTO.Add(new EmailUsuarioDTO()
                {
                    Id = u.Id,
                    Email = u.Email.EmailUsuario
                });
            }
            return usuarioDTO;
        }


        public static DatoUsuarioDTO DatoUsuarioDTOFromUsuario(Usuario usuario)
        {
            return new DatoUsuarioDTO()
            {
                    Id = usuario.Id,
                    Nombre = usuario.Nombre.NombreUsuario,
                    Apellido = usuario.Apellido,
                    Cedula = usuario.Cedula.CedulaUsuario,
                    Email = usuario.Email.EmailUsuario,
                    Password = usuario.Password.PasswordUsuario,
                    Rol = usuario.Rol
            };

        }

        public static Usuario DatoUsuarioDTOToUsuario(DatoUsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null)
            {
                throw new ArgumentNullException("Datos incorrectos");
            }
            return new Usuario(
                usuarioDTO.Nombre,
                usuarioDTO.Apellido,
                usuarioDTO.Cedula,
                usuarioDTO.Email,
                usuarioDTO.Password,
                usuarioDTO.Rol);
        }
    }
}
