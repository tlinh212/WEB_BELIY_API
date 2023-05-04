using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_BELIY_API.DATA;

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
        public IActionResult Create()
        {
            return Ok();
        }
    }
}
