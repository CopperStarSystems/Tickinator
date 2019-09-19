//  --------------------------------------------------------------------------------------
// Tickinator.Model.Ticket.cs
// 2016/11/25
//  --------------------------------------------------------------------------------------

using System;
using Tickinator.Common.Enums;

namespace Tickinator.Model
{
    public class Ticket : ModelBase
    {
        public int AssignedToId { get; set; }

        public DateTime? DateClosed { get; set; }

        public DateTime DateOpened { get; set; }

        public StatusEnum Status { get; set; }

        public string Title { get; set; }
    }
}