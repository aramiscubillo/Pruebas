using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPP.Entities.Objects.ModuloContratos;

namespace WPP.Entities.Mappings.ModuloContratos
{
    public class CompaniaMapping : ClassMap<Compania>
    {
        public CompaniaMapping()
        {
            Table("Compania");
            Id(c => c.Id);
            Map(c => c.Nombre);
            Map(c => c.Cedula);
        }
    }
}
