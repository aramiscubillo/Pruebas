using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPP.Entities.Generales;
using WPP.Persistance.BaseRepositoryClasses;

namespace WPP.Service.Generales
{
     public class CatalogoService : ICatalogoService
    {
         private IRepository<Catalogo> repository;
         public CatalogoService(IRepository<Catalogo> _repository)
        {
            repository = _repository;
        }

        public Entities.Generales.Catalogo Get(Guid id)
        {
            return repository.Get(id);
        }

        public Entities.Generales.Catalogo Get(IDictionary<string, object> criterias)
        {
            return repository.Get(criterias);
        }

        public Entities.Generales.Catalogo Create(Entities.Generales.Catalogo entity)
        {
            repository.Add(entity);
            return entity;
        }

        public Entities.Generales.Catalogo Update(Entities.Generales.Catalogo entity)
        {
            repository.Update(entity);
            return entity;
        }

        public void Delete(Entities.Generales.Catalogo entity)
        {
            repository.Remove(entity);
        }

        public bool Contains(Entities.Generales.Catalogo item)
        {
            return repository.Contains(item);
        }

        public bool Contains(Entities.Generales.Catalogo item, string property, object value)
        {
            return repository.Contains(item, property, value);
        }

        public IEnumerable<Entities.Generales.Catalogo> ListAll()
        {
            return repository.GetAll();
        }

        public IList<Entities.Generales.Catalogo> GetAll(IDictionary<string, object> criterias)
        {
            return repository.GetAll(criterias);
        }

        public IList<Entities.Generales.Catalogo> GetAll(IDictionary<string, object> criterias, string property, DateTime startDate, DateTime endDate)
        {
            return repository.GetAll(criterias, property, startDate, endDate);
        }

        public int Count()
        {
            return repository.Count<Catalogo>();
        }
    }
}
