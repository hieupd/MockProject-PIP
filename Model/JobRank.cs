using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [Table("JobRank")]
    public class JobRank
    {
        [Key]
        [Display(Name = "Job Rank ID")]
        [Required(ErrorMessage = "Job Rank ID is null")]
        public int JobRankId { get; set; }
        [Display(Name = "Job  Rank Name")]
        [Required(ErrorMessage ="Please enter job rank name")]
        [MaxLength(200,ErrorMessage = "Character length is over 200")]
        public string JobRankName { get; set; }
        [Display(Name = "Description")]
        [MaxLength]
        public string Description { get; set; }
        public virtual ICollection<Staff> Staffs { get; set; }
    }
}
