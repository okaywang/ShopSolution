using SE.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE.BussinessLogic
{

    public class BussinessLogicBase<T> where T : class
    {
        protected EfRepository<T> PrimaryRepository;
        public BussinessLogicBase(EfRepository<T> repository)
        {
            PrimaryRepository = repository;
        }

        public T Get(int id)
        {
            return PrimaryRepository.Get(id);
        }

        public virtual T Insert(T entity)
        {
            return PrimaryRepository.Insert(entity);
        }

        public virtual IEnumerable<T> InsertRange(IEnumerable<T> entities)
        {
            return PrimaryRepository.InsertRange(entities);
        }

        public virtual void Update(T entity)
        {
            PrimaryRepository.Update(entity);
        }

        public void Delete(T entity)
        {
            PrimaryRepository.Delete(entity);
        }
    }
}
