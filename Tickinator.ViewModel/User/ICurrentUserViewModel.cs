//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.ICurrentUserViewModel.cs
// 2016/11/28
//  --------------------------------------------------------------------------------------

namespace Tickinator.ViewModel.User
{
    public interface ICurrentUserViewModel : IViewModel
    {
        int Id { get; }
    }
}