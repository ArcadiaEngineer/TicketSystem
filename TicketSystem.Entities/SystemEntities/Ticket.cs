﻿using TicketSystem.Core.Abstract.Entities;

namespace TicketSystem.Entities.SystemEntities
{
    public class Ticket : IEntity
    {
        public int TicketId { get; set; }
        public int SessionId { get; set; }
        public Session? Session { get; set; }
        public int SeatId { get; set; }
        public Seat? Seat { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public int StudentNum { get; set; }
        public int AdultNum { get; set; }
        public decimal Price { get; set; }
    }
}
