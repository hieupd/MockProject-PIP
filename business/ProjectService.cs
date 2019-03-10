using DTO;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ProjectService : IProjectService
    {
        private IProjectRepository projectRepository;
        public ProjectService()
        {
            projectRepository = new ProjectRepository();
        }
        public void BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public void CommitTransaction()
        {
            throw new NotImplementedException();
        }

        public int Delete(object Id, List<string> error)
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

        public int Insert(Project item, List<string> error)
        {
            try
            {
                if (Validate(item, error))
                {
                    projectRepository.Insert(item);
                    return projectRepository.Save();
                }
            }
            catch (Exception ex)
            {
                error.Add(ex.Message);
            }
            return 0;
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
