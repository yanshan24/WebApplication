using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;

namespace WebAppCoreDemo.Controllers
{
    [ApiController]
    [Route("departments")]
    public class DepartmentController : ControllerBase
    {
        List<Department> departments = new List<Department>() {
            new Department(){ id = 1, name = "Service", description = "To ensure customer satisfaction", agents = new string[] { "Amy" } },
            new Department(){ id = 2, name = "IT", description = "To develop products", agents = new string[] { "Amy2" } },
            new Department(){ id = 3, name = "Production", description = "To produce products", agents = new string[] { "Amy3" } },
            new Department(){ id = 4, name = "QualityAssurance", description = "To define the procedures for achieving and improving consistent product quality", agents = new string[] { "Amy4" } },
            new Department(){ id = 5, name = "Finance", description = "To plan and organize the company’s finances and producing financial statements", agents = new string[] { "Amy5" } }
        };

        /*private string[,] departments = new string[,]
        {
            { "Service", "To ensure customer satisfaction" },
            { "IT", "To develop products" },
            { "Production", "To produce products" },
            { "QualityAssurance", "To define the procedures for achieving and improving consistent product quality" },
            { "Finance", "To plan and organize the company’s finances and producing financial statements" }
        };

        private string[,] agents = new string[,]
        {
            { "Service", "Amy" },
            { "IT", "Bob" },
            { "Production", "C" },
            { "QualityAssurance", "D" },
            { "Finance", "E" }
        };*/

        private readonly ILogger<DepartmentController> _logger;

        public DepartmentController(ILogger<DepartmentController> logger)
        {
            _logger = logger;
        }

        [Route("")]
        [HttpGet]
        public IActionResult Get()
        {
            //string json = string.Empty;
            //JsonSerializerSettings jsSetting = new JsonSerializerSettings();
            //jsSetting.NullValueHandling = NullValueHandling.Ignore;

            //foreach (var d in departments)
            //{
            //    string jsonString = JsonConvert.SerializeObject(d, Formatting.Indented, jsSetting);
            //    json += jsonString;
            //}

            var json = JsonConvert.SerializeObject(departments);
            //JObject output = JObject.Parse(json);
            return Content(json);
            //return Json(new)
        }
        //public IEnumerable<string> GetList()
        //{
        //    int j = departments.Count;
        //    int i;
        //    string[] arr = new string[] { };
        //    List<string> ls = arr.ToList();

        //    for (i = 0; i < j; i++)
        //    {
        //        ////ls.Add(departments[i]);
        //    }
        //    arr = ls.ToArray();
        //    return arr;
        //}

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetId(int id)
        {
            //string[] arr = new string[] { departments[id - 1, 0], departments[id - 1, 1]};
            //try
            //{
            //    ;
            //}
            //catch (IndexOutOfRangeException)
            //{
            //    return NotFound();
            //}
            ////throw new Exception("");
            var obj = departments.Find(x => x.id == id);
            if (obj == null)
            {
                return NotFound();
            }
            
            return Content(JsonConvert.SerializeObject(departments[id-1]));
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var obj = departments.Find(x => x.id == id);
            if (obj == null)
            {
                return NotFound();
            }
            departments.RemoveAt(id - 1);
            //return Content(departments.Count().ToString());
            return Ok();
        }

        [Route("")]
        [HttpPost]
        public IActionResult Post(int id, string name, string desc, string[] agents)
        {
            Department d = new Department { id = id, name = name, description = desc, agents = agents };
            departments.Add(d);
            return Content(JsonConvert.SerializeObject(d));
        }

        [Route("{id}")]
        [HttpPut]
        public IActionResult Put(int id, string name, string desc, string[] agents)
        {
            var obj = departments.Find(x => x.id == id);
            if (obj == null)
            {
                return NotFound();
            }
            if (name != null)
            {
                obj.name = name;
            }
            if (desc != null)
            {
                obj.description = desc;
            }
            if (agents != null)
            {
                obj.agents = agents;
            }

            var json = JsonConvert.SerializeObject(departments);
            return Content(json);
        }

        [Route("{id}/agents")]
        [HttpGet]
        public IActionResult GetAgents(int id)
        {
            var obj = departments.Find(x => x.id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return Content(JsonConvert.SerializeObject(departments[id - 1].agents));

        }
    }
    
}
