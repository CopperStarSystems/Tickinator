//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.Tests.MainViewModelTests.cs
// 2016/11/23
//  --------------------------------------------------------------------------------------

using NUnit.Framework;

namespace Tickinator.ViewModel.Tests
{
    [TestFixture]
    public class MainViewModelTests
    {
        MainViewModel systemUnderTest;

        // This is just a stub test, we will remove it once
        // concrete implementation begins.
        [Test]
        public void Constructor_Always_Succeeds()
        {
            Assert.That(systemUnderTest, Is.Not.Null);
        }

        [SetUp]
        public void SetUp()
        {
            systemUnderTest = new MainViewModel();
        }
    }
}