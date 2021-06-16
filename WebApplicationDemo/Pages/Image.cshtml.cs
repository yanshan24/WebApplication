using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplicationDemo.Pages
{
    public class ImageModel : PageModel
    {
        public void OnGet()
        {
        }
        
        [BindProperty]
        public string CompanyName { get; set; }

        [BindProperty]
        public string ContactName { get; set; }

        [BindProperty]
        public bool EmployBool { get; set; }

        public IActionResult OnPost()
        {
            ViewData["Company"] = this.CompanyName;
            ViewData["Contact"] = this.ContactName;
            ViewData["Employ"] = this.EmployBool;

            return Page();
        }
    }
            

}

