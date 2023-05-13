using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WEB_BELIY_API.MODEL
{
    public class Employee
    {
        [Key]

        public Guid IDEmp { get; set; }

        public string Name { get; set; }

        public string LinkImage { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public double Salary { get; set; }

        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        
    }

}
