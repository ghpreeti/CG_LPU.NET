using FlightSserachEngine.Data;
using FlightSserachEngine.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FlightSserachEngine.Controllers
{
    public class FlightController : Controller
    {
        // GET: FlightController
        private readonly DatabaseHelper _db;

        public FlightController(DatabaseHelper db)
        {
            _db = db;
        }

        // GET: Flight/Search
        public IActionResult Search()
        {
            var model = new SearchViewModel
            {
                SourceList = _db.GetSources()
                                .Select(s => new SelectListItem
                                {
                                    Text = s,
                                    Value = s
                                }).ToList(),

                DestinationList = _db.GetDestinations()
                                     .Select(d => new SelectListItem
                                     {
                                         Text = d,
                                         Value = d
                                     }).ToList()
            };

            return View(model);
        }

        // 🔹 POST: Flight/SearchFlights
        [HttpPost]
        public IActionResult SearchFlights(SearchViewModel model)
        {
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }

                LoadDropdowns(model);
                return View("Search", model);
            }

            var results = _db.SearchFlights(model.Source, model.Destination, model.Persons);

            model.FlightResults = results;

            LoadDropdowns(model);
            return View("Search", model);
        }

        // POST: Flight/SearchFlightsWithHotels
        [HttpPost]
        public IActionResult SearchFlightsWithHotels(SearchViewModel model)
        {
            if (!ModelState.IsValid)
            {
                LoadDropdowns(model);
                return View("Search", model);
            }
            
            var results = _db.SearchFlightsWithHotels(model.Source, model.Destination, model.Persons);

            model.FlightHotelResults = results;

            LoadDropdowns(model);
            return View("Search", model);
        }

        //Helper Method to reload dropdowns
        private void LoadDropdowns(SearchViewModel model)
        {
            model.SourceList = _db.GetSources()
                                  .Select(s => new SelectListItem
                                  {
                                      Text = s,
                                      Value = s
                                  }).ToList();

            model.DestinationList = _db.GetDestinations()
                                       .Select(d => new SelectListItem
                                       {
                                           Text = d,
                                           Value = d
                                       }).ToList();
        }
    }
}
