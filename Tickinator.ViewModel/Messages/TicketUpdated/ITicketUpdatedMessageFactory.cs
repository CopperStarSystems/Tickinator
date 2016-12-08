//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.ITicketUpdatedMessageFactory.cs
// 2016/12/08
//  --------------------------------------------------------------------------------------

namespace Tickinator.ViewModel.Messages.TicketUpdated
{
    public interface ITicketUpdatedMessageFactory
    {
        ITicketUpdatedMessage Create();
    }
}