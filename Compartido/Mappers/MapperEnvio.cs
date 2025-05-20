using Compartido.DTOs.Envios;
using Compartido.DTOs.Usuarios;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.Mappers
{
    public class MapperEnvio
    {

        public static Envio EnvioComunFromEnvioDTO(EnvioComunDTO envioComunDTO, Usuario cliente, Usuario empleado, Agencia agencia )
        {
            if (envioComunDTO == null)
            {
                throw new ArgumentNullException("Datos incorrectos");
            }

            return new EnvioComun(
                              cliente,
                              empleado,
                              envioComunDTO.Tracking,
                              envioComunDTO.Peso,
                              agencia);


            //return new EnvioComun() { Cliente= cliente ,Tracking=envioComunDTO.Tracking,Peso=envioComunDTO.Peso,Agencia=envioComunDTO.Agencia};
        }

        public static Envio EnvioUrgenteFromEnvioDTO(EnvioUrgenteDTO envioUrgenteDTO, Usuario cliente, Usuario empleado)
        {
            if (envioUrgenteDTO == null)
            {
                throw new ArgumentNullException("Datos incorrectos");
            }

            return new EnvioUrgente(
                              cliente,
                              empleado,
                              envioUrgenteDTO.Tracking,
                              envioUrgenteDTO.Peso,
                              envioUrgenteDTO.DireccionPostal);


            //return new EnvioComun() { Cliente= cliente ,Tracking=envioComunDTO.Tracking,Peso=envioComunDTO.Peso,Agencia=envioComunDTO.Agencia};
        }

        
        public static List<EnvioDTO> ListEnvioProcesoToListEnvioDTO
        (List<Envio> envios)
        {
            List<EnvioDTO> envioDTO = new List<EnvioDTO>();
            foreach (Envio e in envios)
            {
                envioDTO.Add(new EnvioDTO()
                {
                    EmailCliente = e.Cliente.Email.EmailUsuario,
                    EmailEmpleado = e.Empleado.Email.EmailUsuario,
                    Tracking = e.Tracking,
                    Peso = e.Peso,
                    Fecha = e.Fecha
                });
            }
            return envioDTO;
        }




        public static EnvioDTO EnvioDTOFromEnvio(Envio envio)
        {
            return new EnvioDTO()
            {
                EmailCliente = envio.Cliente.Email.EmailUsuario,
                EmailEmpleado = envio.Empleado.Email.EmailUsuario,
                Tracking = envio.Tracking,
                Peso = envio.Peso,
                Fecha = envio.Fecha,
                Comentarios = envio.Comentarios

            };

        }

        public static Envio FinalizarEnvioDTOToEnvio(FinalizarEnvioDTO finalizarEnvioDTO, Envio envio)
        {

            if (finalizarEnvioDTO == null || envio == null)
            {
                throw new ArgumentNullException("Datos incorrectos");
            }

            envio.Estado = EnumEstadoEnvio.FINALIZADO;
            envio.Fecha = DateTime.Now;

            return envio;
        }

        public static FinalizarEnvioDTO FinalizarEnvioDTOFromEnvio(Envio e)
        {

            return new FinalizarEnvioDTO()
            {
                EmailCliente = e.Cliente.Email.EmailUsuario,
                EmailEmpleado = e.Empleado.Email.EmailUsuario,
                Tracking = e.Tracking,
                Peso = e.Peso,
                Fecha = e.Fecha,
                Estado = e.Estado

            };        
          }


        public static Comentario ComentarioFromComentarioDTO(ComentarioDTO comentarioDTO) {

            if (comentarioDTO == null)
            {
                throw new ArgumentNullException("Datos incorrectos");
            }

            return new Comentario(comentarioDTO.EmpleadoId, comentarioDTO.Fecha, comentarioDTO.Contenido);
        }

    }

    
}
