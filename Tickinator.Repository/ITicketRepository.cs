﻿//  --------------------------------------------------------------------------------------
// Tickinator.Repository.ITicketRepository.cs
// 2016/11/25
//  --------------------------------------------------------------------------------------

using Tickinator.Model;

namespace Tickinator.Repository
{
    public interface ITicketRepository : IInsertRepository<Ticket>, IUpdateRepository<Ticket>
    {
    }
}