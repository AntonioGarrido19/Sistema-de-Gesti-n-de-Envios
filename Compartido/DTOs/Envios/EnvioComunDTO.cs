using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.Envios
{
    public class EnvioComunDTO
    {
        public string EmailCliente {  get; set; }
        //public int IdCliente {get;set;}
        public int idEmpleado { get; set; }
        public int Tracking { get; set; }
        public float Peso { get; set; }
        public int AgenciaId { get; set; }
    }
}
