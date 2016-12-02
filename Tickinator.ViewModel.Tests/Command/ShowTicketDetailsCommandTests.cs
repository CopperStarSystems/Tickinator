﻿//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.Tests.ShowTicketDetailsCommandTests.cs
// 2016/11/29
//  --------------------------------------------------------------------------------------

using Moq;
using NUnit.Framework;
using Tickinator.ViewModel.Command;
using Tickinator.ViewModel.Tests.Command.Core;
using Tickinator.ViewModel.TicketList;
using Tickinator.ViewModel.View;
using Tickinator.ViewModel.View.Core;

namespace Tickinator.ViewModel.Tests.Command
{
    [TestFixture]
    public class ShowTicketDetailsCommandTests : CommandBaseTests<ShowTicketDetailsCommand>
    {
        Mock<ITicketDetailsView> mockTicketDetailsView;
        Mock<IViewFactory> mockViewFactory;
        Mock<ITicketListItemViewModel> mockViewModel;

        [Test]
        public void Execute_Always_PerformsExpectedWork()
        {
            mockViewFactory.Setup(p => p.Create<ITicketDetailsView>()).Returns(mockTicketDetailsView.Object);
            mockTicketDetailsView.SetupSet(p => p.DataContext = mockViewModel.Object);
            mockTicketDetailsView.Setup(p => p.ShowDialog()).Returns(true);
            Execute(mockViewModel.Object);
            MockRepository.VerifyAll();
        }

        protected override void CreateMocks()
        {
            base.CreateMocks();
            mockViewFactory = CreateMock<IViewFactory>();
            mockTicketDetailsView = CreateMock<ITicketDetailsView>();
            mockViewModel = CreateMock<ITicketListItemViewModel>();
        }

        protected override ShowTicketDetailsCommand CreateSystemUnderTest()
        {
            return new ShowTicketDetailsCommand(mockViewFactory.Object);
        }
    }
}