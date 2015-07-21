using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPP.Persistance.Paged
{
    public interface IPagedCompania
    {
        string NombreCompania { get; set; }
        string Sort { get; set; }
    }
}
