using Entities.WPPEntities;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPP.Persistance.BaseRepositoryClasses;
using WPP.Persistance.RepoFactory;

namespace WPP.Service.BaseServiceClasses
{
    public class ServiceFactory<T> : IServiceFactory<T> where T : Entity
    {
        private ISessionFactory sessionFactory;

        private IRepositoryFactory<T> factory;
        public IRepositoryFactory<T> Factory
        {
            get
            {
                if (factory == null)
                    factory = new RepositoryFactory<T>(sessionFactory);
                return factory;
            }
        }

        public ServiceFactory(ISessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory;
        }

        public IService<T> ResolveService()
        {
            //IQueryManager queryManager = new QueryManager(sessionFactory);
            IRepository<T> repository = Factory.ResolveRepository();
            IService<T> service = new Service<T>(repository);

            return service;
        }

        public IService<Usuario> GetUsuarioService()
        {
            //IQueryManager queryManager = new QueryManager(sessionFactory);
            IRepository<Usuario> repository = Factory.GetUsuarioRepository();
            IService<Usuario> service = new Service<Usuario>(repository);

            return service;
        }
    }
}
