using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPP.Entities.Base;

namespace WPP.Entities.Mappings
{
    public class CompaniaMapping : ClassMap<Compania>
    {
        public CompaniaMapping()
        {
            Id(c => c.Id);
            Map(c => c.Nombre);
            Map(c => c.Cedula);
        }
    }
}
