﻿//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.Tests.SaveTicketCommandTests.cs
// 2016/12/07
//  --------------------------------------------------------------------------------------

using GalaSoft.MvvmLight.Messaging;
using Moq;
using NUnit.Framework;
using Tickinator.Model;
using Tickinator.Repository;
using Tickinator.ViewModel.Command;
using Tickinator.ViewModel.Messages.TicketUpdated;
using Tickinator.ViewModel.Tests.Command.Core;

namespace Tickinator.ViewModel.Tests.Command
{
    [TestFixture]
    public class SaveTicketCommandTests : CommandBaseTests<SaveTicketCommand>
    {
        Mock<IMessenger> mockMessenger;
        Mock<ITicketRepository> mockTicketRepository;
        Mock<ITicketUpdatedMessage> mockTicketUpdatedMessage;
        Mock<ITicketUpdatedMessageFactory> mockTicketUpdatedMessageFactory;
        Ticket ticket;

        [Test]
        public void Execute_Always_PerformsExpectedWork()
        {
            mockTicketRepository.Setup(p => p.Insert(ticket)).Returns(ticket);
            mockTicketUpdatedMessageFactory.Setup(p => p.Create()).Returns(mockTicketUpdatedMessage.Object);
            mockMessenger.Setup(p => p.Send(mockTicketUpdatedMessage.Object));
            Execute();
            MockRepository.VerifyAll();
        }

        protected override void CreateMocks()
        {
            base.CreateMocks();
            ticket = new Ticket();
            mockTicketRepository = CreateMock<ITicketRepository>();
            mockMessenger = CreateMock<IMessenger>();
            mockTicketUpdatedMessage = CreateMock<ITicketUpdatedMessage>();
            mockTicketUpdatedMessageFactory = CreateMock<ITicketUpdatedMessageFactory>();
        }

        protected override SaveTicketCommand CreateSystemUnderTest()
        {
            return new SaveTicketCommand(ticket, mockTicketRepository.Object, mockMessenger.Object,
                                         mockTicketUpdatedMessageFactory.Object);
        }
    }
}