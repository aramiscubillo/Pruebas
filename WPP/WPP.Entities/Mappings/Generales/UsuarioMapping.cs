﻿
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPP.Entities.Objects.Generales;

namespace WPP.Entities.Mappings.Generales
{
    public class UsuarioMapping : ClassMap<Usuario>
    {
        public UsuarioMapping()
        {
            Table("Usuario"); 
            Id(c => c.Id);
            Version(u => u.Version);
            Map(u => u.CreateDate).Not.Nullable();
            Map(u => u.DateLastModified).Nullable();
            Map(u => u.IsDeleted).Not.Nullable();
            Map(r => r.Nombre).Not.Nullable();
            Map(r => r.Apellidos).Not.Nullable();
            Map(r => r.FechaNac).Not.Nullable();
            Map(r => r.Email).Not.Nullable();
            Map(r => r.Password).Not.Nullable();
            Map(r => r.Roles).Not.Nullable();

        }
    }
}
