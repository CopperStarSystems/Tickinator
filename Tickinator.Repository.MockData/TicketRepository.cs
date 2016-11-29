//  --------------------------------------------------------------------------------------
// Tickinator.Repository.MockData.TicketRepository.cs
// 2016/11/25
//  --------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Tickinator.Model;

namespace Tickinator.Repository.MockData
{
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

        Ticket CreateTicket(int id, DateTime? dateClosed, DateTime dateOpened, int assignedToId = 1)
        {
            return new Ticket {Id = id, DateClosed = dateClosed, DateOpened = dateOpened, AssignedToId = assignedToId};
        }

        void Seed()
        {
            tickets = new List<Ticket>();
            tickets.Add(CreateTicket(1, DateTime.Today, DateTime.Today.AddHours(-1)));
            tickets.Add(CreateTicket(2, DateTime.Today, DateTime.Today.AddDays(-1.25)));
            tickets.Add(CreateTicket(3, null, DateTime.Now.AddHours(-1)));
            tickets.Add(CreateTicket(4, DateTime.Today, DateTime.Today.AddDays(-2.5), 2));
            tickets.Add(CreateTicket(5, DateTime.Today.AddDays(-2), DateTime.Today.AddDays(-3), 2));
        }
    }
}