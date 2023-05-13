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
        public class SupplierController : ControllerBase
        {
            private readonly MyDbContext Context;
            public SupplierController(MyDbContext context)
            {
                Context = context;
            }
            [HttpGet]
            public IActionResult GetAll()
            {
                var ListSupplier = Context.Suppliers.ToList();

                return Ok(ListSupplier);
            }
            [HttpGet("{id}")]
            public IActionResult GetById(Guid id)
            {
            try
            { 
                var Supplier = Context.Suppliers.SingleOrDefault(s =>s.IDSupp == id);
                if (Supplier != null)
                {
                    return Ok(Supplier);
                }
                else
                {
                    return NotFound();
                }
             }
             catch
             {
                return BadRequest();
            }
            }
            [HttpPost]
            public IActionResult Create(string NameSupp, string ProductType)
            {
            try
            {
                var Supplier = new Supplier
                {
                    IDSupp = Guid.NewGuid(),
                    NameSupp = NameSupp,
                    ProductType = ProductType,
                };

                Context.Suppliers.Add(Supplier);
                Context.SaveChanges();

                return Ok(new
                {
                    Success = true,
                    Data = Supplier,
                });

            }
            catch
            {
                return BadRequest();
            }
            }
            [HttpPut("{id}")]
            public IActionResult Edit( string id, Supplier SupplierEdit)
            {
            try
            {
                var Supplier = Context.Suppliers.SingleOrDefault(p => p.IDSupp == Guid.Parse(id));
                if (Supplier == null)
                {
                    return NotFound();
                }
                if (id != Supplier.IDSupp.ToString())
                {
                    return BadRequest();
                }
                Supplier.NameSupp = SupplierEdit.NameSupp;
                Supplier.ProductType = SupplierEdit.ProductType;
                Context.SaveChanges();

                return Ok(SupplierEdit);
            }
            catch
            {
                return BadRequest();
            }            
                
            }

         }
          




}
