//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.Tests.NewTicketCommandTests.cs
// 2016/12/07
//  --------------------------------------------------------------------------------------

using NUnit.Framework;
using Tickinator.ViewModel.Command;

namespace Tickinator.ViewModel.Tests.Command
{
    [TestFixture]
    public class NewTicketCommandTests : TestBase<NewTicketCommand>
    {
        // Stub test

        protected override NewTicketCommand CreateSystemUnderTest()
        {
            return new NewTicketCommand();
        }
    }
}