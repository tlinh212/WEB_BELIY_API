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
    public class EmployeeController : ControllerBase
    {
        private readonly MyDbContext Context;

        public Guid IDImage { get; private set; }

        public EmployeeController(MyDbContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var ListProduct = Context.Employees.ToList();

            return Ok(ListProduct);
        }

        [HttpGet("{id}")]
        public IActionResult GeById(Guid id)
        {
            try
            {
                var Employee = Context.Employees.SingleOrDefault(i => i.IDEmp == id);
                if (Employee != null)
                {
                    return Ok(Employee);
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
        public IActionResult Create(string Name, string LinkImage, string Position, string Email, string Address, double Salary)
        {
            try
            {
                var Employee = new Employee
                {
                    IDEmp = Guid.NewGuid(),
                    Name = Name,
                    LinkImage = LinkImage, 
                    Position = Position,
                    Email = Email,
                    Salary = Salary

                };

                Context.Employees.Add(Employee);
                Context.SaveChanges();

                return Ok(new
                {
                    Success = true,
                    Data = Employee,
                });
            }
            catch
            {
                return BadRequest();
            }


        }

        [HttpPut("{id}")]
        public IActionResult Edit(string id, Employee employeedit)
        {
            try
            {
                var employee = Context.Employees.SingleOrDefault(i => i.IDEmp == Guid.Parse(id));
                if (employee == null)
                {
                    return NotFound();
                }
                /////update 
                if (id != employee.IDEmp.ToString())
                {
                    return BadRequest();
                }

                employee.Name = employeedit.Name;
                employee.LinkImage = employeedit.LinkImage;
                employee.Position = employeedit.Position;
                employee.Email = employeedit.Email;
                employee.Address = employeedit.Address;
                employee.Salary = employeedit.Salary;
                Context.SaveChanges();
                return Ok(employee);
            }
            catch
            {
                return BadRequest();
            }

        }


    }

}

