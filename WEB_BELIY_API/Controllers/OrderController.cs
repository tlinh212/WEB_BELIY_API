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
    public class OrderController : ControllerBase
    {
        private readonly MyDbContext Context;
        public OrderController(MyDbContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var List = Context.Orders.ToList();

            return Ok(List);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var Obj = Context.Orders.SingleOrDefault(c =>
            c.IdOrder == id);
            if (Obj != null)
            {
                return Ok(Obj);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult Create(string IDEmp, string IDPromotion, DateTime OrderDate, string Status, DateTime PaymentDate, string PaymentMethods, double TotalValue)
        {
            var Order = new Order
            {
                IdOrder = Guid.NewGuid(),
                IDEmp = Guid.Parse(IDEmp),
                IDPromotion = Guid.Parse(IDPromotion),
                OrderDate = OrderDate,
                Status = Status, 
                PaymentDate = PaymentDate, 
                PaymentMethods = PaymentMethods, 
                TotalValue = TotalValue,   
               
            };           

            Context.Orders.Add(Order);
            Context.SaveChanges();

            return Ok(new
            {
                Success = true,
                Data = Order,
            });

        }

        [HttpPut("{id}")]
        public IActionResult Edit(string id, string Status)
        {
            try
            {
                var order = Context.Orders.SingleOrDefault(o => o.IdOrder == Guid.Parse(id));
                if (order == null)
                {
                    return NotFound();
                }
                /////update 
                if (id != order.IdOrder.ToString())
                {
                    return BadRequest();
                }

                order.Status = Status;
                Context.SaveChanges();


                return Ok(order);
            }
            catch
            {
                return BadRequest();
            }

        }

    }
}
