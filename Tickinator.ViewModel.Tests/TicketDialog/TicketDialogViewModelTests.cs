//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.Tests.TicketDialogViewModelTests.cs
// 2016/12/02
//  --------------------------------------------------------------------------------------

using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Tickinator.Model;
using Tickinator.ViewModel.Command;
using Tickinator.ViewModel.StatusList;
using Tickinator.ViewModel.TechnicianList;
using Tickinator.ViewModel.TicketDialog;

namespace Tickinator.ViewModel.Tests.TicketDialog
{
    public class TicketDialogViewModelTests : TestBase<TicketDialogViewModel>
    {
        readonly IList<IStatusListItemViewModel> statusList = new List<IStatusListItemViewModel>();
        readonly IList<ITechnicianListItemViewModel> technicianList = new List<ITechnicianListItemViewModel>();
        readonly Ticket ticket = new Ticket();

        string headerText = "Header";
        Mock<ICloseCommand> mockCloseCommand;
        Mock<ISaveTicketCommand> mockSaveCommand;
        Mock<ISaveTicketCommandFactory> mockSaveTicketCommandFactory;
        Mock<IStatusListProvider> mockStatusListProvider;
        Mock<ITechnicianListProvider> mockTechnicianListProvider;

        [TestCase("Header 1")]
        [TestCase("Header 2")]
        public void Header_Always_ReturnsInjectedValue(string headerText)
        {
            this.headerText = headerText;
            RecreateSystemUnderTest();
            Assert.That(SystemUnderTest.Header, Is.EqualTo(headerText));
        }

        [Test]
        public void SaveCommand_Always_ReturnsCreatedCommand()
        {
            Assert.That(SystemUnderTest.SaveCommand, Is.SameAs(mockSaveCommand.Object));
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

        protected override void CreateMocks()
        {
            base.CreateMocks();
            mockCloseCommand = CreateMock<ICloseCommand>();
            mockStatusListProvider = CreateMock<IStatusListProvider>();
            mockTechnicianListProvider = CreateMock<ITechnicianListProvider>();
            mockSaveTicketCommandFactory = CreateMock<ISaveTicketCommandFactory>();
            mockSaveCommand = CreateMock<ISaveTicketCommand>();
        }

        protected override TicketDialogViewModel CreateSystemUnderTest()
        {
            return new TicketDialogViewModel(ticket, mockCloseCommand.Object, mockStatusListProvider.Object,
                                             mockTechnicianListProvider.Object, mockSaveTicketCommandFactory.Object,
                                             headerText);
        }

        protected override void SetupConstructorRequiredMocks()
        {
            base.SetupConstructorRequiredMocks();
            mockStatusListProvider.Setup(p => p.GetStatuses()).Returns(statusList);
            mockTechnicianListProvider.Setup(p => p.GetTechnicians()).Returns(technicianList);
            mockSaveTicketCommandFactory.Setup(p => p.Create(ticket)).Returns(mockSaveCommand.Object);
        }
    }
}