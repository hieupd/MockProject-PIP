using DTO;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class StaffService : IStaffService
    {
        private StaffRepository _repos = new StaffRepository();
        public int Insert(Staff item, List<string> error)
        {
            if (!Validate(item, error))
            {
                return 0;
            }
            _repos.Insert(item);
            var result = _repos.Save();
            if (result == 0)
            {
                return 0;
            }
            return result;
        }

        public int Delete(object Id, List<string> error)
        {
            int id;
            if (!int.TryParse(Id.ToString(), out id))
            {
                return 0;
            }
            List<Staff> staffs = GetAll(null).ToList();
            foreach (var item in staffs)
            {
                if (item.StaffId == id.ToString())
                {
                    _repos.Delete(Id);
                    return _repos.Save();
                }
            }
            return 0;
        }

        public ICollection<Staff> GetAll(List<string> error)
        {
            return _repos.GetAll().ToList();
        }

        public Staff GetById(object id, List<string> error)
        {
            var staff = _repos.GetById(id);
            if (staff == null)
            {
                return null;
            }
            return staff;
        }

        public int Update(Staff item, List<string> error)
        {
            if (!Validate(item, null))
            {
                return 0;
            }
            _repos.Update(item);
            var result = _repos.Save();
            if (result == 0)
            {
                return 0;
            }
            return result;
        }

        public bool Validate(Staff item, List<string> error)
        {
            List<Department> depts = _repos.GetDepartments();
            List<JobRank> jRanks = _repos.GetJobRanks();
            if (item.StaffName is null || item.CardNumber is null || item.Email is null || item.JobRankId <= 0 || item.DepartmentId <= 0 || item.Salary < 0)
            {
                return false;
            }
            if (item.StaffName.Length > 200 || item.CardNumber.Length > 50 || item.Email.Length > 50)
            {
                return false;
            }
            return true;
        }
        public void BeginTransaction()
        {
            _repos.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _repos.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            _repos.RollbackTransaction();
        }
        
    }
}
