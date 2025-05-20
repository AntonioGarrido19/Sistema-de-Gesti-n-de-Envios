using LogicaNegocio.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Agencia
    {
        public int Id { get; set; }
        public Nombre Nombre { get; set; }

        public string direccionPostal { get; set; }

        public UbicacionAgencia Ubicacion { get; set; }

        public List<EnvioComun> enviosComunes { get; set; }

        public Agencia()
        {

        }

        public Agencia(int id, Nombre nombre)
        {
            Id = id;
            Nombre = nombre;
        }

    }
}
