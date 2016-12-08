//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.Tests.SaveTicketCommandTests.cs
// 2016/12/07
//  --------------------------------------------------------------------------------------

using Moq;
using NUnit.Framework;
using Tickinator.Model;
using Tickinator.Repository;
using Tickinator.ViewModel.Command;
using Tickinator.ViewModel.Tests.Command.Core;

namespace Tickinator.ViewModel.Tests.Command
{
    [TestFixture]
    public class SaveTicketCommandTests : CommandBaseTests<SaveTicketCommand>
    {
        Mock<ITicketRepository> mockTicketRepository;
        Ticket ticket;

        [Test]
        public void Execute_Always_PerformsExpectedWork()
        {
            mockTicketRepository.Setup(p => p.Insert(ticket)).Returns(ticket);
            Execute();
            MockRepository.VerifyAll();
        }

        protected override void CreateMocks()
        {
            base.CreateMocks();
            ticket = new Ticket();
            mockTicketRepository = CreateMock<ITicketRepository>();
        }

        protected override SaveTicketCommand CreateSystemUnderTest()
        {
            return new SaveTicketCommand(ticket, mockTicketRepository.Object);
        }
    }
}