using FlightSserachEngine.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace FlightSserachEngine.Models
{
    public class SearchViewModel
    {
        [Required(ErrorMessage = "Please select source")]
        public string Source { get; set; }

        [Required(ErrorMessage = "Please select destination")]
        public string Destination { get; set; }

        [Range(1, 100, ErrorMessage = "Persons must be at least 1")]
        public int Persons { get; set; }

        // Dropdown Lists
        public List<SelectListItem>? SourceList { get; set; }
        public List<SelectListItem>? DestinationList { get; set; }

        // Optional: To show results on same page
        public List<FlightResult>? FlightResults { get; set; }
        public List<FlightHotelResult>? FlightHotelResults { get; set; }
    }
}



