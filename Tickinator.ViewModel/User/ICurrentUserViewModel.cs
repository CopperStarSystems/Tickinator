//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.ICurrentUserViewModel.cs
// 2016/11/28
//  --------------------------------------------------------------------------------------

using Tickinator.ViewModel.Core;

namespace Tickinator.ViewModel.User
{
    public interface ICurrentUserViewModel : IViewModel
    {
        int Id { get; }
    }
}