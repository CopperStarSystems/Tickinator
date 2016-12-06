//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.Tests.TechnicianListProviderTests.cs
// 2016/12/06
//  --------------------------------------------------------------------------------------

using NUnit.Framework;
using Tickinator.ViewModel.TechnicianList;

namespace Tickinator.ViewModel.Tests.TechnicianList
{
    [TestFixture]
    public class TechnicianListProviderTests : TestBase<TechnicianListProvider>
    {

        // Stub
        [Test]
        public void GetTechnicians_Always_ReturnsExpectedValue()
        {
            Assert.That(SystemUnderTest.GetTechnicians(), Is.Not.Null);
            Assert.That(SystemUnderTest.GetTechnicians(), Is.Empty);
        }

        protected override TechnicianListProvider CreateSystemUnderTest()
        {
            return new TechnicianListProvider();
        }
    }
}