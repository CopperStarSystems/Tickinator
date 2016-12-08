//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.Tests.SaveTicketCommandTests.cs
// 2016/12/07
//  --------------------------------------------------------------------------------------

using NUnit.Framework;
using Tickinator.ViewModel.Command;
using Tickinator.ViewModel.Tests.Command.Core;

namespace Tickinator.ViewModel.Tests.Command
{
    [TestFixture]
    public class SaveTicketCommandTests : CommandBaseTests<SaveTicketCommand>
    {
        // Stub
        protected override SaveTicketCommand CreateSystemUnderTest()
        {
            return new SaveTicketCommand();
        }
    }
}