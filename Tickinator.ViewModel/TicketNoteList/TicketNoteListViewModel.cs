//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.TicketNoteListViewModel.cs
// 2016/12/13
//  --------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using GalaSoft.MvvmLight;
using Tickinator.Model;
using Tickinator.Repository;

namespace Tickinator.ViewModel.TicketNoteList
{
    public class TicketNoteListViewModel : ViewModelBase, ITicketNoteListViewModel
    {
        ObservableCollection<ITicketNoteViewModel> notes;
        CollectionViewSource notesViewSource;

        public TicketNoteListViewModel(int ticketId, 
            ITicketNoteRepository ticketNoteRepository,
            ITicketNoteViewModelFactory noteViewModelFactory)
        {
            var noteEntities = GetNotes(ticketNoteRepository, ticketId);
            LoadTicketNotes(noteViewModelFactory, noteEntities);
            CreateNotesViewSource();
        }

        static IEnumerable<TicketNote> GetNotes(ITicketNoteRepository ticketNoteRepository, int ticketId)
        {
            // This is pretty inefficient, we'll add some functionality
            // to the repository later so we can select by ticketId
            var noteEntities = ticketNoteRepository.GetAll().Where(p=>p.TicketId == ticketId);
            return noteEntities;
        }

        void CreateNotesViewSource()
        {
            notesViewSource = new CollectionViewSource {Source = notes};
        }

        void LoadTicketNotes(ITicketNoteViewModelFactory noteViewModelFactory, IEnumerable<TicketNote> noteEntities)
        {
            notes = new ObservableCollection<ITicketNoteViewModel>();
            foreach (var noteEntity in noteEntities)
                notes.Add(noteViewModelFactory.Create(noteEntity));
        }

        public ICollectionView Notes
        {
            get { return notesViewSource.View; }
        }
    }
}