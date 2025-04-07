namespace VenueBookingSystem.Models
{
    public class Venue
    {
        public int ID { get; set; }
        public string VenueName { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        public string ImageURL { get; set; }

        public List<Booking> Bookings { get; set; } = new();

    }
}
