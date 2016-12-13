//  --------------------------------------------------------------------------------------
// Tickinator.Model.TicketNote.cs
// 2016/12/13
//  --------------------------------------------------------------------------------------

using System;

namespace Tickinator.Model
{
    public class TicketNote : ModelBase
    {
        public DateTime Created { get; set; }

        public string Note { get; set; }

        public int TicketId { get; set; }
    }
}