using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using LogicaNegocio.ExcepcionesEntidades;
using System.Drawing;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace LogicaNegocio.ValueObject
{
    [Owned]
    public class Email
    {
        public string EmailUsuario { get; init; }

        public Email(string emailUsuario)
        {
            EmailUsuario = emailUsuario;
            Validar();
        }

        public void Validar()
        {
            if (string.IsNullOrWhiteSpace(EmailUsuario))
            {
                throw new UsuarioException("El email no puede estar vacío.");
            }

            if (EmailUsuario.Length < 5)
            {
                throw new UsuarioException("El email debe tener al menos 5 caracteres.");
            }

            // Validación de formato usando expresión regular simple
            string patronEmail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(EmailUsuario, patronEmail))
            {
                throw new UsuarioException("El formato del email no es válido.");
            }
        }
    }
}