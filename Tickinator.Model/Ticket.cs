﻿//  --------------------------------------------------------------------------------------
// Tickinator.Model.Ticket.cs
// 2016/11/25
//  --------------------------------------------------------------------------------------

using System;

namespace Tickinator.Model
{
    public class Ticket : ModelBase
    {
        public DateTime? DateClosed { get; set; }
    }
}