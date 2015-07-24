
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPP.Entities.Objects.ModuloContratos;

namespace WPP.Service.ModuloContratos
{
    public interface ICompaniaService
    {
        Compania Get(Guid id);
        Compania Get(IDictionary<string, object> criterias);
        Compania Create(Compania entity);
        Compania Update(Compania entity);
        void Delete(Compania entity);
        bool Contains(Compania item);
        bool Contains(Compania item, string property, object value);
        IEnumerable<Compania> ListAll();
        IList<Compania> GetAll(IDictionary<string, object> criterias);
        IList<Compania> GetAll(IDictionary<string, object> criterias, string property, DateTime startDate, DateTime endDate);

        int Count();
    }
}
