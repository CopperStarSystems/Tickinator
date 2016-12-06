//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.GenericCommandBase.cs
// 2016/12/02
//  --------------------------------------------------------------------------------------

namespace Tickinator.ViewModel.Command.Core
{
    public abstract class GenericCommandBase<T> : CommandBase
    {
        static bool ShouldExecuteWithDefaultParameter(object parameterReference)
        {
            return (parameterReference == null) && typeof(T).IsValueType;
        }

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

        protected abstract void ExecuteInternal(T parameter);
    }
}