using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using LogicaNegocio.ExcepcionesEntidades;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;


namespace LogicaNegocio.ValueObject
{
    [Owned]
    public class Cedula
    {
   
        public string CedulaUsuario { get; init; }
        
        public Cedula(string cedulaUsuario)
        {
            CedulaUsuario = cedulaUsuario;
            Validar();
        }

        public void Validar()
        {
            if (CedulaUsuario.Length != 8 || !CedulaUsuario.All(char.IsDigit))
            {
                throw new UsuarioException("Por favor agregue su cedula sin putos ni guiones, con su digito verificador al final");
            }
            else if (DigitoVerificador(CedulaUsuario) != int.Parse(CedulaUsuario.Substring(CedulaUsuario.Length - 1)))
            {
                throw new UsuarioException("La cedula ingresada no es valida");
            }

        }

        public int DigitoVerificador(string cedula)
        {
            int resultado = 0;
            int[] coeficientes = { 2, 9, 8, 7, 6, 3, 4 };

            for (int i = 0; i < 7; i++)
            {
                int digitoCedula = int.Parse(cedula.Substring(i, 1));
                resultado += (digitoCedula * coeficientes[i]);
            }
            return (10 - (resultado % 10)) % 10;
        }
    }
}
