
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPP.Entities.Base;
using WPP.Persistance.BaseRepositoryClasses;
using WPP.Service.BaseServiceClasses;

namespace WPP.Service.ModuloContratos
{
    public class UsuarioService : IUsuarioService//IService<Usuario>
    {
        private IRepository<Usuario> repository;
        //private readonly IQueryManager queryManager;

        public Usuario Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Usuario Get(IDictionary<string, object> criterias)
        {
            throw new NotImplementedException();
        }

        public Usuario Create(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public Usuario Update(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public bool Contains(Usuario item)
        {
            throw new NotImplementedException();
        }

        public bool Contains(Usuario item, string property, object value)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> ListAll()
        {
            throw new NotImplementedException();
        }

        public IList<Usuario> GetAll(IDictionary<string, object> criterias)
        {
            throw new NotImplementedException();
        }

        public IList<Usuario> GetAll(IDictionary<string, object> criterias, string property, DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }
    }
}
