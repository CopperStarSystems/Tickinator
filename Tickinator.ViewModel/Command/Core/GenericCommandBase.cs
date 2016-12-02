//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.GenericCommandBase.cs
// 2016/11/29
//  --------------------------------------------------------------------------------------

namespace Tickinator.ViewModel.Command.Core
{
    public abstract class GenericCommandBase<T> : CommandBase
    {
        public sealed override void Execute(object parameter)
        {
            var parameterReference = parameter;
            if (!CanExecute(parameterReference))
                return;
            if (ShouldExecuteWithDefaultParameter(parameterReference))
            {
                ExecuteInternal(default(T));
                return;
            }
            ExecuteInternal((T) parameterReference);
        }

        static bool ShouldExecuteWithDefaultParameter(object parameterReference)
        {
            return (parameterReference == null) && typeof(T).IsValueType;
        }

        protected abstract void ExecuteInternal(T parameter);
    }
}