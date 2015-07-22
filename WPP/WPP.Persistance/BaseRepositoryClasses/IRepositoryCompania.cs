using Entities.WPPEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPP.Persistance.BaseRepositoryClasses
{
    public interface ICompaniaRepository : IEnumerable<Compania> 
    {
        void Add(Compania item);
        void Update(Compania item);
        bool Contains(Compania item);
        bool Contains(Compania item, string property, object value);
        bool Remove(Compania item);
        Compania Get(IDictionary<string, object> criterias);
        Compania Get(Guid id);
        IList<Compania> GetAll();
        IList<Compania> GetAll(IDictionary<string, object> criterias);
        IList<Compania> GetAll(IDictionary<string, object> criterias, string property, DateTime startDate, DateTime endDate);
        int Count { get; }
    
    }
}
