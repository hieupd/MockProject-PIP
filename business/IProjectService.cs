using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IProjectService
    {
        int Insert(Project item, IDictionary<string, string> staffIds, List<string> error);
        int Update(Project item, IDictionary<string, string> staffIds,List<string> error);
        ICollection<Project> GetAll(List<string> error);
        Project GetById(object id, List<string> error);
        bool Validate(Project item, List<string> error);
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        IEnumerable<Staff> GetAllStaffByProjectId(object projectId);
    }
}
