using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepository<T>
    {
        void Insert(T item);
        void Update(T item);
        void Delete(object Id);
        IQueryable<T> GetAll();
        T GetById(object id);
        int Save();
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}
