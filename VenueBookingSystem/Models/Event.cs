﻿namespace VenueBookingSystem.Models
{
    public class Event
    {
        public int ID { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string Description { get; set; }
        public List<Booking> Bookings { get; set; } = new();

    }
}
