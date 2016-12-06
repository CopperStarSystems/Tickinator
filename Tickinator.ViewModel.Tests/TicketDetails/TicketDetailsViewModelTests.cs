//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.Tests.TicketDetailsViewModelTests.cs
// 2016/12/02
//  --------------------------------------------------------------------------------------

using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Tickinator.Model;
using Tickinator.ViewModel.Command;
using Tickinator.ViewModel.StatusList;
using Tickinator.ViewModel.TechnicianList;
using Tickinator.ViewModel.TicketDetails;

namespace Tickinator.ViewModel.Tests.TicketDetails
{
    public class TicketDetailsViewModelTests : TestBase<TicketDetailsViewModel>
    {
        readonly IList<IStatusListItemViewModel> statusList = new List<IStatusListItemViewModel>();
        readonly IList<ITechnicianListItemViewModel> technicianList = new List<ITechnicianListItemViewModel>();
        readonly Ticket ticket = new Ticket();
        Mock<ICloseCommand> mockCloseCommand;
        Mock<IStatusListProvider> mockStatusListProvider;
        Mock<ITechnicianListProvider> mockTechnicianListProvider;

        protected override void CreateMocks()
        {
            base.CreateMocks();
            mockCloseCommand = CreateMock<ICloseCommand>();
            mockStatusListProvider = CreateMock<IStatusListProvider>();
            mockTechnicianListProvider = CreateMock<ITechnicianListProvider>();
        }

        protected override TicketDetailsViewModel CreateSystemUnderTest()
        {
            return new TicketDetailsViewModel(ticket, mockCloseCommand.Object, mockStatusListProvider.Object,
                mockTechnicianListProvider.Object);
        }

        protected override void SetupConstructorRequiredMocks()
        {
            base.SetupConstructorRequiredMocks();
            mockStatusListProvider.Setup(p => p.GetStatuses()).Returns(statusList);
            mockTechnicianListProvider.Setup(p => p.GetTechnicians()).Returns(technicianList);
        }

        [Test]
        public void Statuses_Always_ReturnsExpectedValues()
        {
            Assert.That(SystemUnderTest.Statuses, Is.SameAs(statusList));
        }

        [Test]
        public void Technicians_Always_ReturnsExpectedValues()
        {
            Assert.That(SystemUnderTest.Technicians, Is.SameAs(technicianList));
        }
    }
}