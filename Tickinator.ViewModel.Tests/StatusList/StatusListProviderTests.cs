//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.Tests.StatusListProviderTests.cs
// 2016/12/02
//  --------------------------------------------------------------------------------------

using System;
using System.Linq;
using Moq;
using NUnit.Framework;
using Tickinator.Common.Enums;
using Tickinator.ViewModel.StatusList;

namespace Tickinator.ViewModel.Tests.StatusList
{
    [TestFixture]
    public class StatusListProviderTests : TestBase<StatusListProvider>
    {
        Mock<IStatusListItemViewModelFactory> mockStatusListItemViewModelFactory;

        protected override void CreateMocks()
        {
            base.CreateMocks();
            mockStatusListItemViewModelFactory = CreateMock<IStatusListItemViewModelFactory>();
        }

        protected override StatusListProvider CreateSystemUnderTest()
        {
            return new StatusListProvider(mockStatusListItemViewModelFactory.Object);
        }

        void SetupMocksForGetStatusesTest()
        {
            foreach (var status in Enum.GetValues(typeof(StatusEnum)).Cast<StatusEnum>())
            {
                var mock = CreateMock<IStatusListItemViewModel>();
                mockStatusListItemViewModelFactory.Setup(p => p.Create(status)).Returns(mock.Object);
            }
        }

        [Test]
        public void GetStatuses_Always_ReturnsExpectedResult()
        {
            SetupMocksForGetStatusesTest();
            var result = SystemUnderTest.GetStatuses();
            Assert.That(result.Count(), Is.EqualTo(Enum.GetNames(typeof(StatusEnum)).Length));
        }
    }
}