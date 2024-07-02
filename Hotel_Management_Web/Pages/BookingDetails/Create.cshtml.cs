using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject.DataAccess;

namespace Hotel_Management_Web.Pages.BookingDetails
{
    public class CreateModel : PageModel
    {
        private readonly BusinessObject.DataAccess.Hotel_ManagementsContext _context;

        public CreateModel(BusinessObject.DataAccess.Hotel_ManagementsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["BookingId"] = new SelectList(_context.Bookings, "BookingId", "BookingId");
        ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "RoomId");
            return Page();
        }

        [BindProperty]
        public BookingDetail BookingDetail { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.BookingDetails.Add(BookingDetail);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
