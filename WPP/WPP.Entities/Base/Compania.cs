using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPP.Entities.Base
{
    public class Compania: Entity
    {
        public virtual String Nombre { get; set; }
        public virtual String Cedula { get; set; }
    }
}
