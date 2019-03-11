using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [Table("Staff")]
    public class Staff
    {
        [Key]
        [Display(Name = "Staff ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "Please enter staff id")]
        public string StaffId { get; set; }
        [Display(Name = "Staff Name")]
        [Required(ErrorMessage ="Please enter staff name")]
        [MaxLength(200,ErrorMessage = "Character length is over 200")]
        public string StaffName { get; set; }
        [Display(Name ="Salary Staff")]
        [Required(ErrorMessage ="Please enter salary")]
        public Decimal Salary { get; set; }
        [Display(Name = "Email Staff")]
        [MaxLength(50, ErrorMessage = "Character length is over 50")]
        public string Email { get; set; }
        [Display(Name = "Card Number")]
        [MaxLength(50,ErrorMessage = "Character length is over 50")]
        public string CardNumber { get; set; }
        [Display(Name = "Job rank Id")]
        [Required(ErrorMessage ="Please enter job rank id")]
        public int JobRankId { get; set; }
        [ForeignKey("JobRankId")]
        public virtual JobRank JobRank { get; set; }
        [Display(Name = "Department ID")]
        [Required(ErrorMessage = "Please enter Department ID")]
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
        public virtual ICollection<ProjectStaff> ProjectStaffs { get; set; }
        public virtual ICollection<ClaimRequest> ClaimRequests { get; set; }

    }
}
