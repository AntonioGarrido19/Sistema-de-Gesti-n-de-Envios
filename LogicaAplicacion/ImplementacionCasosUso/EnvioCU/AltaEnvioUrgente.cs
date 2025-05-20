using Compartido.DTOs.Envios;
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
    public class AltaEnvioUrgente : IAltaEnvioUrgente
    {
        private IRepositorioEnvio RepositorioEnvio { get; set; }

        private IRepositorioUsuario RepositorioUsuario { get; set; }

        public AltaEnvioUrgente(IRepositorioEnvio repositorioEnvio, IRepositorioUsuario repositorioUsuario)
        {
            RepositorioEnvio = repositorioEnvio;

            RepositorioUsuario = repositorioUsuario;
        }


        public void Ejecutar(EnvioUrgenteDTO envioUrgenteDTO)
        {           //validar el argumento que recibe
            //llamar al mapper para convertir el DTO a entidad de negocio Carrera
            //llamar al Repositorio de carrera pasando por parametro la entidad creada 
            if (envioUrgenteDTO == null)
            {
                throw new ArgumentNullException("Datos incorrectos");
            }
            Usuario cliente = RepositorioUsuario.FindByEmail(envioUrgenteDTO.EmailCliente);
            Usuario empleado = RepositorioUsuario.FindById(envioUrgenteDTO.idEmpleado);
            Envio envio = MapperEnvio.EnvioUrgenteFromEnvioDTO(envioUrgenteDTO, cliente, empleado);
            RepositorioEnvio.Add(envio);
        }
    }
}
