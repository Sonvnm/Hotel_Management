using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.DataAccess;
using Repository;
using Microsoft.AspNetCore.Http;

namespace Hotel_Management_Web.Pages.Staffs
{
    public class IndexModel : PageModel
    {
        private readonly IStaffRepository staf = new StaffRepository();
        private readonly ICustomerRepository cus = new CustomerRepository();

        public List<staff> staff { get;set; }

        public IActionResult OnGet()
        {
            string cont = HttpContext.Session.GetString("username");

            string Id = HttpContext.Session.GetString("role");
          
            if (HttpContext.Session.GetString("username") == null ||
               HttpContext.Session.GetString("password") == null)
            {
                return RedirectToPage("/Index");
            }else if (!Id.Equals("2"))
            {
                return RedirectToPage("/Errors");
            }
            else if (Id.Equals("2"))
            {
                staff= staf.Searchingstaff(cont);
                return Page();
            }
            return RedirectToPage("/Errors");

            string pass = HttpContext.Session.GetString("password");

            //string pass = HttpContext.Session.GetString("password");

            //staff = staf.Searchingstaff(cont);
            //return RedirectToPage("/Welcome");



            return Page();
           

        }
    
            public IActionResult OnGetLog()
        {
            return RedirectToPage("/Errors");
        }
    }
}
