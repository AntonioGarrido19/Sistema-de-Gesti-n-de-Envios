using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ExcepcionesEntidades
{
    public class EnvioComunException:Exception
    {
        public EnvioComunException() { }
        public EnvioComunException(string message) : base(message) { }
        public EnvioComunException(string message, Exception innerException) : base(message, innerException) { }
    }
}
