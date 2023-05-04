using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WEB_BELIY_API.MODEL
{
    public class Order
    {
        [Key]
        public Guid IdOrder { get; set; }

        public DateTime OrderDate { get; set; }

        public string Status { get; set; }

        public DateTime PaymentDate { get; set; }

        public string PaymentMethods { get; set; }

        public int TotalValue { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
