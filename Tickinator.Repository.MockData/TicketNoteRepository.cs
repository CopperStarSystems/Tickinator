//  --------------------------------------------------------------------------------------
// Tickinator.Repository.MockData.TicketNoteRepository.cs
// 2016/12/13
//  --------------------------------------------------------------------------------------

using System.Collections.Generic;
using Tickinator.Model;

namespace Tickinator.Repository.MockData
{
    public class TicketNoteRepository : ITicketNoteRepository
    {
        public IEnumerable<TicketNote> GetAll()
        {
            return new List<TicketNote>();
        }
    }
}