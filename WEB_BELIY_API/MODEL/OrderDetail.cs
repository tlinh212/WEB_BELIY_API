using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WEB_BELIY_API.MODEL
{
    public class OrderDetail
    {

        [Required]
        [Display(Name = "IDOrder")]
        public virtual Guid IdOrder { get; set; }

        [ForeignKey("IDOrder")]
        public virtual Order Orders { get; set; }

        [Required]
        [Display(Name = "IDPro")]
        public virtual Guid IDPro { get; set; }

        [ForeignKey("IDPro")]
        public virtual Product Product { get; set; }
        public int Quantity { set; get; }
        public double Price { set; get; }
    }
}
