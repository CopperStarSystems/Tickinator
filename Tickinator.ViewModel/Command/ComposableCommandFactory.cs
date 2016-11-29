//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.ComposableCommandFactory.cs
// 2016/11/29
//  --------------------------------------------------------------------------------------

namespace Tickinator.ViewModel.Command
{
    public class ComposableCommandFactory : IComposableCommandFactory
    {
        public IComposableCommand Create(ICanExecute canExecute, IExecute execute)
        {
            return new ComposableCommand(canExecute, execute);
        }
    }
}