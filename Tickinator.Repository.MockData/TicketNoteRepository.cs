//  --------------------------------------------------------------------------------------
// Tickinator.Repository.MockData.TicketNoteRepository.cs
// 2016/12/13
//  --------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Tickinator.Model;

namespace Tickinator.Repository.MockData
{
    public class TicketNoteRepository : ITicketNoteRepository
    {
        IList<TicketNote> notes;
        public TicketNoteRepository()
        {
            Seed();
        }

        void Seed()
        {
            notes = new List<TicketNote>();
            notes.Add(new TicketNote {Created = DateTime.Today, Id = 1, Note = "Note 1", TicketId = 3});
            notes.Add(new TicketNote { Created = DateTime.Today.AddDays(-1), Id = 2, Note = "Note 2", TicketId = 3 });
            notes.Add(new TicketNote { Created = DateTime.Today, Id = 3, Note = "Some other note", TicketId = 4 });
            notes.Add(new TicketNote { Created = DateTime.Today.AddDays(-3), Id = 4, Note = "Note on Ticket 2", TicketId = 2 });
        }

        public IEnumerable<TicketNote> GetAll()
        {
            return notes;
        }
    }
}