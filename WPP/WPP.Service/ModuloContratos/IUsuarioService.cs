
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPP.Entities.Base;

namespace WPP.Service.ModuloContratos
{
    public interface IUsuarioService 
    {
        Usuario Get(Guid id);
        Usuario Get(IDictionary<string, object> criterias);
        Usuario Create(Usuario entity);
        Usuario Update(Usuario entity);
        void Delete(Usuario entity);
        bool Contains(Usuario item);
        bool Contains(Usuario item, string property, object value);
        IEnumerable<Usuario> ListAll();
        IList<Usuario> GetAll(IDictionary<string, object> criterias);
        IList<Usuario> GetAll(IDictionary<string, object> criterias, string property, DateTime startDate, DateTime endDate);

        int Count();
    }
}
