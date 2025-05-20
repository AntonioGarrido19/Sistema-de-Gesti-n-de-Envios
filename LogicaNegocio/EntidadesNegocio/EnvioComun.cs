using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class EnvioComun : Envio
    {
        
        public Agencia Agencia { get; set; }


        public EnvioComun(Usuario cliente, Usuario empleado, int tracking, float peso, Agencia agencia)
        : base(cliente, empleado, tracking, peso)
        {
            Agencia = agencia;
        }


        protected EnvioComun() : base() { }
    }
}
