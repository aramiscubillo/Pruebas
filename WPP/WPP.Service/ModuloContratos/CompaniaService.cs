using Entities.WPPEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPP.Persistance.BaseRepositoryClasses;
using WPP.Persistance.RepoFactory;

namespace WPP.Service.ModuloContratos
{
    public class CompaniaService: ICompaniaService
    {
        private IRepository<Compania> repository;
        //private IRepositoryFactory<Compania> repositoryFactory;
        //private readonly IQueryManager queryManager;
     
        public CompaniaService(IRepository<Compania> companiaRepository)
        {
            repository = companiaRepository;
        }

        public Compania Get(Guid id)
        {
            return repository.Get(id);
        }

        public Compania Get(IDictionary<string, object> criterias)
        {
            return repository.Get(criterias);
        }

        public Compania Create(Compania entity)
        {
            repository.Add(entity);
            return entity;
        }

        public Compania Update(Compania entity)
        {
            repository.Update(entity);
            return entity;
        }

        public void Delete(Compania entity)
        {
            repository.Remove(entity);
        }

        public bool Contains(Compania item)
        {
            return repository.Contains(item);
        }

        public bool Contains(Compania item, string property, object value)
        {
            return repository.Contains(item, property, value);
        }

        public IEnumerable<Compania> ListAll()
        {
            return repository.GetAll();
        }

        public IList<Compania> GetAll(IDictionary<string, object> criterias)
        {
            return repository.GetAll(criterias);
        }

        public IList<Compania> GetAll(IDictionary<string, object> criterias, string property, DateTime startDate, DateTime endDate)
        {
            return repository.GetAll(criterias, property, startDate, endDate);
        }

        public int Count()
        {
            return repository.Count<Compania>();
        }
    }
}


