using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_BELIY_API.DATA;
using WEB_BELIY_API.MODEL;

namespace WEB_BELIY_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class OrderDetailController : ControllerBase
    {
        private readonly MyDbContext Context;
        public OrderDetailController(MyDbContext context)
        {
            Context = context;
        }
        
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var OrderDetail = Context.OrderDetails.ToList().Where(o =>o.IdOrder == id);
            if (OrderDetail != null)
            {
                return Ok(OrderDetail);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult Create(string IdOrder,string IDPro, int Quantity ,double Price)
        {
            var OrderDetail = new OrderDetail
            {
                IdOrder = Guid.Parse(IdOrder),
                IDPro = Guid.Parse(IDPro),
                Quantity = Quantity, 
                Price = Price,                

            };

            Context.OrderDetails.Add(OrderDetail);
            Context.SaveChanges();

            return Ok(new
            {
                Success = true,
                Data = OrderDetail,
            });

        }

    }
}
