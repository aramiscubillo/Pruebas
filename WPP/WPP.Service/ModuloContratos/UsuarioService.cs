
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
        //private ICompaniaRepository repository;
        //private IRepositoryFactory<Compania> repositoryFactory;
        //private readonly IQueryManager queryManager;

          public UsuarioService(IRepository<Usuario> _repository)
        {
            repository = _repository;
        }


        //public CompaniaService(ICompaniaRepository companiaRepository)
        //{
        //    repository = companiaRepository;
        //}

          public Usuario Get(Guid id)
        {
            return repository.Get(id);
        }

          public Usuario Get(IDictionary<string, object> criterias)
        {
            return repository.Get(criterias);
        }

          public Usuario Create(Usuario entity)
        {
            repository.Add(entity);
            return entity;
        }

          public Usuario Update(Usuario entity)
        {
            repository.Update(entity);
            return entity;
        }

          public void Delete(Usuario entity)
        {
            repository.Remove(entity);
        }

          public bool Contains(Usuario item)
        {
            return repository.Contains(item);
        }

          public bool Contains(Usuario item, string property, object value)
        {
            return repository.Contains(item, property, value);
        }

          public IEnumerable<Usuario> ListAll()
        {
            return repository.GetAll();
        }

          public IList<Usuario> GetAll(IDictionary<string, object> criterias)
        {
            return repository.GetAll(criterias);
        }

          public IList<Usuario> GetAll(IDictionary<string, object> criterias, string property, DateTime startDate, DateTime endDate)
        {
            return repository.GetAll(criterias, property, startDate, endDate);
        }

        public int Count()
        {
            return repository.Count<Usuario>();
        }
    }
}
