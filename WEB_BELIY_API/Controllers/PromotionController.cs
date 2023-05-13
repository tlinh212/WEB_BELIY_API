﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_BELIY_API.MODEL;
using WEB_BELIY_API.DATA;

namespace WEB_BELIY_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        private readonly MyDbContext Context;
        public PromotionController(MyDbContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var ListPromotion = Context.Promotions.ToList();

            return Ok(ListPromotion);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var Promotion = Context.Promotions.SingleOrDefault(p => p.IDPromotion == id);
                if (Promotion != null)
                {
                    return Ok(Promotion);
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
        public IActionResult Create(string NamePromotion, double Discount, DateTime BeginDate, DateTime EndDate )
        {
            try
            {
                var Promotion = new Promotion
                {
                    IDPromotion = Guid.NewGuid(), 
                    NamePromotion = NamePromotion, 
                    Discount = Discount,
                    BeginDate = BeginDate, 
                    EndDate = EndDate,                    
                };

                Context.Promotions.Add(Promotion);
                Context.SaveChanges();

                return Ok(new
                {
                    Success = true,
                    Data = Promotion,
                });

            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public IActionResult Edit(string id, Promotion PromotionEdit)
        {
            try
            {
                var Promotion = Context.Promotions.SingleOrDefault(p => p.IDPromotion == Guid.Parse(id));
                if (Promotion == null)
                {
                    return NotFound();
                }
                if (id != Promotion.IDPromotion.ToString())
                {
                    return BadRequest();
                }
                Promotion.NamePromotion = PromotionEdit.NamePromotion;
                Promotion.Discount = PromotionEdit.Discount;
                Promotion.BeginDate = PromotionEdit.BeginDate;
                Promotion.EndDate = PromotionEdit.EndDate;

                Context.SaveChanges(); 


                return Ok(PromotionEdit);
            }
            catch
            {
                return BadRequest();
            }

        }
    }
}
