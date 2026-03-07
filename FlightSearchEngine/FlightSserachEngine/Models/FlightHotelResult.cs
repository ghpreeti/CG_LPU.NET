namespace FlightSserachEngine.Models
{
    public class FlightHotelResult
    {
        // Flight Details
        public int FlightId { get; set; }
        public string FlightName { get; set; }
        public string FlightType { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public decimal PricePerSeat { get; set; }

        // Hotel Details
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public string HotelType { get; set; }
        public string Location { get; set; }
        public decimal PricePerDay { get; set; }

        public int Persons { get; set; }

        public decimal FlightCost { get; set; }
        public decimal HotelCost { get; set; }
        public decimal TotalCost { get; set; }
    }
}
