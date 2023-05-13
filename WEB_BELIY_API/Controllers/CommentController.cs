using Microsoft.AspNetCore.Http;
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
    public class CommentController : ControllerBase
    {
        private readonly MyDbContext Context;
        public CommentController(MyDbContext context)

        {
            Context = context;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var ListComment = Context.Comments.ToList().Where(i => i.IDPro == id);
                if (ListComment != null)
                {
                    return Ok(ListComment);
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
        public IActionResult Create(string IDCmt, string IdCus, string IDPro, int Rate, string Detail)
        {
            try
            {
                var Comment = new Comment
                {
                    IDCmt = Guid.NewGuid(),
                    IdCus = Guid.Parse(IdCus),
                    IDPro = Guid.Parse(IDPro),
                    Rate = Rate, 
                    Detail = Detail,
                    Enable = 1,

                };

                Context.Comments.Add(Comment);
                Context.SaveChanges();

                return Ok(new
                {
                    Success = true,
                    Data = Comment,
                });
            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpPut("{id}")]
        public IActionResult Disable(string id)
        {
            try
            {
                var Comment = Context.Comments.SingleOrDefault(i => i.IDCmt == Guid.Parse(id));
                if (Comment == null)
                {
                    return NotFound();
                }
                /////update 
                if (id != Comment.IDCmt.ToString())
                {
                    return BadRequest();
                }
               
                Comment.Enable = 0;
                Context.SaveChanges();

                return Ok(Comment);
            }
            catch
            {
                return BadRequest();
            }

        }

    }
}
