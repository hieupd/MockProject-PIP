using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [Table("Department")]
    public class Department
    {
        [Key]
        [Display(Name = "Department ID")]
        [Required(ErrorMessage = "Please enter Department ID")]
        public int DepartmentId { get; set; }
        [Display(Name = "Department Name")]
        [Required(ErrorMessage ="Please enter department name")]
        [MaxLength(200,ErrorMessage = "Character length is over 200")]
        public string DepartmentName { get; set; }
        [Display(Name = "Description")]
        [MaxLength(50, ErrorMessage = "Character length is over 50")]
        public string Description { get; set; }
        public virtual ICollection<Staff> Staffs { get; set; }

    }
}
