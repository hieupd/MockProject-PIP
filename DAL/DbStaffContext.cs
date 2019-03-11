using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DbStaffContext:DbContext
    {
        public DbStaffContext():base()
        {
            Database.SetInitializer(new Initialaze());
        }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<JobRank> JobRanks { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectStaff> ProjectStaff { get; set; }
        public DbSet<ClaimRequest> ClaimRequests { get; set; }
        public DbSet<ClaimRequestDetail> ClaimRequestDetails { get; set; }
    }
}
