using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DepartmentalStore.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailID { get; set; }

        public int OrderMasterId { get; set; }
        [ForeignKey("OrderMasterId")]
        public virtual OrderMaster? ordermasters { get; set; }

        public int PaymentId { get; set; }
        [ForeignKey("PaymentId")]
        public virtual Payment? payments { get; set; }

        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer? cutstomers { get; set; }

    }
}
