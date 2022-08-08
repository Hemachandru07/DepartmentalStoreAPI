using System.ComponentModel.DataAnnotations;

namespace DepartmentalStore.Models
{
    public class Beverages
    {
        [Key]
        [Display(Name = "Beverage ID")]
        public int BeverageId { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Beverage  Name")]
        public string? BeverageName { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Beverage Price")]
        public float BeveragePrice { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Beverage Quantity")]
        public int BeverageQty { get; set; }
        public List<OrderMaster>? ordermasters { get; set; }
    }
}
