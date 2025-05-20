using Compartido.DTOs.Envios;
using Compartido.DTOs.Usuarios;
using Compartido.Mappers;
using LogicaAccesoDatos.Repositorios;
using LogicaAplicacion.InterfacesCasosUso.InterfacesEnvio;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.EnvioCU
{
    public class AltaEnvioComun : IAltaEnvioComun
    {
        private IRepositorioEnvio RepositorioEnvio { get; set; }

        private IRepositorioUsuario RepositorioUsuario { get; set; }

        private IRepositorioAgencia RepositorioAgencia { get; set; }

        public AltaEnvioComun(IRepositorioEnvio repositorioEnvio, IRepositorioUsuario repositorioUsuario, IRepositorioAgencia repositorioAgencia)
        {
            RepositorioEnvio = repositorioEnvio;

            RepositorioUsuario = repositorioUsuario;

            RepositorioAgencia = repositorioAgencia;
        }


        public void Ejecutar(EnvioComunDTO envioComunDTO)
        {
          
            if (envioComunDTO == null)
            {
                throw new ArgumentNullException("Datos incorrectos");
            }
            Usuario cliente = RepositorioUsuario.FindByEmail(envioComunDTO.EmailCliente);
            Usuario empleado = RepositorioUsuario.FindById(envioComunDTO.idEmpleado);
            Agencia agencia = RepositorioAgencia.FindById(envioComunDTO.AgenciaId);
            Envio envio = MapperEnvio.EnvioComunFromEnvioDTO(envioComunDTO, cliente, empleado, agencia);
            RepositorioEnvio.Add(envio);
        }
    }
    
}
