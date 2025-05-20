using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioAuditoriaEF : IRepositorioAuditoria
    {
        private SistemaContext Contexto { get; set; }
        public RepositorioAuditoriaEF(SistemaContext contexto)
        {
            Contexto = contexto;
        }
        public void Add(Auditoria item)
        {
            Contexto.Auditorias.Add(item);
            Contexto.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Auditoria> FindAll()
        {
            throw new NotImplementedException();
        }

        public Auditoria FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Auditoria item)
        {
            throw new NotImplementedException();
        }
    }
}

