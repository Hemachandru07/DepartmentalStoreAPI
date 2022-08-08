using System.ComponentModel.DataAnnotations;

namespace DepartmentalStore.Models
{
    public class Fruits
    {
        [Key]
        [Display(Name = "Fruit ID")]
        public int FruitId { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Fruit  Name")]
        public string? FruitName { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Fruit Price")]
        public float FruitPrice { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Fruit  Quantity")]
        public int FruitQty { get; set; }
        public List<OrderMaster>? ordermasters { get; set; }
    }
}
