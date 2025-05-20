using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class EnvioUrgente: Envio
    {
        public string DireccionPostal {  get; set; }

        public Boolean Eficiente { get; set; }

   

        public EnvioUrgente(Usuario cliente, Usuario empleado, int tracking, float peso, string direccionPostal)
      : base(cliente, empleado, tracking, peso)
        {

            DireccionPostal = direccionPostal;

            Eficiente = false;
        }

        protected EnvioUrgente(): base() { }

    }
}
