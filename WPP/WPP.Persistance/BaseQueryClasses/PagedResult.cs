using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPP.Persistance.BaseQueryClasses
{
    public class PagedResult<T>
    {
        public int TotalItems { get; set; }
        public IEnumerable<T> PageOfResults { get; set; }
    }
}
