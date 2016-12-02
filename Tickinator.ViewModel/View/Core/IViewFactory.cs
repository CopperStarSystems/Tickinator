//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.IViewFactory.cs
// 2016/12/02
//  --------------------------------------------------------------------------------------

namespace Tickinator.ViewModel.View.Core
{
    public interface IViewFactory
    {
        T Create<T>() where T : IView;
    }
}