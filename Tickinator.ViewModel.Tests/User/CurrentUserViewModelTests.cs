//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.Tests.CurrentUserViewModelTests.cs
// 2016/11/28
//  --------------------------------------------------------------------------------------

using NUnit.Framework;
using Tickinator.ViewModel.User;

namespace Tickinator.ViewModel.Tests.User
{
    [TestFixture]
    public class CurrentUserViewModelTests : TestBase<CurrentUserViewModel>
    {
        int expectedId;

        [TestCase(5)]
        [TestCase(1)]
        [TestCase(8)]
        public void Id_Always_ReturnsInjectedValue(int id)
        {
            expectedId = id;
            RecreateSystemUnderTest();
            Assert.That(SystemUnderTest.Id, Is.EqualTo(id));
        }

        protected override CurrentUserViewModel CreateSystemUnderTest()
        {
            return new CurrentUserViewModel(expectedId);
        }
    }
}