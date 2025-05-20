using LogicaNegocio.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Usuario
    {
        public int Id { get; set; }
        public Nombre Nombre { get; set; }
        public string Apellido { get; set; }
        public Cedula Cedula { get; set; }
        public Email Email { get; set; }
        public Password Password { get; set; }
        public EnumRol Rol {  get; set; }

        public Usuario() { }
        public Usuario(string nombre, string apellido, string cedula, string email, string password, EnumRol rol) { 
            Nombre = new Nombre(nombre);
            Apellido = apellido;
            Cedula = new Cedula(cedula);
            Email = new Email(email);  
            Password = new Password(password);
            Rol = rol;
             
        }

    }

}
