//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.IStatusListItemViewModel.cs
// 2016/12/02
//  --------------------------------------------------------------------------------------

using Tickinator.Common.Enums;

namespace Tickinator.ViewModel.StatusList
{
    public interface IStatusListItemViewModel
    {
        string DisplayText { get; }

        StatusEnum Value { get; }
    }
}