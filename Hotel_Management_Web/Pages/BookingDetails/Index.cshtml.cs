using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.DataAccess;

namespace Hotel_Management_Web.Pages.BookingDetails
{
    public class IndexModel : PageModel
    {
        private readonly BusinessObject.DataAccess.Hotel_ManagementsContext _context;

        public IndexModel(BusinessObject.DataAccess.Hotel_ManagementsContext context)
        {
            _context = context;
        }

        public IList<BookingDetail> BookingDetail { get;set; }

        public async Task OnGetAsync()
        {
            BookingDetail = await _context.BookingDetails
                .Include(b => b.Booking)
                .Include(b => b.Room).ToListAsync();
        }
    }
}
