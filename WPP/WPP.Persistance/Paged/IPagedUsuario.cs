
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPP.Persistance.BaseQueryClasses;

namespace WPP.Persistance.Paged
{
    public interface IPagedUsuario
    {
        string NombreMedicamento { get; set; }
        string Sort { get; set; }
    }
}
