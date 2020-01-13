using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ThAmCo.Catering.Models.ViewModels;
using ThAmCo.Events.Data;
using ThAmCo.Events.Models;
using ThAmCo.Events.Models.ViewModels;
using ThAmCo.Venues.Models;

namespace ThAmCo.Events.Controllers
{
    public class EventsController : Controller
    {
        private readonly EventsDbContext _context;

        public EventsController(EventsDbContext context)
        {
            _context = context;
        }

        // GET: Events
        public async Task<IActionResult> Index()
        {
            return View(await _context.Events.ToListAsync());
        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // GET: Events/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Date,Duration,TypeId")] Event @event)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@event);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@event);
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Date,Duration,TypeId")] Event @event)
        {
            if (id != @event.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.Id))
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
            return View(@event);
        }

        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @event = await _context.Events.FindAsync(id);
            _context.Events.Remove(@event);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        //***************
        // GET: Events/Details/5
        public async Task<IActionResult> BookVenue(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events
                .FirstOrDefaultAsync(m => m.Id == id);

            String eventType = @event.TypeId;
            DateTime beginDate = @event.Date;
            DateTime endDate = @event.Date.Add(@event.Duration.Value);

            if (@event == null)
            {
                return NotFound();
            }

            var Event = await _context.Events.FirstOrDefaultAsync(m => m.Id == id);

            var venues = new List<availabilityDto>().AsEnumerable();

            // Code from slide 16

            HttpClient client = new HttpClient();
            client.BaseAddress = new System.Uri("http://localhost:23652/");
            client.DefaultRequestHeaders.Accept.ParseAdd("application/json");

            var uri = "api/availability?EventType=" + Event.TypeId +
                "&BeginDate=" + Event.Date.ToString("yyyy-MM-dd") +
                "&EndDate=" + Event.Date.ToString("yyyy-MM-dd");

            HttpResponseMessage response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                venues = await response.Content.ReadAsAsync<IEnumerable<availabilityDto>>();
            }
            else
            {
                Debug.WriteLine("Index received a bad response from the web service.");
            }

            ViewData["VenueList"] = new SelectList(venues, "code", "name");

            return View(@event);
        }

        //************

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BookVenue(int? eventId, string venueCode, string staffId)
        {
            if (eventId == null || venueCode == null || staffId == null)
            {
                return BadRequest();
            }

            HttpClient client = getClient("23652");

            var @event = await _context.Events.FindAsync(eventId);

            HttpResponseMessage getAvailability = await client.GetAsync("api/Availability?eventType=" + @event.TypeId
                + "&beginDate=" + @event.Date.ToString("yyyy/MM/dd")
                + "&endDate=" + @event.Date.ToString("yyyy/MM/dd"));

            var availability = await getAvailability.Content.ReadAsAsync<IEnumerable<availabilityDto>>();

            decimal venueCost = (decimal)availability.FirstOrDefault().costPerHou;
            @event.VenueCost = venueCost * @event.Duration.Value.Hours;

            @event.VenueReference = availability.FirstOrDefault().name;



            _context.Update(@event);
            await _context.SaveChangesAsync();

            DateTime eventDate = @event.Date;

            ReservationPostDto reservation = new ReservationPostDto();
            reservation.EventDate = eventDate;
            reservation.StaffId = staffId;
            reservation.VenueCode = venueCode;

            string reference = venueCode + eventDate.ToString("yyyyMMdd");
            HttpResponseMessage delete = await client.DeleteAsync("api/reservations/" + reference);
            HttpResponseMessage post = await client.PostAsJsonAsync("api/reservations", reservation);

            if (post.IsSuccessStatusCode)
            {

                HttpResponseMessage getReservation = await client.GetAsync("api/reservations/" + reference);
                var x = await getReservation.Content.ReadAsAsync<Event>();
                return View("Reservation", x);
            }
            else
            {
                return RedirectToAction(nameof(BookVenue), eventId);
            }

        }


        //AVILABLE
        public async Task<IActionResult> AvailableMenus(int? eventid)
        {
            if (eventid == null)
            {
                return BadRequest();
            }

            var availableMenus = new List<Menu>().AsEnumerable();

            HttpClient client = getClient("32824");

            HttpResponseMessage response = await client.GetAsync("api/Menus");

            if (response.IsSuccessStatusCode)
            {
                availableMenus = await response.Content.ReadAsAsync<IEnumerable<Menu>>();

                if (availableMenus.Count() == 0)
                {
                    Debug.WriteLine("No available venues");
                }
            }
            else
            {
                Debug.WriteLine("Recieved a bad response from service");
            }

            ViewData["EventId"] = eventid;

            return View(availableMenus);
        }


        //BOOKMENUE
        public async Task<IActionResult> BookMenu(int? eventid, int? menuid)
        {
            if (eventid == null || menuid == null)
            {
                return BadRequest();
            }
            var @event = await _context.Events.FindAsync(eventid);

            HttpClient client = getClient("32824");

            HttpResponseMessage response = await client.GetAsync("api/Menus/" + menuid);
            Menu menu = await response.Content.ReadAsAsync<Menu>();

            @event.Menu = menu.Starter + " | " + menu.Main + " | " + menu.Dessert;
            @event.FoodCost = menu.Cost;

            _context.Update(@event);
            await _context.SaveChangesAsync();

            FoodBookingDto booking = new FoodBookingDto();
            booking.EventId = (int)eventid;
            booking.MenuId = (int)menuid;

            HttpResponseMessage delete = await client.DeleteAsync("api/bookings/" + eventid);
            HttpResponseMessage post = await client.PostAsJsonAsync("api/bookings", booking);

            if (post.IsSuccessStatusCode)
            {
                HttpResponseMessage getBooking = await client.GetAsync("api/foodmenus/" + menuid);
                var x = await getBooking.Content.ReadAsAsync<Menu>();
                ViewData["EventId"] = eventid;
                return View("BookMenu", x);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }

        }

        //Cancel MENUE
        public async Task<IActionResult> CancelMenu(int? eventid)
        {
            if (eventid == null)
            {
                return BadRequest();
            }

            var @event = await _context.Events.FindAsync(eventid);
            @event.FoodCost = 0;
            @event.Menu = null;

            _context.Update(@event);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { id = eventid });
        }

        private HttpClient getClient(string port)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new System.Uri("http://localhost:" + port);
            client.DefaultRequestHeaders.Accept.ParseAdd("application/json");

            return client;
        }

        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.Id == id);
        }
    }
}

