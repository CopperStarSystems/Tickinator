//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.Tests.MockEventHandler.cs
// 2016/11/29
//  --------------------------------------------------------------------------------------

using System.Collections.Generic;
using NUnit.Framework;

namespace Tickinator.ViewModel.Tests.Common
{
    public class MockEventHandler<T>
    {
        readonly Queue<T> expectedEventArgsQueue;
        readonly object expectedSender;
        readonly int initialArgsCount;

        public MockEventHandler(object expectedSender, IEnumerable<T> expectedEventArgs)
        {
            this.expectedSender = expectedSender;
            expectedEventArgsQueue = new Queue<T>(expectedEventArgs);
            initialArgsCount = expectedEventArgsQueue.Count;
            Assert.That(initialArgsCount, Is.GreaterThanOrEqualTo(1), "expectedEventArgs cannot be empty.");
        }

        public MockEventHandler(object expectedSender, T expectedEventArgs)
            : this(expectedSender, new List<T>(new[] {expectedEventArgs}))
        {
        }

        public int TimesCalled { get; private set; }

        bool AlwaysExpectingSameEventArg
        {
            get
            {
                return initialArgsCount == 1;
            }
        }

        public void HandleEvent(object sender, T e)
        {
            Assert.That(sender, Is.SameAs(expectedSender), "Event Sender is not expected Sender");
            Assert.That(e, Is.EqualTo(GetExpectedEventArgs()), "EventArgs is not equal to expected EventArgs");
            TimesCalled++;
        }

        T DequeueNextExpectedEventArgs()
        {
            Assert.That(TimesCalled, Is.LessThan(initialArgsCount), "Event has been called more times than expected.");
            return expectedEventArgsQueue.Dequeue();
        }

        T GetExpectedEventArgs()
        {
            if (AlwaysExpectingSameEventArg)
                return GetExpectedSingleEventArgs();
            return DequeueNextExpectedEventArgs();
        }

        T GetExpectedSingleEventArgs()
        {
            return expectedEventArgsQueue.Peek();
        }
    }
}