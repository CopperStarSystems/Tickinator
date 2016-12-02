//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.CloseCommand.cs
// 2016/12/02
//  --------------------------------------------------------------------------------------

using Tickinator.ViewModel.Command.Core;
using Tickinator.ViewModel.View;

namespace Tickinator.ViewModel.Command
{
    public class CloseCommand : CommandBase, ICloseCommand
    {
        readonly IClosable closable;

        public CloseCommand(IClosable closable)
        {
            this.closable = closable;
        }

        public override void Execute(object parameter)
        {
            closable.Close();
        }
    }
}