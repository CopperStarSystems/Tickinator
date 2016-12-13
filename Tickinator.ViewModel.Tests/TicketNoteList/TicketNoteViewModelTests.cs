//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.Tests.TicketNoteViewModelTests.cs
// 2016/12/13
//  --------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using NUnit.Framework;
using Tickinator.Model;
using Tickinator.ViewModel.TicketNoteList;

namespace Tickinator.ViewModel.Tests.TicketNoteList
{
    [TestFixture]
    public class TicketNoteViewModelTests : TestBase<TicketNoteViewModel>
    {
        TicketNote inputNote;

        [TestCaseSource(nameof(TestData))]
        public void Properties_AfterConstruction_AreExpectedValues(TicketNote note)
        {
            inputNote = note;
            RecreateSystemUnderTest();
            Assert.That(SystemUnderTest.Created, Is.EqualTo(note.Created));
            Assert.That(SystemUnderTest.Note, Is.EqualTo(note.Note));
            Assert.That(SystemUnderTest.TicketId, Is.EqualTo(note.TicketId));
        }

        public static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return
                    new TestCaseData(new TicketNote {Created = DateTime.Today, Id = 1, Note = "Note 1", TicketId = 1});
                yield return
                    new TestCaseData(new TicketNote
                                     {
                                         Created = DateTime.Today.AddDays(-1),
                                         Id = 2,
                                         Note = "Note 2",
                                         TicketId = 9
                                     });
                yield return
                    new TestCaseData(new TicketNote
                                     {
                                         Created = DateTime.Today.AddMonths(-1),
                                         Id = 31,
                                         Note = "Some Note",
                                         TicketId = 15
                                     });
            }
        }

        protected override void CreateMocks()
        {
            base.CreateMocks();
            inputNote = new TicketNote();
        }

        protected override TicketNoteViewModel CreateSystemUnderTest()
        {
            return new TicketNoteViewModel(inputNote);
        }
    }
}