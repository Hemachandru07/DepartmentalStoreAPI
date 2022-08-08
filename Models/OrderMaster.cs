using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DepartmentalStore.Models
{
    public class OrderMaster
    {
        [Key]
        public int OrderMasterID { get; set; }

        [Display(Name = "Grocery Details")]
        public int GroceryDetailId { get; set; }
        [ForeignKey("GroceryDetailId")]
        public virtual Groceries? groceries { get; set; }

        [Display(Name = "Fruit Details")]
        public int FruitDetailId { get; set; }
        [ForeignKey("FruitDetailId")]
        public virtual Fruits? fruits { get; set; }

        [Display(Name = "Beverage Details")]
        public int BeverageDetailId { get; set; }
        [ForeignKey("BeverageDetailId")]
        public virtual Beverages? beverages { get; set; }

        [Display(Name = "Vegetable Details")]
        public int VegetableDetailId { get; set; }
        [ForeignKey("VegetableDetailId")]
        public virtual Vegetables? vegetables { get; set; }
        public List<Payment>? payments { get; set; }
        public List<OrderDetail>? orderDetails { get; set; }
       
    }
}
