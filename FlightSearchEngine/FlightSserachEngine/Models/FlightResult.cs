namespace FlightSserachEngine.Models
{
    public class FlightResult
    {
        public int FlightId { get; set; }
        public string FlightName { get; set; }
        public string FlightType { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public decimal PricePerSeat { get; set; }
        public int Persons { get; set; }
        public decimal TotalCost { get; set; }
    }
}
