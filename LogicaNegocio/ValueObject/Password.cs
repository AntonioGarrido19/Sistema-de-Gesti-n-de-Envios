using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using LogicaNegocio.ExcepcionesEntidades;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace LogicaNegocio.ValueObject
{
    [Owned]
    public record Password
    {
        public string PasswordUsuario { get; init; }

        public Password(string passwordUsuario)
        {
            PasswordUsuario = passwordUsuario;
            Validar();
        }

        private void Validar()
        {
            if (string.IsNullOrWhiteSpace(PasswordUsuario) ||
                PasswordUsuario.Length < 8 ||
                !System.Text.RegularExpressions.Regex.IsMatch(PasswordUsuario, @"^[a-zA-Z0-9]+$"))
            {
                throw new Exception("La contraseña debe tener mínimo 8 caracteres y también incluir números y letras.");
            }
        }

    }
}
