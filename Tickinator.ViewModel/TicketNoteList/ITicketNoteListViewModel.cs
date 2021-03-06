﻿//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.ITicketNoteListViewModel.cs
// 2016/12/13
//  --------------------------------------------------------------------------------------

using System.ComponentModel;

namespace Tickinator.ViewModel.TicketNoteList
{
    public interface ITicketNoteListViewModel : IViewModel
    {
        ICollectionView Notes { get; }
    }
}