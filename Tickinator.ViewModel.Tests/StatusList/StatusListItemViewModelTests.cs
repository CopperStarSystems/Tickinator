//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.Tests.StatusListItemViewModelTests.cs
// 2016/12/02
//  --------------------------------------------------------------------------------------

using Tickinator.ViewModel.StatusList;

namespace Tickinator.ViewModel.Tests.StatusList
{
    public class StatusListItemViewModelTests : TestBase<StatusListItemViewModel>
    {
        protected override StatusListItemViewModel CreateSystemUnderTest()
        {
            return new StatusListItemViewModel();
        }
    }
}