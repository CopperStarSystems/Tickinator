//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.Tests.ShowTicketDetailsCommandTests.cs
// 2016/11/29
//  --------------------------------------------------------------------------------------

using NUnit.Framework;
using Tickinator.ViewModel.Tests.Command;
using Tickinator.ViewModel.TicketList;

namespace Tickinator.ViewModel.Tests.TicketList
{
    [TestFixture]
    public class ShowTicketDetailsCommandTests : CommandBaseTests<ShowTicketDetailsCommand>
    {
        protected override ShowTicketDetailsCommand CreateSystemUnderTest()
        {
            return new ShowTicketDetailsCommand();
        }
    }
}