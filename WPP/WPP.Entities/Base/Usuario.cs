
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPP.Entities.Base
{
    public class Usuario : Entity
    {
        public virtual String Nombre { get; set; }
        public virtual String Apellido { get; set; }
        public virtual String Password { get; set; }
        public virtual String Email { get; set; }
    }
}
