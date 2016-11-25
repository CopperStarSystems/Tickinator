//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.Tests.TestBase.cs
// 2016/11/23
//  --------------------------------------------------------------------------------------

using Moq;
using NUnit.Framework;

namespace Tickinator.ViewModel.Tests
{
    [TestFixture]
    public abstract class TestBase<T>
    {
        protected T SystemUnderTest { get; private set; }

        protected MockRepository MockRepository { get; private set; }

        protected void RecreateSystemUnderTest()
        {
            SystemUnderTest = CreateSystemUnderTest();
        }

        [SetUp]
        public virtual void SetUp()
        {
            CreateMockRepository();
            CreateMocks();
            SetupConstructorRequiredMocks();
            SystemUnderTest = CreateSystemUnderTest();
        }

        protected Mock<TMock> CreateMock<TMock>() where TMock : class
        {
            return MockRepository.Create<TMock>();
        }

        protected virtual void CreateMocks()
        {
        }

        protected abstract T CreateSystemUnderTest();

        protected virtual void SetupConstructorRequiredMocks()
        {
        }

        void CreateMockRepository()
        {
            MockRepository = new MockRepository(MockBehavior.Strict);
        }
    }
}