using LogicaAplicacion.InterfacesCasosUso.InterfacesUsuario;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.UsuarioCU
{
    public class EliminarUsuario : IEliminarUsuario
    {
        private IRepositorioUsuario RepoUsuario { get; set; }

        public EliminarUsuario(IRepositorioUsuario repoUsuario)
        {
            RepoUsuario = repoUsuario;
        }
        public void Ejecutar(int id)
        {
            RepoUsuario.Delete(id);
        }
    }
}
