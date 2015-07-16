using Entities.WPPEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPP.Service.BaseServiceClasses
{
    public interface IServiceFactory<T> where T : Entity
    {
        IService<T> ResolveService();
        IService<Usuario> GetUsuarioService();
    }
}
