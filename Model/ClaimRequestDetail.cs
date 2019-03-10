using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ClaimRequestDetail
    {
        [Key]
        [Display(Name = "Claim Detail Id")]
        public int ClaimDetailId { get; set; }

        [Display(Name = "Date")]
        [Required(ErrorMessage = "Please enter Date")]
        public DateTime Date { get; set; }

        [Display(Name = "From")]
        [Required(ErrorMessage = "Please enter From")]
        public DateTime From { get; set; }

        [Display(Name = "To")]
        [Required(ErrorMessage = "Please enter To")]
        public DateTime To { get; set; }

        [Display(Name = "Total No Of Hours")]
        [Required(ErrorMessage = "Please enter Total No Of Hours")]
        public decimal TotalNoOfHours { get; set; }

        [Display(Name = "Remarks")]
        public string Remarks { get; set; }

        [Display(Name = "Claim Request Id")]
        [ForeignKey("ClaimRequest")]
        [Required(ErrorMessage = "Please enter Claim Request Id")]
        public int ClaimRequestId { get; set; }

        public virtual ClaimRequest ClaimRequest { get; set; }
    }
}
