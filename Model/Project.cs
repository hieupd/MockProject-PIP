using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [Table("Project")]
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        [Display(Name = "Project Name")]
        [Required(ErrorMessage ="Please enter Project Name")]
        [MaxLength(100,ErrorMessage = "Character length is over 100")]
        public string ProjectName { get; set; }
        [Display(Name = "Duration")]
        [Required(ErrorMessage ="Please enter duration")]
        public Decimal Duration { get; set; }
        [Display(Name = "Start Date")]
        [Required(ErrorMessage ="Please enter Start Date")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Complete On")]
        [Required(ErrorMessage ="Please enter Complete On")]
        public DateTime CompleteOn { get; set; }
        [Display(Name = "Budget")]
        [Required(ErrorMessage ="Please enter Bubget")]
        public Decimal Bubget { get; set; }
        [Display(Name = "")]
        [Required(ErrorMessage ="Please enter Project Status")]
        public string ProjectStatus { get; set; }
        [Display(Name = "Description")]
        public string Descriptions { get; set; }

        public virtual ICollection<ProjectStaff> ProjectStaffs { get; set; }
        public virtual ICollection<ClaimRequest> ClaimRequests { get; set; }
    }
}
