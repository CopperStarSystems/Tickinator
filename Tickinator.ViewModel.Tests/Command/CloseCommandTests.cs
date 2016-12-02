//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.Tests.CloseCommandTests.cs
// 2016/12/02
//  --------------------------------------------------------------------------------------

using NUnit.Framework;
using Tickinator.ViewModel.Command;

namespace Tickinator.ViewModel.Tests.Command
{
    [TestFixture]
    public class CloseCommandTests : TestBase<CloseCommand>
    {
        protected override CloseCommand CreateSystemUnderTest()
        {
            return new CloseCommand();
        }
    }
}