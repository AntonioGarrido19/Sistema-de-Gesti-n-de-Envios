using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.ValueObject;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioUsuarioEF : IRepositorioUsuario
    {

        private SistemaContext Contexto { get; set; }
        public RepositorioUsuarioEF(SistemaContext contexto)
        {
            Contexto = contexto;
        }

        public void Add(Usuario item)
        {
            Usuario usuarioBuscado = FindByName(item.Nombre.NombreUsuario);
            if (usuarioBuscado == null)
            {
                Contexto.Usuarios.Add(item);
                Contexto.SaveChanges();
            }
            else
            {
                throw new UsuarioException("Ya existe un usuario con ese nombre");
            }
        }

        private Usuario FindByName(string name)
        {
            return Contexto.Usuarios
                      .Where(c => c.Nombre.NombreUsuario == name)
                      .SingleOrDefault();
        }

        public Usuario FindByEmailAndPassword(string email, string password)
        {
            return Contexto.Usuarios
                      .Where(u => u.Email.EmailUsuario == email && u.Password.PasswordUsuario == password)
                      .SingleOrDefault();
        }

        public Usuario FindByEmail(string email)
        {
            return Contexto.Usuarios
                      .Where(u => u.Email.EmailUsuario == email )
                      .SingleOrDefault();
        }



        public void Delete(int id)
        {
            Usuario usuarioBuscado = FindById(id);
            if (usuarioBuscado != null)
            {
                Contexto.Usuarios.Remove(usuarioBuscado);
                Contexto.SaveChanges();
            }
            else
            {
                throw new UsuarioException("No existe una carrera con ese id");
            }
        }

        public IEnumerable<Usuario> FindAll()
        {
            return Contexto.Usuarios;
        }

        public IEnumerable<Usuario> FindClientes()
        {
            return Contexto.Usuarios.Where(u => u.Rol == EnumRol.CLIENTE);
        }

        public Usuario FindById(int id)
        {
            return Contexto.Usuarios.Find(id);
        }



        public void Update(Usuario item)
        {
            Usuario usuarioBuscado = FindByEmailAndId(item.Email.EmailUsuario, item.Id);
            if (usuarioBuscado == null)
            {
                Contexto.Usuarios.Update(item);
                Contexto.SaveChanges();
            }
            else
            {
                throw new UsuarioException("Ya existe un usuario con ese E-Mail");
            }
        }

        public Usuario FindByEmailAndId(string email, int id) {
            return Contexto.Usuarios.Where(u => u.Email.EmailUsuario == email
            && u.Id != id).SingleOrDefault();
        
        }


    }
}
