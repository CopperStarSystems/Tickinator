//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.IComposableCommandFactory.cs
// 2016/11/29
//  --------------------------------------------------------------------------------------

namespace Tickinator.ViewModel.Command
{
    public interface IComposableCommandFactory
    {
        IComposableCommand Create(ICanExecute canExecute, IExecute execute);
    }
}