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
        public Guid IdOrder { get; set; }
        public Order Orders { get; set; }

        public Guid IDPro { get; set; }
        public Product Product { get; set; }
        public int Quantity { set; get; }
        public double Price { set; get; }
    }
}
