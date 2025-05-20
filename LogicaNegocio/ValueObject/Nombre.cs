using LogicaNegocio.ExcepcionesEntidades;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.RegularExpressions;

namespace LogicaNegocio.ValueObject
{
    [Owned]
    public class Nombre
    {
        public string NombreUsuario { get; init; }

        public Nombre(string nombreUsuario)
        {
            NombreUsuario = nombreUsuario;
            Validar();
        }

        private void Validar()
        {
            if (string.IsNullOrWhiteSpace(NombreUsuario))
            {
                throw new UsuarioException("El nombre no puede estar vacío.");
            }


            if (NombreUsuario.Length < 2 || NombreUsuario.Length > 50) 
            {
                throw new UsuarioException("El nombre debe tener entre 2 y 50 caracteres.");
            }


            if (!VerificarNombreUsuario(NombreUsuario)) 
            {
                throw new UsuarioException("El nombre solo puede contener letras y espacio.");
            }

            if (NombreUsuario.Contains("  ")) 
            {
                throw new UsuarioException("El nombre no puede contener múltiples espacios seguidos.");
            }

        }

        public bool VerificarNombreUsuario(string NombreUsuario)
        {
            bool retorno = true;
            foreach (char c in NombreUsuario)
            {
                
                if (!Char.IsLetter(c) && c != ' ' && c != 'Ñ' && c != 'ñ')
                {
                    retorno = false;
                }
            }

            return retorno;
        }
    }
}
