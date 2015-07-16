﻿using Entities.WPPEntities;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPP.Persistance.BaseRepositoryClasses;

namespace WPP.Persistance.RepoFactory
{
    public class RepositoryFactory<T> : IRepositoryFactory<T> where T : Entity
    {
        private ISessionFactory sessionfactory;

        public RepositoryFactory(ISessionFactory sessionFactory)
        {
            this.sessionfactory = sessionFactory;
        }

        public IRepository<T> ResolveRepository()
        {
            IRepository<T> repository = new Repository<T>(sessionfactory);
            return repository;
        }

        public IRepository<Usuario> GetUsuarioRepository()
        {
            IRepository<Usuario> repository = new Repository<Usuario>(sessionfactory);
            return repository;
        }

       
    }
}
