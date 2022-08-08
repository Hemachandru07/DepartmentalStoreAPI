using System.ComponentModel.DataAnnotations;

namespace DepartmentalStore.Models
{
    public class Vegetables
    {

        [Key]
        [Display(Name = "Vegetable ID")]
        public int VegetableId { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Vegetable  Name")]
        public string? VegetableName { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Vegetable Price")]
        public float VegetablePrice { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Vegetable Quantity")]
        public int VegetableQty { get; set; }
        public List<OrderMaster>? ordermasters { get; set; }
    }
}
