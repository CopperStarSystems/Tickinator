//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.ICloseCommandFactory.cs
// 2016/12/02
//  --------------------------------------------------------------------------------------

using Tickinator.ViewModel.View;

namespace Tickinator.ViewModel.Command
{
    public interface ICloseCommandFactory
    {
        ICloseCommand Create(IClosable closable);
    }
}