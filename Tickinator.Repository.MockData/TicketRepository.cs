//  --------------------------------------------------------------------------------------
// Tickinator.Repository.MockData.TicketRepository.cs
// 2016/11/25
//  --------------------------------------------------------------------------------------

using System.Collections.Generic;
using Tickinator.Model;

namespace Tickinator.Repository.MockData
{
    public class TicketRepository : ITicketRepository
    {
// Eventually we will put mock data in this class for 
        // development-time use.
        public IEnumerable<Ticket> GetAll()
        {
            // Eventually we will put mock data in this class for 
            // development-time use.
            return new List<Ticket>();
        }
    }
}