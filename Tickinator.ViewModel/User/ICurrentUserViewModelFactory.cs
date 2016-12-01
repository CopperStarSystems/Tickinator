//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.ICurrentUserViewModelFactory.cs
// 2016/11/30
//  --------------------------------------------------------------------------------------

namespace Tickinator.ViewModel.User
{
    public interface ICurrentUserViewModelFactory
    {
        ICurrentUserViewModel Create(int id);
    }
}