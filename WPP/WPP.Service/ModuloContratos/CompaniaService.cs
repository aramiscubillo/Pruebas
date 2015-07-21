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
            throw new NotImplementedException();
        }

        public Compania Get(IDictionary<string, object> criterias)
        {
            throw new NotImplementedException();
        }

        public Compania Create(Compania entity)
        {
            repository.Add(entity);
            return entity;
        }

        public Compania Update(Compania entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Compania entity)
        {
            throw new NotImplementedException();
        }

        public bool Contains(Compania item)
        {
            throw new NotImplementedException();
        }

        public bool Contains(Compania item, string property, object value)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Compania> ListAll()
        {
            throw new NotImplementedException();
        }

        public IList<Compania> GetAll(IDictionary<string, object> criterias)
        {
            throw new NotImplementedException();
        }

        public IList<Compania> GetAll(IDictionary<string, object> criterias, string property, DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }
    }
}


