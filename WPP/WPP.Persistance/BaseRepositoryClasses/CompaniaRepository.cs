using Entities.WPPEntities;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPP.Service.BaseServiceClasses;

namespace WPP.Persistance.BaseRepositoryClasses
{
    public class CompaniaRepository : ICompaniaRepository 
    {
        private UnitOfWork _unitOfWork;


        public CompaniaRepository(IUnitOfWork unitOfWork)           
        {
            _unitOfWork = (UnitOfWork)unitOfWork;
        }

        protected ISession Session { get { return _unitOfWork.Session; } }
      
        //public ISessionFactory SessionFactory
        //{
        //    get { return this.sessionFactory; }
        //}

        public virtual void Add(Compania item)
        {
            
            Session.Save(item);
       
           // Transact(() => Session.Save(item));
        }

        public virtual void Update(Compania item)
        {
            Session.Update(item);
            //Transact(() => Session.Update(item));
        }

        public virtual bool Contains(Compania item)
        {
            if (item.Id == default(Guid))
                return false;
            
            var resultado = Session.Get<Compania>(item.Id) != null;//Transact(() => Session.Get<T>(item.Id)) != null;
       
            return resultado;
        }

        public virtual bool Contains(Compania item, string property, object value)
        {
            if (value == null)
                return false;
            
            ICriteria criteria = Session.CreateCriteria<Compania>();
            criteria.Add(Restrictions.Eq(property, value));
            Compania compare = criteria.UniqueResult<Compania>();//Transact(() => criteria.UniqueResult<T>());
       
            if (compare != null)
                return (!(compare.Id == item.Id));
            return false;
        }

        public Compania Get(IDictionary<string, object> criterias)
        {
             
            ICriteria criteria = Session.CreateCriteria<Compania>();
            foreach (var x in criterias)
            {
                criteria.Add(Restrictions.Eq(x.Key, x.Value));
            }
            var resultado= criteria.UniqueResult<Compania>();
            
            return resultado;
        }

        public Compania Get(Guid id)
        {
            
            var resultado = Session.Get<Compania>(id);// Transact(() => Session.Get<T>(id));
       
            return resultado;
        }

        public IList<Compania> GetAll()
        {
             
            ICriteria criteria = Session.CreateCriteria<Compania>();
            criteria.Add(Restrictions.Not(Restrictions.Eq("IsDeleted", true)));
            var resultado = criteria.List<Compania>();//Session.Transact(() => criteria.List<T>());
       
            return resultado;
        }

        public IList<Compania> GetAll(IDictionary<string, object> criterias)
        {
            
            ICriteria criteria = Session.CreateCriteria<Compania>();
            foreach (var x in criterias)
            {
                criteria.Add(Restrictions.Eq(x.Key, x.Value));
            }
            var resultado = criteria.List<Compania>();
       
            return resultado;//Transact(() => criteria.List<T>());
        }

        public IList<Compania> GetAll(IDictionary<string, object> criterias, string property, DateTime startDate, DateTime endDate)
        {
             
            ICriteria criteria = Session.CreateCriteria<Compania>();
            foreach (var x in criterias)
            {
                criteria.Add(Restrictions.Eq(x.Key, x.Value));
            }
            criteria.Add(Restrictions.Between(property, startDate, endDate));

            var resultado = criteria.List<Compania>();//Transact(() => criteria.List<T>());
       
            return resultado;
        }

        public int Count
        {
            get
            {
                
                var resultado =  Session.CreateCriteria<Compania>().List().Count;
           
                return resultado;
            }
        }

        public virtual bool Remove(Compania item)
        {
            
            Session.Delete(item);
        
            return true;
        }

        public IEnumerator<Compania> GetEnumerator()
        {
            
            var resultado =  Session.CreateCriteria<Compania>().List<Compania>().GetEnumerator();
       
            return resultado;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return  GetEnumerator();
        }
    }
}
