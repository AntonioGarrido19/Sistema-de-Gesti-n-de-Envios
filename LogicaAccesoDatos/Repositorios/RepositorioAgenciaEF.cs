using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioAgenciaEF : IRepositorioAgencia
    {
        private SistemaContext Contexto {  get; set; }
        public RepositorioAgenciaEF(SistemaContext contexto)
        {
            Contexto = contexto;
        }
        public void Add(Agencia item)
        {      
            Agencia agenciaBuscada = FindById(item.Id);
            if (agenciaBuscada == null)
            {
                Contexto.Agencias.Add(item);
                Contexto.SaveChanges();
            }
            else
            {
                throw new UsuarioException("Ya existe un usuario con ese nombre");
            }
        }

        private Agencia FindByDireccionPostal(string direccion)
        {
            return Contexto.Agencias
                        .Where(a => a.direccionPostal == direccion)
                        .SingleOrDefault();
        }


        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Agencia> FindAll()
        {
            return Contexto.Agencias;
        }

        public Agencia FindById(int id)
        {
            return Contexto.Agencias.Find(id);
        }

        public void Update(Agencia item)
        {
            throw new NotImplementedException();
        }
    }
}
