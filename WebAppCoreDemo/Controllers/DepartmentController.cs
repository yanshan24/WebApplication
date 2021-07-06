using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;
using WebAppCoreDemo.Models.DataBaseTable;

namespace WebAppCoreDemo.Controllers
{
    [ApiController]
    [Route("departments")]
    public class DepartmentController : ControllerBase
    {

        private readonly ILogger<DepartmentController> _logger;

        public DepartmentController(ILogger<DepartmentController> logger)
        {
            _logger = logger;
        }

        [Route("")]
        [HttpGet]
        public OkObjectResult Get()
        {
            CoreDbContext db = new CoreDbContext();
            List<Department> plist = db.department.ToList();
            return Ok(plist); 
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetId(int id)
        {
            CoreDbContext db = new CoreDbContext();
            var o = db.department.Where(t => t.id == id).FirstOrDefault();
            if (o == null)
            {
                return NotFound();
            }
            return Ok(o);
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            CoreDbContext db = new CoreDbContext();
            var o = db.department.Where(t => t.id == id).FirstOrDefault();
            if (o == null)
            {
                return NotFound();
            }

            db.department.Remove(o);
            db.SaveChanges();
            return NoContent();
        }

        [Route("")]
        [HttpPost]
        public IActionResult Post(string name, string desc, string agents)
        {
            CoreDbContext db = new CoreDbContext();
            var o = new Department { name = name, description = desc, agents = agents };
            db.department.Add(o);
            db.SaveChanges();
            return Ok(o);
        }

        [Route("{id}")]
        [HttpPut]
        public IActionResult Put(int id, string name, string desc, string agents)
        {
            CoreDbContext db = new CoreDbContext();
            var o = db.department.Where(t => t.id == id).FirstOrDefault();
            if (o == null)
            {
                return NotFound();
            }

            if (name != null)
            {
                o.name = name;
            }
            if (desc != null)
            {
                o.description = desc;
            }
            if (agents != null)
            {
                o.agents = agents;
            }

            db.department.Update(o);
            db.SaveChanges();

            List<Department> plist = db.department.ToList();
            return Ok(plist);
        }

        [Route("{id}/agents")]
        [HttpGet]
        public IActionResult GetAgents(int id)
        {
            CoreDbContext db = new CoreDbContext();
            var o = db.department.Where(t => t.id == id).FirstOrDefault();
            if (o == null)
            {
                return NotFound();
            }
            return Ok(o.agents);

        }
    }
    
}
