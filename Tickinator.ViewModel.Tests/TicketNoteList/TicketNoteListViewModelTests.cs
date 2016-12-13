//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.Tests.TicketNoteListViewModelTests.cs
// 2016/12/13
//  --------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using Tickinator.Model;
using Tickinator.Repository;
using Tickinator.ViewModel.TicketNoteList;

namespace Tickinator.ViewModel.Tests.TicketNoteList
{
    [TestFixture]
    public class TicketNoteListViewModelTests : TestBase<TicketNoteListViewModel>
    {
        readonly int expectedTicketId = 1;
        Mock<ITicketNoteRepository> mockTicketNoteRepository;
        Mock<ITicketNoteViewModelFactory> mockTicketNoteViewModelFactory;

        List<TicketNote> notes;

        [Test]
        public void Notes_Only_ReturnsNotesForSpecifiedTicket()
        {
            var expectedCount = notes.Count(p => p.TicketId == expectedTicketId);
            var actual = SystemUnderTest.Notes.Cast<ITicketNoteViewModel>().Count();
            Assert.That(actual, Is.EqualTo(expectedCount));
        }

        protected override void CreateMocks()
        {
            base.CreateMocks();
            mockTicketNoteRepository = CreateMock<ITicketNoteRepository>();
            mockTicketNoteViewModelFactory = CreateMock<ITicketNoteViewModelFactory>();
            notes = new List<TicketNote>();
        }

        protected override TicketNoteListViewModel CreateSystemUnderTest()
        {
            return new TicketNoteListViewModel(expectedTicketId, mockTicketNoteRepository.Object,
                                               mockTicketNoteViewModelFactory.Object);
        }

        protected override void SetupConstructorRequiredMocks()
        {
            base.SetupConstructorRequiredMocks();
            mockTicketNoteRepository.Setup(p => p.GetAll()).Returns(notes);
            SetupTicketNoteViewModelFactory();
        }

        void CreateNotes(int count, int ticketId)
        {
            for (var i = 0; i < count; i++)
                notes.Add(new TicketNote {TicketId = ticketId});
        }

        void SetupTicketNoteViewModelFactory()
        {
            foreach (var ticketNote in notes)
                if (ticketNote.TicketId == expectedTicketId)
                {
                    var viewModel = CreateMock<ITicketNoteViewModel>();
                    mockTicketNoteViewModelFactory.Setup(p => p.Create(ticketNote)).Returns(viewModel.Object);
                }
        }
    }
}