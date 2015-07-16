using Entities.WPPEntities;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPP.Persistance.BaseRepositoryClasses
{
    class Repository<T> : NHibernateBase, IRepository<T> where T : Entity
    {
        public Repository(ISessionFactory sessionFactory)
            : base(sessionFactory)
        {

        }

        public ISessionFactory SessionFactory
        {
            get { return this.sessionFactory; }
        }

        public virtual void Add(T item)
        {
            Transact(() => Session.Save(item));
        }

        public virtual void Update(T item)
        {
            Transact(() => Session.Update(item));
        }

        public virtual bool Contains(T item)
        {
            if (item.Id == default(Guid))
                return false;
            return Transact(() => Session.Get<T>(item.Id)) != null;
        }

        public virtual bool Contains(T item, string property, object value)
        {
            if (value == null)
                return false;
            ICriteria criteria = Session.CreateCriteria<T>();
            criteria.Add(Restrictions.Eq(property, value));
            T compare = Transact(() => criteria.UniqueResult<T>());
            if (compare != null)
                return (!(compare.Id == item.Id));
            return false;
        }

        public T Get(IDictionary<string, object> criterias)
        {
            ICriteria criteria = Session.CreateCriteria<T>();
            foreach (var x in criterias)
            {
                criteria.Add(Restrictions.Eq(x.Key, x.Value));
            }
            return Transact(() => criteria.UniqueResult<T>());
        }

        public T Get(Guid id)
        {
            return Transact(() => Session.Get<T>(id));
        }

        public IList<T> GetAll()
        {
            ICriteria criteria = Session.CreateCriteria<T>();
            criteria.Add(Restrictions.Not(Restrictions.Eq("IsDeleted", true)));
            return Transact(() => criteria.List<T>());
        }

        public IList<T> GetAll(IDictionary<string, object> criterias)
        {
            ICriteria criteria = Session.CreateCriteria<T>();
            foreach (var x in criterias)
            {
                criteria.Add(Restrictions.Eq(x.Key, x.Value));
            }
            return Transact(() => criteria.List<T>());
        }

        public IList<T> GetAll(IDictionary<string, object> criterias, string property, DateTime startDate, DateTime endDate)
        {
            ICriteria criteria = Session.CreateCriteria<T>();
            foreach (var x in criterias)
            {
                criteria.Add(Restrictions.Eq(x.Key, x.Value));
            }
            criteria.Add(Restrictions.Between(property, startDate, endDate));
            return Transact(() => criteria.List<T>());
        }

        public int Count
        {
            get
            {
                return Transact(() => Session.CreateCriteria<T>().List().Count);
            }
        }

        public virtual bool Remove(T item)
        {
            Transact(() => Session.Delete(item));
            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Transact(() => Session.CreateCriteria<T>().List<T>().GetEnumerator());
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Transact(() => GetEnumerator());
        }

    }
}
