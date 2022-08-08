using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DepartmentalStore.Models
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }

        public int OrderMasterId { get; set; }
        [ForeignKey("OrderMasterId")]
        public virtual OrderMaster? ordermasters { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Card Number")]
        public int CardNumber { get; set; }

        [Required(ErrorMessage = "*")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Total Amount")]
        public float Amount { get; set; }

        public List<OrderDetail>? orderdetails { get; set; }


    }
}
