using Entities.WPPEntities;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPP.Persistance.BaseRepositoryClasses;
using WPP.Service.BaseServiceClasses;

namespace WPP.Persistance.RepoFactory
{
    public class RepositoryFactory<T> : IRepositoryFactory<T> where T : Entity
    {
        private ISessionFactory sessionfactory;
        private UnitOfWork _unitOfWork;

        public RepositoryFactory(ISessionFactory sessionFactory)
        {
            this.sessionfactory = sessionFactory;
        }

        public IRepository<T> ResolveRepository()
        {
            IRepository<T> repository = new Repository<T>(_unitOfWork);
            return repository;
        }

        public IRepository<Usuario> GetUsuarioRepository()
        {
            IRepository<Usuario> repository = new Repository<Usuario>(_unitOfWork);
            return repository;
        }

        public IRepository<Compania> GetCompaniaRepository()
        {
            IRepository<Compania> repository = new Repository<Compania>(_unitOfWork);
            return repository;
        }

    }
}
