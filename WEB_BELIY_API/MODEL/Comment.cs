using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WEB_BELIY_API.DATA;

namespace WEB_BELIY_API.MODEL
{
    public class Comment
    {
        [Key]
        public Guid IDCmt { get; set; }

        [Required]
        [Display(Name = "Customer")]
        public virtual Guid IdCus { get; set; }
        [ForeignKey("IdCus")]
        public virtual Customer Customer { get; set; }

        [Required]
        [Display(Name = "Product")]
        public virtual Guid IDPro { get; set; }
        [ForeignKey("IDPro")]
        public virtual Product Product { get; set; }

        
        public int Rate { get; set; }
        public string Detail { get; set; }
        public int Enable { get; set; }




    }
}
