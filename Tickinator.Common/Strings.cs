//  --------------------------------------------------------------------------------------
// Tickinator.Common.Strings.cs
// 2016/12/07
//  --------------------------------------------------------------------------------------

namespace Tickinator.Common
{
    public class Strings
    {
        public class Button
        {
            public const string Cancel = "_Cancel";
            public const string Save = "_Save";
        }

        public class Dashboard
        {
            public const string AverageTicketDuration = "Average Ticket Duration:";
            public const string CurrentOpenTickets = "Current Open Tickets:";
            public const string MyDashboardTitle = "My Dashboard:";
            public const string TeamDashboardTitle = "Team Dashboard";
            public const string TicketsClosedToday = "Tickets Closed Today:";
        }

        public class MainWindow
        {
            public const string NewTicket = "New Ticket";
            public const string ApplicationTitle = "Tickinator!";
        }

        public class TicketDetails
        {
            public const string AddHeaderText = "New Ticket:";
            public const string AssignedToLabel = "Assigned To:";
            public const string DateLabel = "Date:";
            public const string EditHeaderText = "Ticket Details:";
            public const string HistoryTabHeader = "History";
            public const string NotesTabHeader = "Notes";
            public const string StatusLabel = "Status:";
            public const string SummaryTabHeader = "Summary";
            public const string TicketNumberLabel = "Ticket Number:";
            public const string TitleLabel = "Title";
        }

        public class TicketNotes
        {
            public const string DateColumnHeader = "Date";
            public const string TechnicianColumnHeader = "Technician";
            public const string NoteColumnHeader = "Note";
        }

        public class TicketList
        {
            public const string IdColumnHeader = "Id";
            public const string DateOpenedColumnHeader = "Date Opened";
            public const string DateClosedColumnHeader = "Date Closed";
            public const string TitleColumnHeader = "Title";
            public const string ShowOnlyOpenTickets = "Show only open tickets";
            public const string ShowOnlyMyTickets = "Show only my tickets";
            public const string TodaysTickets = "Today's Tickets:";
        }
    }
}