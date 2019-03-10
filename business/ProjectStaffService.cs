using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ProjectStaffService : IProjectStaffService
    {
        public ProjectStaff GetByProjectIdStaffId(int projectId, string staffId, List<string> error)
        {
            throw new NotImplementedException();
        }

        public int Update(ProjectStaff projectStaff, List<string> error)
        {
            throw new NotImplementedException();
        }

        public bool Validate(ProjectStaff projectStaff, List<string> error)
        {
            throw new NotImplementedException();
        }
    }
}
