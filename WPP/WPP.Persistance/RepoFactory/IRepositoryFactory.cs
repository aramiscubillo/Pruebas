using Entities.WPPEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPP.Persistance.BaseRepositoryClasses;

namespace WPP.Persistance.RepoFactory
{
    public interface IRepositoryFactory<T>  where T : Entity
    {
        IRepository<T> ResolveRepository();
        IRepository<Usuario> GetUsuarioRepository();
    }
}
