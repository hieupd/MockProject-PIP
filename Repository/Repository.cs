using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DbStaffContext _context;
        private DbSet<T> _dbset;
        private DbContextTransaction transaction;

        public Repository()
        {
            _context = new DbStaffContext();
            _dbset = _context.Set<T>();
        }
        public void Insert(T item)
        {
            _dbset.Add(item);
        }

        public void Delete(object id)
        {
            var obj = (T)_dbset.Find(id);
            _dbset.Remove(obj);
        }
        public IQueryable<T> GetAll()
        {
            return _dbset;
        }

        public T GetById(object id)
        {
            var obj = _dbset.Find(id);
            if (obj == null)
            {
                return null;
            }
            return (T)obj;
        }
        public void Update(T item)
        {
            _dbset.AddOrUpdate(item);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void BeginTransaction()
        {
            transaction = _context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            transaction.Commit();
        }

        public void RollbackTransaction()
        {
            transaction.Rollback();
        }
    }
}
