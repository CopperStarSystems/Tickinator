//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.Tests.TechnicianListItemViewModelTests.cs
// 2016/12/04
//  --------------------------------------------------------------------------------------

using NUnit.Framework;
using Tickinator.Model;
using Tickinator.ViewModel.TechnicianList;

namespace Tickinator.ViewModel.Tests.TechnicianList
{
    [TestFixture]
    public class TechnicianListItemViewModelTests : TestBase<TechnicianListItemViewModel>
    {
        Technician technician;

        [TestCase("Dave", "Smith")]
        [TestCase("Rhonda", "Wilson")]
        public void FullName_Always_ReturnsExpectedValue(string firstName, string lastName)
        {
            technician.FirstName = firstName;
            technician.LastName = lastName;
            string expectedValue = $"{lastName}, {firstName}";
            Assert.That(SystemUnderTest.FullName, Is.EqualTo(expectedValue));
        }

        [TestCase(1)]
        [TestCase(5)]
        public void Id_Always_ReturnsExpectedValue(int expectedId)
        {
            technician.Id = expectedId;
            Assert.That(SystemUnderTest.Id, Is.EqualTo(expectedId));
        }

        protected override TechnicianListItemViewModel CreateSystemUnderTest()
        {
            return new TechnicianListItemViewModel(technician);
        }

        protected override void SetupConstructorRequiredMocks()
        {
            base.SetupConstructorRequiredMocks();
            technician = new Technician {FirstName = "First", LastName = "Last", Id = 1};
        }
    }
}