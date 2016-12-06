//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.Tests.TechnicianListProviderTests.cs
// 2016/12/06
//  --------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using Tickinator.Model;
using Tickinator.Repository;
using Tickinator.ViewModel.TechnicianList;

namespace Tickinator.ViewModel.Tests.TechnicianList
{
    [TestFixture]
    public class TechnicianListProviderTests : TestBase<TechnicianListProvider>
    {
        Mock<ITechnicianListItemViewModelFactory> mockListItemViewModelFactory;
        Mock<ITechnicianRepository> mockTechnicianRepository;
        List<Technician> technicians;

        [TestCase(3)]
        [TestCase(10)]
        public void GetTechnicians_Always_ReturnsExpectedValue(int technicianCount)
        {
            for (var i = 0; i < technicianCount; i++)
            {
                var technician = new Technician();
                technicians.Add(technician);
                var listItemViewModel = CreateMock<ITechnicianListItemViewModel>();
                mockListItemViewModelFactory.Setup(p => p.Create(technician)).Returns(listItemViewModel.Object);
            }
            RecreateSystemUnderTest();
            Assert.That(SystemUnderTest.GetTechnicians(), Is.Not.Null);
            Assert.That(SystemUnderTest.GetTechnicians().Count(), Is.EqualTo(technicianCount));
        }

        protected override void CreateMocks()
        {
            base.CreateMocks();
            technicians = new List<Technician>();
            mockTechnicianRepository = CreateMock<ITechnicianRepository>();
            mockListItemViewModelFactory = CreateMock<ITechnicianListItemViewModelFactory>();
        }

        protected override TechnicianListProvider CreateSystemUnderTest()
        {
            return new TechnicianListProvider(mockTechnicianRepository.Object, mockListItemViewModelFactory.Object);
        }

        protected override void SetupConstructorRequiredMocks()
        {
            base.SetupConstructorRequiredMocks();
            mockTechnicianRepository.Setup(p => p.GetAll()).Returns(technicians);
        }
    }
}