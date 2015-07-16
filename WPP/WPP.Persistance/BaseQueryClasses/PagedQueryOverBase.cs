using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPP.Persistance.BaseRepositoryClasses;

namespace WPP.Persistance.BaseQueryClasses
{
    public abstract class PagedQueryOverBase<T> : NHibernateBase
    {
        public int PageNumber { get; set; }
        public int ItemsPerPage { get; set; }

        public PagedQueryOverBase(ISessionFactory sessionFactory)
            : base(sessionFactory)
        {

        }
        public override PagedResult<T> Execute()
        {
            var query = GetQuery();
            SetPaging(query);
            return Transact(() => Execute(query));
        }

        protected abstract IQueryOver<T, T> GetQuery();
        protected virtual void SetPaging(IQueryOver<T, T> query)
        {
            int maxResults = ItemsPerPage;
            int firstResult = (PageNumber - 1) * ItemsPerPage;
            query.Skip(firstResult).Take(maxResults);
        }

        protected virtual PagedResult<T> Execute(IQueryOver<T, T> query)
        {
            var results = query.Future<T>();
            var count = query.ToRowCountQuery().FutureValue<int>();
            return new PagedResult<T>()
            {
                PageOfResults = results,
                TotalItems = count.Value
            };
        }
    }
}
