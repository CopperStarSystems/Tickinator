//  --------------------------------------------------------------------------------------
// Tickinator.Repository.MockData.TicketRepository.cs
// 2016/11/25
//  --------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Tickinator.Common.Enums;
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

        public Ticket Insert(Ticket item)
        {
            var newId = tickets.Max(p => p.Id) + 1;
            item.Id = newId;
            tickets.Add(item);
            return item;
        }

        Ticket CreateTicket(int id, DateTime? dateClosed, DateTime dateOpened, string title, int assignedToId = 1,
                            StatusEnum status = StatusEnum.Open)
        {
            return new Ticket
                   {
                       Id = id,
                       DateClosed = dateClosed,
                       DateOpened = dateOpened,
                       AssignedToId = assignedToId,
                       Status = status,
                       Title=title
                   };
        }

        void Seed()
        {
            tickets = new List<Ticket>();
            tickets.Add(CreateTicket(1, DateTime.Today, DateTime.Today.AddHours(-1), "Title 1"));
            tickets.Add(CreateTicket(2, DateTime.Today, DateTime.Today.AddDays(-1.25), "Title 2", status: StatusEnum.Pending));
            tickets.Add(CreateTicket(3, null, DateTime.Now.AddHours(-1), "Title 3"));
            tickets.Add(CreateTicket(4, null, DateTime.Today.AddDays(-2.5), "Title 4", 2));
            tickets.Add(CreateTicket(5, DateTime.Today.AddDays(-2), DateTime.Today.AddDays(-3), "Title 5", 2));
        }

        public Ticket Update(Ticket item)
        {
            var existingItem = tickets.FirstOrDefault(p => p.Id == item.Id);
            var itemIndex = tickets.IndexOf(existingItem);
            tickets.RemoveAt(itemIndex);
            tickets.Insert(itemIndex, item);
            return item;
        }
    }
}