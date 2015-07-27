using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPP.Entities.Objects.ModuloContratos;
using WPP.Persistance.BaseQueryClasses;

namespace WPP.Persistance.Paged
{
    public class PagedCompania : PagedQueryOverBase<Compania>, IPagedCompania
    {
        public string NombreCompania { get; set; }
        public string Sort { get; set; }
        public PagedCompania(ISessionFactory sessionFactory) : base(sessionFactory) { }


        protected override IQueryOver<Compania,Compania> GetQuery()
        {
          
            var query = sessionFactory.OpenSession().QueryOver<Compania>();
            query = query.Where(p => p.IsDeleted == false);

         
            return query;

        }
    }
}
