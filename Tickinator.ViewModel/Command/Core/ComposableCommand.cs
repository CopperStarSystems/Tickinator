//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.ComposableCommand.cs
// 2016/11/29
//  --------------------------------------------------------------------------------------

namespace Tickinator.ViewModel.Command.Core
{
    public class ComposableCommand : CommandBase, IComposableCommand
    {
        readonly ICanExecute canExecute;
        readonly IExecute execute;

        public ComposableCommand(ICanExecute canExecute, IExecute execute)
        {
            this.canExecute = canExecute;
            this.execute = execute;
        }

        public override void Execute(object parameter)
        {
            execute.Execute(parameter);
        }

        public override bool CanExecute(object parameter)
        {
            return canExecute.CanExecute(parameter);
        }
    }
}