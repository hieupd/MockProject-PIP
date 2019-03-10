using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [Table("ClaimRequest")]
    public class ClaimRequest
    {
        [Display(Name = "Claim Id")]
        [Key]
        public int ClaimId { get; set; }
        [Display(Name = "Claim Status")]
        [Required(ErrorMessage = "Please enter Claim Status")]
        public string Status { get; set; }

        [Display(Name = "Remarks")]
        public string Remarks { get; set; }

        [Display(Name = "Staff Id")]
        [Required(ErrorMessage = "Please enter Staff Id")]
        [ForeignKey("Staff")]
        public string StaffId { get; set; }

        [Display(Name = "Project Id")]
        [ForeignKey("Project")]
        [Required(ErrorMessage = "Please enter Project Id")]
        public int ProjectId { get; set; }

        [Display(Name = "Approver Id")]
        [ForeignKey("Approver")]
        [Required(ErrorMessage = "Please enter Approver Id")]
        public int ApproverId { get; set; }

        [Display(Name = "Approved Date")]
        public DateTime? ApprovedDate { get; set; }

        [Display(Name = "Submitted Date")]
        [Required]
        public DateTime SubmittedDate { get; set; }
        [Required(ErrorMessage = "Please enter AuditTrail")]
        public string AuditTrail { get; set; }

        public virtual Staff Staff { get; set; }
        public virtual Staff Approver { get; set; }
        public virtual Project Project { get; set; }
        public virtual ICollection<ClaimRequestDetail> ClaimRequestDetails { get; set; }
    }
}
