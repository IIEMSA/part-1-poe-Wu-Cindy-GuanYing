using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VenueBookingSystem.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace VenueBookingSystem.Controllers
{
    public class EventController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EventController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()

        {
            var Event = await _context.Event.ToListAsync();

            return View(Event);
        }

        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Create(Event newevent)
        {
            if (ModelState.IsValid)
            {

                _context.Add(newevent);
                await _context.SaveChangesAsync();


                return RedirectToAction(nameof(Index));
            }


            return View(newevent);
        }

        public async Task<IActionResult> Details(int? id)
        {

            var newevent = await _context.Event.FirstOrDefaultAsync(m => m.ID == id);

            if (newevent == null)
            {
                return NotFound();
            }
            return View(newevent);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            var newevent = await _context.Event.FirstOrDefaultAsync(m => m.ID == id);


            if (newevent == null)
            {
                return NotFound();
            }
            return View(newevent);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var newevent = await _context.Event.FindAsync(id);
            _context.Event.Remove(newevent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool EventExists(int id)
        {
            return _context.Event.Any(e => e.ID == id);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newevent = await _context.Event.FindAsync(id);
            if (id == null)
            {
                return NotFound();
            }

            return View(newevent);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Event newevent)
        {
            if (id != newevent.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(newevent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(newevent.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(newevent);
        }


    }
}