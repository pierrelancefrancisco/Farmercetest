using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Farmerce.Models
{
    public class ContactForm
    {
        [Key]
        public int userID { get; set; }

        [Required(ErrorMessage = "Required.")]
        [Display(Name = "Firstname")]
        public string firstName { get; set; }
        [Required(ErrorMessage = "Required.")]
        [Display(Name = "Lastname")]
        public string lastName { get; set; }

        [Required(ErrorMessage = "Required.")]
        [Display(Name = "Username")]
        public string userName { get; set; }

        [Required(ErrorMessage = "Required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Required.")]
        [Display(Name = "Mobile Number")]
        public int mobileNo { get; set; }

        [Display(Name = "Item Type")]
        public SubjectType Type { get; set; }
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Required.")]
        public string Message { get; set; }

    }

    public enum SubjectType
    {
        Order = 1,
        Issue = 2,
        Update = 3,
        AccountRecovery = 4,
        Others = 5
    }
}

