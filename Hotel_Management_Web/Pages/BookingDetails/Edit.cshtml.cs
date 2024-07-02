using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObject.DataAccess;

namespace Hotel_Management_Web.Pages.BookingDetails
{
    public class EditModel : PageModel
    {
        private readonly BusinessObject.DataAccess.Hotel_ManagementsContext _context;

        public EditModel(BusinessObject.DataAccess.Hotel_ManagementsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BookingDetail BookingDetail { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BookingDetail = await _context.BookingDetails
                .Include(b => b.Booking)
                .Include(b => b.Room).FirstOrDefaultAsync(m => m.BookingDetailId == id);

            if (BookingDetail == null)
            {
                return NotFound();
            }
           ViewData["BookingId"] = new SelectList(_context.Bookings, "BookingId", "BookingId");
           ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "RoomId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BookingDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingDetailExists(BookingDetail.BookingDetailId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BookingDetailExists(string id)
        {
            return _context.BookingDetails.Any(e => e.BookingDetailId == id);
        }
    }
}
