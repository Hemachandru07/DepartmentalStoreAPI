using System.ComponentModel.DataAnnotations;

namespace DepartmentalStore.Models
{
    public class Groceries
    {
        [Key]
        [Display(Name = "Grocery ID")]
        public int GroceryId { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Grocery Name")]
        public string? GroceryName { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Grocery Price")]
        public float GroceryPrice { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Grocery Quantity")]
        public int GroceryQty { get; set; }
        public List<OrderMaster>? ordermasters { get; set; }
    }
}
