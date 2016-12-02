//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.Tests.TicketListItemViewModelTests.cs
// 2016/11/28
//  --------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Tickinator.Model;
using Tickinator.ViewModel.StatusList;
using Tickinator.ViewModel.TicketList;

namespace Tickinator.ViewModel.Tests.TicketList
{
    [TestFixture]
    public class TicketListItemViewModelTests : TestBase<TicketListItemViewModel>
    {
        Mock<IStatusListProvider> mockStatusListProvider;
        Ticket ticket;

        static IEnumerable<TestCaseData> ConstructorInjectionTestData
        {
            get
            {
                yield return new TestCaseData(DateTime.Today, DateTime.Today, 1, 1);
                yield return new TestCaseData(DateTime.MinValue, DateTime.MaxValue, 5, 90);
                yield return new TestCaseData(DateTime.Today.AddDays(2), null, 2, 4);
            }
        }

        [TestCaseSource(nameof(ConstructorInjectionTestData))]
        public void Constructor_Always_SetsPropertyValues(DateTime dateOpened, DateTime? dateClosed, int assignedToId,
            int id)
        {
            CreateTicket(dateOpened, dateClosed, assignedToId, id);
            RecreateSystemUnderTest();
            Assert.That(SystemUnderTest.DateClosed, Is.EqualTo(dateClosed));
            Assert.That(SystemUnderTest.DateOpened, Is.EqualTo(dateOpened));
            Assert.That(SystemUnderTest.AssignedToId, Is.EqualTo(assignedToId));
            Assert.That(SystemUnderTest.Id, Is.EqualTo(id));
        }

        protected override void SetupConstructorRequiredMocks()
        {
            base.SetupConstructorRequiredMocks();
            mockStatusListProvider.Setup(p => p.GetStatuses()).Returns(new List<IStatusListItemViewModel>());
        }

        protected override void CreateMocks()
        {
            base.CreateMocks();
            mockStatusListProvider = CreateMock<IStatusListProvider>();
        }

        protected override TicketListItemViewModel CreateSystemUnderTest()
        {
            return new TicketListItemViewModel(ticket, mockStatusListProvider.Object);
        }

        void CreateTicket(DateTime dateOpened, DateTime? dateClosed, int assignedToId, int id)
        {
            ticket = new Ticket {DateOpened = dateOpened, DateClosed = dateClosed, AssignedToId = assignedToId, Id = id};
        }
    }
}