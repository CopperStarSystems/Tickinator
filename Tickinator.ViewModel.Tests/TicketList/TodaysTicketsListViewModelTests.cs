﻿//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.Tests.TodaysTicketsListViewModel.cs
// 2016/11/28
//  --------------------------------------------------------------------------------------

using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Tickinator.Model;
using Tickinator.Repository;
using Tickinator.ViewModel.Factory;
using Tickinator.ViewModel.TicketList;

namespace Tickinator.ViewModel.Tests.TicketList
{
    [TestFixture]
    public class TodaysTicketsListViewModelTests : TestBase<TodaysTicketsListViewModel>
    {
        Mock<ITicketListItemViewModelFactory> mockTicketListItemViewModelFactory;
        Mock<ITicketRepository> mockTicketRepository;

        [Test]
        public void TodaysTickets_AfterConstruction_IsNotNull()
        {
            Assert.That(SystemUnderTest.TodaysTickets, Is.Not.Null);
        }

        protected override void CreateMocks()
        {
            base.CreateMocks();
            mockTicketRepository = CreateMock<ITicketRepository>();
            mockTicketListItemViewModelFactory = CreateMock<ITicketListItemViewModelFactory>();
        }

        protected override TodaysTicketsListViewModel CreateSystemUnderTest()
        {
            return new TodaysTicketsListViewModel(mockTicketRepository.Object, mockTicketListItemViewModelFactory.Object);
        }

        protected override void SetupConstructorRequiredMocks()
        {
            base.SetupConstructorRequiredMocks();
            var tickets = new List<Ticket> {new Ticket(), new Ticket(), new Ticket()};

            mockTicketRepository.Setup(p => p.GetAll()).Returns(tickets);
            foreach (var ticket in tickets)
            {
                var mockListItemViewModel = CreateMock<ITicketListItemViewModel>();
                mockTicketListItemViewModelFactory.Setup(p => p.Create(ticket)).Returns(mockListItemViewModel.Object);
            }
        }
    }
}