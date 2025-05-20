using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioEnvioEF : IRepositorioEnvio
    {

        private SistemaContext Contexto { get; set; }
        public RepositorioEnvioEF(SistemaContext contexto)
        {
            Contexto = contexto;
        }

        public void Add(Envio item)
        {
            Envio envioBuscado = FindByTracking(item.Tracking);
            if (envioBuscado == null)
            {
                Contexto.Envios.Add(item);
                Contexto.SaveChanges();
            }
            else
            {
                throw new UsuarioException("Ya existe un envío con ese número de Tracking");
            }
        }

        public Envio FindByTracking(int tracking)
        {
            return Contexto.Envios
               .Where(e => e.Tracking == tracking)
               .Include(e => e.Cliente)
                    .ThenInclude(c => c.Email)
               .Include(e => e.Empleado)
                     .ThenInclude(emp => emp.Email)
               .Include(e => e.Comentarios)
               .SingleOrDefault();
        }

        public IEnumerable<Envio> FindEnProceso()
        {
            return Contexto.Envios
           .Where(e => e.Estado == EnumEstadoEnvio.EN_PROCESO)
           .Include(e => e.Cliente)
               .ThenInclude(c => c.Email)
           .Include(e => e.Empleado)
               .ThenInclude(emp => emp.Email)
           .ToList();
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Envio> FindAll()
        {
            throw new NotImplementedException();
        }

        public Envio FindById(int id)
        {
            throw new NotImplementedException();
        }


        public Envio FindByTrackingAndID(int tracking, int id)
        {
            return Contexto.Envios
                .Where(e => e.Tracking == tracking && e.Id == id)
                .Include(e => e.Cliente)
                    .ThenInclude(c => c.Email)
                .Include(e => e.Empleado)
                    .ThenInclude(emp => emp.Email)
                .SingleOrDefault();
        }

        public void Update(Envio item)
        {
            Envio envioBuscado = FindByTrackingAndID(item.Tracking, item.Id);
            if (envioBuscado != null && envioBuscado.Id == item.Id)
            {
                Contexto.Envios.Update(item);
                Contexto.SaveChanges();
            }
            else
            {
                throw new EnvioComunException("Ya existe un envio con ese numero de Tracking");
            }
        }

    
    }
}
