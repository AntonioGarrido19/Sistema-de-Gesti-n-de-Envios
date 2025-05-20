using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.EntidadesNegocio;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioUsuario:IRepositorio<Usuario>
    {
        Usuario FindByEmailAndPassword(string email, string password);

        Usuario FindByEmail(string email);
        IEnumerable<Usuario> FindClientes();


    }
}
