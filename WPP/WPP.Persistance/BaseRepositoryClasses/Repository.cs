﻿using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPP.Entities.Objects.Base;
using WPP.Service.BaseServiceClasses;

namespace WPP.Persistance.BaseRepositoryClasses
{
    public class Repository<T> :  IRepository<T> where T : Entity
    {
        private UnitOfWork _unitOfWork;


        public Repository(IUnitOfWork unitOfWork)           
        {
            _unitOfWork = (UnitOfWork)unitOfWork;
        }

        protected ISession Session { get { return _unitOfWork.Session; } }
      
        //public ISessionFactory SessionFactory
        //{
        //    get { return this.sessionFactory; }
        //}

        public virtual void Add(T item)
        {
            
            Session.Save(item);
       
           // Transact(() => Session.Save(item));
        }

        public virtual void Update(T item)
        {
            Session.Update(item);
            //Transact(() => Session.Update(item));
        }

        public virtual bool Contains(T item)
        {
            if (item.Id == default(Guid))
                return false;
            
            var resultado = Session.Get<T>(item.Id) != null;//Transact(() => Session.Get<T>(item.Id)) != null;
       
            return resultado;
        }

        public virtual bool Contains(T item, string property, object value)
        {
            if (value == null)
                return false;
            
            ICriteria criteria = Session.CreateCriteria<T>();
            criteria.Add(Restrictions.Eq(property, value));
            T compare = criteria.UniqueResult<T>();//Transact(() => criteria.UniqueResult<T>());
       
            if (compare != null)
                return (!(compare.Id == item.Id));
            return false;
        }

        public T Get(IDictionary<string, object> criterias)
        {

            if (!Session.IsOpen)
            {
                _unitOfWork.BeginTransaction();
            }

            ICriteria criteria = Session.CreateCriteria<T>();
           
            foreach (var x in criterias)
            {
                criteria.Add(Restrictions.Eq(x.Key, x.Value));
            }


            var resultado = criteria.UniqueResult<T>();

            if (!Session.IsOpen)
            {
                _unitOfWork.Commit();
            }

            return resultado;            
            //return resultado.FirstOrDefault<T>();
        }

        public T Get(Guid id)
        {
            
            var resultado = Session.Get<T>(id);// Transact(() => Session.Get<T>(id));
       
            return resultado;
        }

        public IList<T> GetAll()
        {
             
            ICriteria criteria = Session.CreateCriteria<T>();
            criteria.Add(Restrictions.Not(Restrictions.Eq("IsDeleted", true)));
            var resultado = criteria.List<T>();//Session.Transact(() => criteria.List<T>());
       
            return resultado;
        }

        public IList<T> GetAll(IDictionary<string, object> criterias)
        {
            
            ICriteria criteria = Session.CreateCriteria<T>();
            foreach (var x in criterias)
            {
                criteria.Add(Restrictions.Eq(x.Key, x.Value));
            }
            var resultado = criteria.List<T>();
       
            return resultado;//Transact(() => criteria.List<T>());
        }

        public IList<T> GetAll(IDictionary<string, object> criterias, string property, DateTime startDate, DateTime endDate)
        {
             
            ICriteria criteria = Session.CreateCriteria<T>();
            foreach (var x in criterias)
            {
                criteria.Add(Restrictions.Eq(x.Key, x.Value));
            }
            criteria.Add(Restrictions.Between(property, startDate, endDate));

            var resultado = criteria.List<T>();//Transact(() => criteria.List<T>());
       
            return resultado;
        }

        public int Count
        {
            get
            {
                
                var resultado =  Session.CreateCriteria<T>().List().Count;
           
                return resultado;
            }
        }

        public virtual bool Remove(T item)
        {
            
            Session.Delete(item);
        
            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            
            var resultado =  Session.CreateCriteria<T>().List<T>().GetEnumerator();
       
            return resultado;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return  GetEnumerator();
        }

    }
}
