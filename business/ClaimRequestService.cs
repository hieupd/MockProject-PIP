using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Commond;
using Repository;
using System.Net.Mail;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Configuration;

namespace Business
{
    public class ClaimRequestService : IClaimRequestService
    {
        private IClaimRequestRepository requestRepository;
        public ClaimRequestService()
        {
            requestRepository = new ClaimRequestRepository();
        }

        public int ApproveRequest(int claimId, string staffId, ApproveType approveType, List<string> error)
        {
            ClaimRequest claimRequest = requestRepository.GetById(claimId);
            if (claimRequest == null)
            {
                error.Add("Claim Request is not exists");
                return 0;
            }
            switch (approveType)
            {
                case ApproveType.Submit:
                    if(claimRequest.Status.Equals(ClaimStatus.DRAFT))
                    {
                        claimRequest.Status = ClaimStatus.PENDING_APPROVAL;
                    }
                    break;
                case ApproveType.Approve:
                    if (claimRequest.Status.Equals(ClaimStatus.PENDING_APPROVAL))
                    {
                        claimRequest.Status = ClaimStatus.APPROVED;
                    }
                    break;
                case ApproveType.Return:
                    if (claimRequest.Status.Equals(ClaimStatus.PENDING_APPROVAL))
                    {
                        claimRequest.Status = ClaimStatus.DRAFT;
                    }
                    break;
                case ApproveType.Reject:
                    if (claimRequest.Status.Equals(ClaimStatus.DRAFT))
                    {
                        claimRequest.Status = ClaimStatus.PENDING_APPROVAL;
                    }
                    break;
                case ApproveType.Paid:
                    if (claimRequest.Status.Equals(ClaimStatus.APPROVED))
                    {
                        claimRequest.Status = ClaimStatus.PAID;
                    }
                    break;
                case ApproveType.Cancel:
                    if (claimRequest.Status.Equals(ClaimStatus.DRAFT))
                    {
                        claimRequest.Status = ClaimStatus.CANCELLED;
                    }
                    break;
                default:
                    return 0;
            }
            try
            {
                claimRequest.AuditTrail += string.Format("{0} by <<{1}>> on <<{2}>>",approveType.ToString(), staffId, DateTime.Now.ToString());
                requestRepository.Update(claimRequest);
                return requestRepository.Save();
            }
            catch (Exception ex)
            {
                error.Add(ex.Message);
                return 0;
            }
        }

        public void BeginTransaction()
        {
            requestRepository.BeginTransaction();
        }

        public void CommitTransaction()
        {
            requestRepository.CommitTransaction();
        }

        public void Download(List<string> error) //chua xong
        {
            throw new NotImplementedException();
        }

        public ICollection<ClaimRequest> GetAll(List<string> error)
        {
            try
            {
                return requestRepository.GetAll().ToList();
            }
            catch (Exception ex)
            {
                error.Add(ex.Message);
                return new List<ClaimRequest>();
            }
        }

        public ClaimRequest GetById(object id, List<string> error)
        {
            ClaimRequest claimRequest = null;
            try
            {
                claimRequest = requestRepository.GetById(id);
                if (claimRequest == null)
                {
                    error.Add("Claim request is null");
                }
            }
            catch (Exception ex)
            {
                error.Add(ex.Message);
            }
            return claimRequest;
        }

        public IEnumerable<ClaimRequest> GetByOneOrMoreStatus(string status, List<string> error)
        {
            IEnumerable<ClaimRequest> claimRequests = new List<ClaimRequest>();
            try
            {
                claimRequests = requestRepository.GetAll()
                                                 .Where(cr => status.Trim().ToLower().Contains(cr.Status.ToLower()))
                                                 .ToList();
            }
            catch (Exception ex)
            {
                error.Add(ex.Message);
            }
            return claimRequests;
        }

        public IEnumerable<ClaimRequest> GetMyClaimByOneOrMoreStatus(string staffId, string status, List<string> error)
        {
            IEnumerable<ClaimRequest> claimRequests = new List<ClaimRequest>();
            try
            {
                claimRequests = requestRepository.GetAll()
                                             .Where(cr => cr.StaffId.Equals(staffId))
                                             .Where(cr => status.Trim().ToLower().Contains(cr.Status.ToLower()))
                                             .ToList();
            }
            catch (Exception ex)
            {
                error.Add(ex.Message);
            }
            return claimRequests;
        }

        public int Insert(ClaimRequest item, string staffId, List<string> error)
        {
            try
            {
                if(Validate(item,error)==true)
                {
                    item.AuditTrail= string.Format("{0} by <<{1}>> on <<{2}>>","CREATED", staffId, DateTime.Now.ToString());
                    requestRepository.Insert(item);
                    return requestRepository.Save();
                }
            }
            catch (Exception ex)
            {
                error.Add(ex.Message);
            }
            return 0;
        }

        public void RollbackTransaction()
        {
            requestRepository.RollbackTransaction();
        }

        public void SendMail(List<string> error, string emailTo, string subject, string body)
        {
            try
            {
                var smtp = new SmtpClient
                {
                    Host = ConfigurationManager.AppSettings["host"],
                    Port = int.Parse(ConfigurationManager.AppSettings["port"]),
                    EnableSsl = bool.Parse(ConfigurationManager.AppSettings["enableSsl"]),
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(ConfigurationManager.AppSettings["emailFrom"], "tramtran1234")
                };

                using (var smtpMessage = new MailMessage(ConfigurationManager.AppSettings["username"], emailTo))
                {
                    smtpMessage.Subject = subject;
                    smtpMessage.Body = body;
                    smtpMessage.IsBodyHtml = true;
                    smtp.Send(smtpMessage);
                }
            }
            catch (Exception ex)
            {
                error.Add(ex.Message);
            }
        }

        public int Update(ClaimRequest item, string staffId, List<string> error)
        {
            if(!item.Status.Equals(ClaimStatus.DRAFT))
            {
                error.Add("Claim Status must be Draft");
                return 0;
            }
            BeginTransaction();
            try
            {
                if (Validate(item, error) == true)
                {
                    var claimRequestDetails = item.ClaimRequestDetails;

                    item.ClaimRequestDetails.Clear();
                    requestRepository.Update(item);
                    requestRepository.Save();

                    item.ClaimRequestDetails = claimRequestDetails;
                    item.AuditTrail = string.Format("{0} by <<{1}>> on <<{2}>>", "Updated", staffId, DateTime.Now.ToString());
                    requestRepository.Update(item);
                    requestRepository.Save();
                    CommitTransaction();

                    return 1;
                }
            }
            catch (Exception ex)
            {
                error.Add(ex.Message);
                RollbackTransaction();
            }
            return 0;
        }

        public bool Validate(ClaimRequest item, List<string> error)
        {
            if (item == null)
            {
                error.Add("Claim Request is null");
                return false;
            }
            if (item.ClaimRequestDetails == null)
            {
                error.Add("Claim detail is empty");
            }
            else if (item.ClaimRequestDetails.Count==0)
            {
                error.Add("Claim detail is empty");
            }
            else
            {
                IClaimRequestDetailService claimRequestDetailService = new ClaimRequestDetailService();
                IProjectService projectService = new ProjectService();
                var project = projectService.GetById(item.ProjectId, error);
                if(project!=null)
                {
                    foreach (var claimReqeustDetail in item.ClaimRequestDetails)
                    {
                        claimRequestDetailService.Validate(claimReqeustDetail, project, error);
                    }
                }
                else
                {
                    error.Add("Project is not exists");
                }
            }
            if (item.ProjectId == 0)
            {
                error.Add("Project is required");
            }
            if (string.IsNullOrEmpty(item.Status))
            {
                error.Add("Status is required");
            }
            if (error.Count == 0)
            {
                return true;
            }
            else
                return false;
        }
    }
}
