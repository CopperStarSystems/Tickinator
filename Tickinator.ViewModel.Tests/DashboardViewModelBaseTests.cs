//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.Tests.DashboardViewModelBaseTests.cs
// 2016/11/25
//  --------------------------------------------------------------------------------------

using System.Collections.Generic;
using NUnit.Framework;
using Tickinator.Model;

namespace Tickinator.ViewModel.Tests
{
    [TestFixture]
    public abstract class DashboardViewModelBaseTests<T> : TestBase<T> where T : IDashboardViewModel
    {
        protected IList<Ticket> Tickets { get; private set; }

        [SetUp]
        public override void SetUp()
        {
            Tickets = new List<Ticket>();
            base.SetUp();
        }

        protected void AddTickets(int ticketCount)
        {
            for (var ctr = 0; ctr < ticketCount; ctr++)
                Tickets.Add(new Ticket {Id = ctr + 1});
        }
    }
}