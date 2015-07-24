using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPP.Entities.Objects.Base;

namespace WPP.Entities.Objects.ModuloContratos
{
    public class Compania: Entity
    {
        public virtual String Nombre { get; set; }
        public virtual String Cedula { get; set; }
    }
}
