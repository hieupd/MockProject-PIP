using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IService<T>
    {
        int Insert(T item, List<string> error);
        int Update(T item, List<string> error);
        ICollection<T> GetAll(List<string> error);
        T GetById(object id, List<string> error);
        bool Validate(T item, List<string> error);
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}
