//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.IStatusListItemViewModelFactory.cs
// 2016/12/02
//  --------------------------------------------------------------------------------------

using Tickinator.Common.Enums;

namespace Tickinator.ViewModel.StatusList
{
    public interface IStatusListItemViewModelFactory
    {
        IStatusListItemViewModel Create(StatusEnum statusEnum);
    }
}