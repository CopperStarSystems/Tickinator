//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.StatusListItemViewModel.cs
// 2016/12/02
//  --------------------------------------------------------------------------------------

using Tickinator.Common.Enums;

namespace Tickinator.ViewModel.StatusList
{
    public class StatusListItemViewModel : IStatusListItemViewModel
    {
        public string DisplayText { get; }

        public StatusEnum Value { get; }

        public StatusListItemViewModel(StatusEnum statusEnum)
        {
            Value = statusEnum;
            DisplayText = statusEnum.ToString();
        }
    }
}