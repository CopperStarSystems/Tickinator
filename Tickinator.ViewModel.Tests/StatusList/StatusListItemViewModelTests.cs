//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.Tests.StatusListItemViewModelTests.cs
// 2016/12/02
//  --------------------------------------------------------------------------------------

using NUnit.Framework;
using Tickinator.Common.Enums;
using Tickinator.ViewModel.StatusList;

namespace Tickinator.ViewModel.Tests.StatusList
{
    [TestFixture]
    public class StatusListItemViewModelTests : TestBase<StatusListItemViewModel>
    {
        StatusEnum status = StatusEnum.Closed;

        [TestCase(StatusEnum.Closed)]
        [TestCase(StatusEnum.Open)]
        [TestCase(StatusEnum.Pending)]
        public void DisplayText_Always_ReturnsExpectedValue(StatusEnum input)
        {
            status = input;
            RecreateSystemUnderTest();
            Assert.That(SystemUnderTest.DisplayText, Is.EqualTo(input.ToString()));
        }

        [TestCase(StatusEnum.Closed)]
        [TestCase(StatusEnum.Open)]
        [TestCase(StatusEnum.Pending)]
        public void Value_Always_ReturnsExpectedValue(StatusEnum input)
        {
            status = input;
            RecreateSystemUnderTest();
            Assert.That(SystemUnderTest.Value, Is.EqualTo(input));
        }

        protected override StatusListItemViewModel CreateSystemUnderTest()
        {
            return new StatusListItemViewModel(status);
        }
    }
}