using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DepartmentalStore.Models
{
    public class AdminMaster
    {
        [Key]
        public int AdminId { get; set; }
        public string? AdminName { get; set; }

        [Required]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$",
            ErrorMessage = "Password must contains one Uppercase,one Lowercase and one Specialcharacter")]
        public string? Password { get; set; }

        [Required]
        [NotMapped]
        [Compare("PassWord", ErrorMessage = "Password Not Matching")]
        [Display(Name = "Confirm Password")]
        public string? ConfirmPassword { get; set; }
    }
}
