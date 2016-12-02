//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.Tests.StatusListProviderTests.cs
// 2016/12/02
//  --------------------------------------------------------------------------------------

using NUnit.Framework;
using Tickinator.ViewModel.StatusList;

namespace Tickinator.ViewModel.Tests.StatusList
{
    [TestFixture]
    public class StatusListProviderTests : TestBase<StatusListProvider>
    {
        [Test]
        public void GetStatuses_Always_ReturnsExpectedResult()
        {
            Assert.That(SystemUnderTest.GetStatuses(), Is.Empty);
        }

        protected override StatusListProvider CreateSystemUnderTest()
        {
            return new StatusListProvider();
        }
    }
}