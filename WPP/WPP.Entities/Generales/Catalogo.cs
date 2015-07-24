using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPP.Entities.Base;

namespace WPP.Entities.Generales
{
    public class Catalogo : Entity
    {
        public virtual String Nombre { get; set; }
        public virtual String Tipo { get; set; }
    }
}
