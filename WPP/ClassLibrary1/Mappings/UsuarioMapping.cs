using Entities.WPPEntities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Mappings
{
    public class UsuarioMapping : ClassMap<Usuario>
    {
        public UsuarioMapping()
        {
            Id(c => c.Id);
            Map(c => c.Nombre);
        }
    }
}
