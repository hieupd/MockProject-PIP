using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IProjectStaffService
    {
        int Update(ProjectStaff projectStaff, List<string> error);
        ProjectStaff GetByProjectIdStaffId (int projectId,string staffId,List<string> error);
        bool Validate(ProjectStaff projectStaff, List<string> error);
    }
}
