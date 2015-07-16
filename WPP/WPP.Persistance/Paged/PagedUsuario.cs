using Entities.WPPEntities;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPP.Persistance.BaseQueryClasses;

namespace WPP.Persistance.Paged
{
    public class PagedUsuario : PagedQueryOverBase<Usuario>, IPagedUsuario
    {
        public string NombreMedicamento { get; set; }
        public string Sort { get; set; }
        public PagedUsuario(ISessionFactory sessionFactory) : base(sessionFactory) { }


        protected override IQueryOver<Usuario, Usuario> GetQuery()
        {
          
            var query = sessionFactory.OpenSession().QueryOver<Usuario>();
            query = query.Where(p => p.IsDeleted == false);

         
            return query;

        }

    }
}
