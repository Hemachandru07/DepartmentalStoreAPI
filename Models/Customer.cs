using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DepartmentalStore.Models
{
    public class Customer
    {
        [Key]
        [Display(Name = "Customer ID")]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Customer Name")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Numbers and special characters are not allowed")]
        public string? CustomerName { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Mobile Number")]
        [DataType(DataType.PhoneNumber)]
        public long MobileNumber { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Email-ID")]
        [DataType(DataType.EmailAddress)]
        public string? CustomerEmail { get; set; }

        [Required(ErrorMessage = "*")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "*")]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$",
            ErrorMessage = "Password must contains one Uppercase,one Lowercase and one Specialcharacter")]
        [Display(Name = "Password")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "*")]
        [NotMapped]
        [Compare("Password", ErrorMessage = "Password Not Matching")]
        [Display(Name = "Confirm Password")]
        public string? ConfirmPassword { get; set; }
        public List<OrderDetail>? orderdetails { get; set; }
    }
}
