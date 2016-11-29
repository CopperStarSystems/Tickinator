using System;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;

namespace Tickinator.UI.Wpf.Infrastructure
{
    [MarkupExtensionReturnType(typeof(Delegate))]
    public class EventBindingExtension : MarkupExtension
    {
        readonly string commandName;

        public EventBindingExtension(string command)
        {
            commandName = command;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            // Retrieve a reference to the InvokeCommand helper method declared below, using reflection
            var invokeCommand = GetType().GetMethod("InvokeCommand", BindingFlags.Instance | BindingFlags.NonPublic);
            if (invokeCommand != null)
            {
                // Check if the current context is an event or a method call with two parameters
                var target = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;
                if (target != null)
                {
                    var property = target.TargetProperty;
                    if (property is EventInfo)
                    {
                        // If the context is an event, simply return the helper method as delegate
                        // (this delegate will be invoked when the event fires)
                        var eventHandlerType = (property as EventInfo).EventHandlerType;
                        return invokeCommand.CreateDelegate(eventHandlerType, this);
                    }
                    if (property is MethodInfo)
                    {
                        // Some events are represented as method calls with 2 parameters:
                        // The first parameter is the control that acts as the event's sender,
                        // the second parameter is the actual event handler
                        var methodParameters = (property as MethodInfo).GetParameters();
                        if (methodParameters.Length == 2)
                        {
                            var eventHandlerType = methodParameters[1].ParameterType;
                            return invokeCommand.CreateDelegate(eventHandlerType, this);
                        }
                    }
                }
            }
            throw new InvalidOperationException(
                "The EventBinding markup extension is valid only in the context of events.");
        }

        void InvokeCommand(object sender, EventArgs args)
        {
            if (!string.IsNullOrEmpty(commandName))
            {
                var control = sender as FrameworkElement;
                if (control != null)
                {
                    // Find control's ViewModel
                    var viewmodel = control.DataContext;
                    if (viewmodel != null)
                    {
                        // Command must be declared as public property within ViewModel
                        var commandProperty = viewmodel.GetType().GetProperty(commandName);
                        if (commandProperty != null)
                        {
                            var command = commandProperty.GetValue(viewmodel) as ICommand;
                            if (command != null)
                                if (command.CanExecute(args))
                                    command.Execute(args);
                        }
                    }
                }
            }
        }
    }
}