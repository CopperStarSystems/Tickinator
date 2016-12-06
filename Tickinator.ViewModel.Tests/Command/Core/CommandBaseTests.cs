﻿//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.Tests.CommandBaseTests.cs
// 2016/11/29
//  --------------------------------------------------------------------------------------

using System;
using System.Windows.Input;
using NUnit.Framework;
using Tickinator.ViewModel.Command.Core;
using Tickinator.ViewModel.Tests.Common;

namespace Tickinator.ViewModel.Tests.Command.Core
{
    public abstract class CommandBaseTests<T> : TestBase<T> where T : CommandBase, ICommand
    {
        protected MockEventHandler<EventArgs> MockCanExecuteChangedEventHandler { get; private set; }

        protected bool CanExecute(object parameter = null)
        {
            return SystemUnderTest.CanExecute(parameter);
        }

        protected void Execute(object parameter = null)
        {
            SystemUnderTest.Execute(parameter);
        }

        protected override void SetupMocksAfterConstruction()
        {
            base.SetupMocksAfterConstruction();
            MockCanExecuteChangedEventHandler = SetUpMockCanExecuteChangedEventHandler();
        }

        MockEventHandler<EventArgs> SetUpMockCanExecuteChangedEventHandler()
        {
            var mockEventHandler = new MockEventHandler<EventArgs>(SystemUnderTest, EventArgs.Empty);
            SystemUnderTest.CanExecuteChanged += mockEventHandler.HandleEvent;
            return mockEventHandler;
        }

        [Test]
        public void RaiseCanExecuteChanged_EventIsHooked_RaisesEventWithExpectedArguments()
        {
            // Verification is done in mock event handler's HandleEvent method
            SystemUnderTest.RaiseCanExecuteChanged();
        }

        [Test]
        public void RaiseCanExecuteChanged_EventIsNotHooked_DoesNotThrowException()
        {
            SystemUnderTest.CanExecuteChanged -= MockCanExecuteChangedEventHandler.HandleEvent;
            Assert.DoesNotThrow(() => SystemUnderTest.RaiseCanExecuteChanged());
        }
    }
}