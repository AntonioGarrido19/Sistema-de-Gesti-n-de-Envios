using LogicaNegocio.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Auditoria
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Accion { get; set; }

        public int IdUsuario { get; set; }

        private Auditoria() { }

        public Auditoria(int id, DateTime fecha, string accion, int usuario)
        {
            Id = id;
            Fecha = fecha;
            Accion = accion;
            IdUsuario = usuario;
        }
    }
}

