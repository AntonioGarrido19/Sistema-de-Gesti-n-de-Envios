using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public abstract class Envio
    {

        public int Id { get; set; }
 
        public Usuario Cliente {get;set;}
        
        public Usuario Empleado {get;set;}

        public int Tracking {  get; set; }

        public float Peso {  get; set; }

        public EnumEstadoEnvio Estado   { get; set; }

        public List<Comentario> Comentarios { get; set; } = new List<Comentario>();

        public DateTime Fecha { get; set; }


        public Envio(Usuario cliente, Usuario empleado, int tracking, float peso) 
        {
            Cliente = cliente;
            Empleado = empleado;
            Tracking = tracking;
            Peso = peso;
            Estado = EnumEstadoEnvio.EN_PROCESO;
            Fecha = DateTime.Now;
        }

        protected Envio() { }
   
    }

}
