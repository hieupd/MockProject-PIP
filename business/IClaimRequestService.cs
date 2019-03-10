using Commond;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IClaimRequestService
    {
        int Insert(ClaimRequest item, string staffId, List<string> error);
        int Update(ClaimRequest item, string staffId, List<string> error);
        ICollection<ClaimRequest> GetAll(List<string> error);
        ClaimRequest GetById(object id, List<string> error);
        bool Validate(ClaimRequest item, List<string> error);
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();

        int ApproveRequest(int claimId, string currentUser, ApproveType approveType,List<string> error);
        void Download(List<string> error);
        IEnumerable<ClaimRequest> GetByOneOrMoreStatus(string status,List<string> error);
        IEnumerable<ClaimRequest> GetMyClaimByOneOrMoreStatus(string staffId, string status, List<string> error);
        void SendMail(List<string> error, string emailTo, string subject, string body);
    }
}
