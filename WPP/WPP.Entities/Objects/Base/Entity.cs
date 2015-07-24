using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPP.Entities.Objects.Base
{
    public abstract class Entity
    {
        public virtual Guid Id { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual int Version { get; set; }
        public virtual DateTime DateLastModified { get; set; }
    }
}
