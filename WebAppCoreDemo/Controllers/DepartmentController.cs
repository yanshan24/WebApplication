using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebAppCoreDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : ControllerBase
    {
        private string[,] departments = new string[,]
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
        };

        private readonly ILogger<DepartmentController> _logger;

        public DepartmentController(ILogger<DepartmentController> logger)
        {
            _logger = logger;
        }

        [Route("departments")]
        [HttpGet]
        public IEnumerable<string> GetList()
        {
            int j = departments.GetLength(0);
            int i;
            string[] arr = new string[] { };
            List<string> ls = arr.ToList();

            for (i = 0; i < j; i++)
            {
                ls.Add(departments[i, 0]);
            }
            arr = ls.ToArray();
            return arr;
        }

        [Route("departments/{id}")]
        [HttpGet]
        public IEnumerable<string> Get(int id)
        {
            string[] arr = new string[2] { departments[id - 1, 0], departments[id - 1, 1] };
            return arr.ToArray();
        }
    }
}
