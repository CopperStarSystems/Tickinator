﻿//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.Tests.MainViewModelTests.cs
// 2016/11/23
//  --------------------------------------------------------------------------------------

using Moq;
using NUnit.Framework;
using Tickinator.ViewModel.Dashboard;

namespace Tickinator.ViewModel.Tests
{
    [TestFixture]
    public class MainViewModelTests : TestBase<MainViewModel>
    {
        Mock<IMyDashboardViewModel> mockMyDashboardViewModel;
        Mock<ITeamDashboardViewModel> mockTeamDashboardViewModel;

        [Test]
        public void TeamDashboardViewModel_AfterConstruction_IsInjectedInstance()
        {
            Assert.That(SystemUnderTest.TeamDashboardViewModel, Is.SameAs(mockTeamDashboardViewModel.Object));
        }

        [Test]
        public void TeamDashboardViewModel_AfterConstruction_IsNotNull()
        {
            Assert.That(SystemUnderTest.TeamDashboardViewModel, Is.Not.Null);
        }

        protected override void CreateMocks()
        {
            base.CreateMocks();
            mockTeamDashboardViewModel = CreateMock<ITeamDashboardViewModel>();
            mockMyDashboardViewModel = CreateMock<IMyDashboardViewModel>();
        }

        protected override MainViewModel CreateSystemUnderTest()
        {
            return new MainViewModel(mockTeamDashboardViewModel.Object, mockMyDashboardViewModel.Object);
        }
    }
}