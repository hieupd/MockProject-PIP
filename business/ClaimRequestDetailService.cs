using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace Business
{
    public class ClaimRequestDetailService : IClaimRequestDetailService
    {
        public List<ClaimRequestDetail> Delete(List<ClaimRequestDetail> tempDataRequestDetail, ClaimRequestDetail claimRequestDetail, List<string> error)
        {
            if (tempDataRequestDetail == null)
            {
                error.Add("Claim detail section is empty");
                return new List<ClaimRequestDetail>();
            }
            tempDataRequestDetail.Remove(claimRequestDetail);
            return tempDataRequestDetail;
        }

        public List<ClaimRequestDetail> Insert(List<ClaimRequestDetail> tempDataRequestDetail, ClaimRequestDetail claimRequestDetail, List<string> error)
        {
            if(tempDataRequestDetail == null)
            {
                tempDataRequestDetail = new List<ClaimRequestDetail>();
            }
            else
            {
                var requestDetailInList = tempDataRequestDetail.Where(t => (t.From == claimRequestDetail.From && t.To == claimRequestDetail.To)).SingleOrDefault();
                if(requestDetailInList!=null)
                {
                    error.Add("Claim request detail is exists");
                    return tempDataRequestDetail;
                }
            }
            tempDataRequestDetail.Add(claimRequestDetail);
            return tempDataRequestDetail;
        }

        public List<ClaimRequestDetail> Update(List<ClaimRequestDetail> tempDataRequestDetail, ClaimRequestDetail claimRequestDetail, List<string> error)
        {
            var requestDetailInList = tempDataRequestDetail.Where(t => (t.From == claimRequestDetail.From
                                                                     && t.To == claimRequestDetail.To
                                                                     && t.ClaimDetailId != claimRequestDetail.ClaimDetailId)).SingleOrDefault();
            if (requestDetailInList != null)
            {
                error.Add("Claim request detail is exists");
                return tempDataRequestDetail;
            }
            var claimRequestDetailFromList = tempDataRequestDetail.Find(c => c.ClaimDetailId == claimRequestDetail.ClaimDetailId);
            claimRequestDetailFromList.Date = claimRequestDetail.Date;
            claimRequestDetailFromList.From = claimRequestDetail.From;
            claimRequestDetailFromList.To = claimRequestDetail.To;
            claimRequestDetailFromList.TotalNoOfHours = claimRequestDetail.TotalNoOfHours;
            claimRequestDetailFromList.Remarks = claimRequestDetail.Remarks;
            return tempDataRequestDetail;
        }

        public bool Validate(ClaimRequestDetail claimRequestDetail,Project project,List<string> error)
        {
            if (claimRequestDetail == null)
            {
                error.Add("Claim Request detail is null");
                return false;
            }
            var date = claimRequestDetail.Date;
            if (date < project.StartDate || date > project.CompleteOn)
            {
                error.Add("Date have to between Start Date and Complete Date");
            }
            else if (claimRequestDetail.From < new DateTime(date.Year, date.Month, date.Day, hour: 0, minute: 0, second: 0)
                  || claimRequestDetail.Date > new DateTime(date.Year, date.Month, date.Day, hour: 24, minute: 59, second: 59))
            {
                error.Add("From and To have to in Date");
            }
            if(claimRequestDetail.TotalNoOfHours<=0 || claimRequestDetail.TotalNoOfHours>24)
            {
                error.Add("Total No of Hours between 0 and 24");
            }
            if (error.Count > 0)
            {
                return false;
            }
            else
                return true;
        }
    }
}
