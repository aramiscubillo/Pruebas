
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPP.Entities.Generales;

namespace WPP.Entities.Base
{
    public class Usuario : Entity
    {
        public virtual String Nombre { get; set; }
        public virtual String Apellidos { get; set; }
        public virtual DateTime FechaNac { get; set; }

        public String Email { get; set; }
        public String Password { get; set; }
        public virtual IList<String> Roles { get; set; }
    }
}
