using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WEB_BELIY_API.MODEL
{
    public class Order
    {
        [Key]
        [Required]
        public Guid IdOrder { get; set; }

        [Required]
        [Display(Name = "IDEmp")]
        public virtual Guid IDEmp { get; set; }
        [ForeignKey("IDEmp")]
        public virtual Employee Employees { get; set; }
        
        [Required]
        [Display(Name = "IDPromotion")]
        public virtual Guid IDPromotion { get; set; }
        [ForeignKey("IDEmp")]
        public virtual Promotion Promotions { get; set; }

        public DateTime OrderDate { get; set; }

        public string Status { get; set; }

        public DateTime PaymentDate { get; set; }

        public string PaymentMethods { get; set; }

        public double TotalValue { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
