using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ProjectService : IProjectService
    {
        public void BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public void CommitTransaction()
        {
            throw new NotImplementedException();
        }

        public ICollection<Project> GetAll(List<string> error)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Staff> GetAllStaffByProjectId(object projectId)
        {
            throw new NotImplementedException();
        }

        public Project GetById(object id, List<string> error)
        {
            throw new NotImplementedException();
        }

        public int Insert(Project item, IDictionary<string, string> staffIds, List<string> error)
        {
            throw new NotImplementedException();
        }

        public void RollbackTransaction()
        {
            throw new NotImplementedException();
        }

        public int Update(Project item, IDictionary<string, string> staffIds, List<string> error)
        {
            throw new NotImplementedException();
        }

        public bool Validate(Project item, List<string> error)
        {
            throw new NotImplementedException();
        }
    }
}
