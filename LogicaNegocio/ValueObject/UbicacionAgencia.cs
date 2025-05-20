using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using LogicaNegocio.ExcepcionesEntidades;
using Microsoft.EntityFrameworkCore;

namespace LogicaNegocio.ValueObject
{
    [Owned]
    public record UbicacionAgencia
    {
        public int Latitud {  get; init; }
        public int Longitud { get; init; }

        public UbicacionAgencia(int latitud, int longitud) 
        {
            Latitud = latitud;
            Longitud = longitud;
            Validar();
        }

        public void Validar()
        {
            
        }
    }
}
