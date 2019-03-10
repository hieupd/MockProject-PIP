using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    interface IClaimRequestDetailService
    {
        List<ClaimRequestDetail> Insert(List<ClaimRequestDetail>tempDataRequestDetail, ClaimRequestDetail claimRequestDetail, List<string> error);
        List<ClaimRequestDetail> Update(List<ClaimRequestDetail> tempDataRequestDetail, ClaimRequestDetail claimRequestDetail, List<string> error);
        List<ClaimRequestDetail> Delete (List<ClaimRequestDetail> tempDataRequestDetail, ClaimRequestDetail claimRequestDetail, List<string> error);

        bool Validate(ClaimRequestDetail claimRequestDetail, Project project,List<string> error);
    }
}
