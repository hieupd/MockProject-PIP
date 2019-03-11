using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class Initialaze:DropCreateDatabaseAlways<DbStaffContext>
    {
        protected override void Seed(DbStaffContext context)
        {
            List<JobRank> jobranks = new List<JobRank>
            {
                new JobRank{JobRankName="dev 1"},
                new JobRank{JobRankName="test 1"},
                new JobRank{JobRankName="BA 1"},
                new JobRank{JobRankName="QA 1"},
            };
            context.JobRanks.AddRange(jobranks);

            List<Department> departments = new List<Department>
            {
                new Department{DepartmentName="dept 1"},
                new Department{DepartmentName="dept 1"},
                new Department{DepartmentName="dept 1"},
                new Department{DepartmentName="dept 1"},
            };
            context.JobRanks.AddRange(jobranks);

            List<Staff> staffs = new List<Staff>
            {
                new Staff{StaffName="nv1",CardNumber="1",Salary=1000,JobRankId=1},
                new Staff{StaffName="nv2",CardNumber="2",Salary=2000,JobRankId=2},
                new Staff{StaffName="nv3",CardNumber="3",Salary=3000,JobRankId=3},
            };

            base.Seed(context);
        }
    }
}
