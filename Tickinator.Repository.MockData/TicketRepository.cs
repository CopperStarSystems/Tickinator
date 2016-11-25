//  --------------------------------------------------------------------------------------
// Tickinator.Repository.MockData.TicketRepository.cs
// 2016/11/25
//  --------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Tickinator.Model;

namespace Tickinator.Repository.MockData
{
    // Eventually we will put mock data in this class for 
    // development-time use.
    public class TicketRepository : ITicketRepository
    {
        IList<Ticket> tickets;

        public TicketRepository()
        {
            // Populate our mock data
            Seed();
        }

        public IEnumerable<Ticket> GetAll()
        {
            return tickets;
        }

        Ticket CreateTicket(int id, DateTime? dateClosed)
        {
            return new Ticket {Id = id, DateClosed = dateClosed};
        }

        void Seed()
        {
            tickets = new List<Ticket>();
            tickets.Add(CreateTicket(1, DateTime.Today));
            tickets.Add(CreateTicket(2, DateTime.Today.AddDays(-1)));
            tickets.Add(CreateTicket(3, DateTime.Today));
            tickets.Add(CreateTicket(4, DateTime.Today.AddDays(-2)));
            tickets.Add(CreateTicket(5, DateTime.Today.AddDays(-2)));
        }
    }
}