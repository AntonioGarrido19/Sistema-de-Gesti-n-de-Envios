using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Comentario
    {

        public int Id { get; set; }

        //public int Tracking { get; set; } 
        public int EmpleadoId { get; set; }

        public DateTime Fecha { get; set; }

        public string Contenido { get; set; }


        public Comentario(int empleadoId, DateTime fecha, string contenido)
        {
            EmpleadoId = empleadoId;
            Fecha = fecha;
            Contenido = contenido;
        }
    }
}
