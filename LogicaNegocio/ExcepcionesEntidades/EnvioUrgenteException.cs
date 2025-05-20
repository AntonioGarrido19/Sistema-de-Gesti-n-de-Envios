using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ExcepcionesEntidades
{
    public class EnvioUrgenteException:Exception
    {
        public EnvioUrgenteException() { }
        public EnvioUrgenteException(string message) : base(message) { }
        public EnvioUrgenteException(string message, Exception innerException) : base(message, innerException) { }
    }
}
