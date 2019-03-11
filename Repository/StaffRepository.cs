using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class StaffRepository:Repository<Staff>,IStaffRepository
    {
        Repository<Department> _deptRepos = new Repository<Department>();
        Repository<JobRank> _jRankRepos = new Repository<JobRank>();
        public List<Department> GetDepartments()
        {
            return _deptRepos.GetAll().ToList();
        }
        public List<JobRank> GetJobRanks()
        {
            return _jRankRepos.GetAll().ToList();
        }
    }
}
