using NUnit.Framework;

namespace Tickinator.ViewModel.Tests
{
    [TestFixture]
    public class LoginViewModelTests : TestBase<LoginViewModel>
    {
        protected override LoginViewModel CreateSystemUnderTest()
        {
            return new LoginViewModel();
        }

        [Test]
        public void Constructor_Always_PerformsExpectedWork()
        {
            Assert.That(SystemUnderTest, Is.Not.Null);
        }
    }
}