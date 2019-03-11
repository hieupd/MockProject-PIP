using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [Table("ProjectStaff")]
    public class ProjectStaff
    {
        [Key]
        [Display(Name = "ProjectID")]
        [Column(Order =0)]
        [Required(ErrorMessage = "Please Enter Project ID")]
        public int ProjectId { get; set; }
        [Key]
        [Display(Name = "StaffID")]
        [Column(Order = 1)]
        [Required(ErrorMessage = "Please Enter Staff ID")]
        public int StaffId { get; set; }
        [Required(ErrorMessage ="Please enter Status")]
        [MaxLength(20, ErrorMessage = "Character length is over 20")]
        public string Status { get; set; }
        [Required(ErrorMessage ="Please enter Add On")]
        
        public DateTime AddOn { get; set; }
        public DateTime ModifierDate { get; set; }
        [Display(Name = "Role In Project")]
        [Required(ErrorMessage = "Please enter Role In Project")]
        public string RoleInProject { get; set; }
        public virtual Project Project { get; set; }
        public virtual Staff Staff { get; set; }
    }
}
