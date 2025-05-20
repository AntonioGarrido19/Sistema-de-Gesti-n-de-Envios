
using Compartido.DTOs.Envios;
using Compartido.DTOs.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCasosUso.InterfacesEnvio
{
    public interface IBuscarEnvio
    {
        FinalizarEnvioDTO Ejecutar(int tracking);
        EnvioDTO EjecutarComentarios(int tracking);

        //ComentarioDTO EjecutarComentario(int tracking);
    }
}
