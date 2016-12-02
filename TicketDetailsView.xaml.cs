using System.Windows;
using Tickinator.ViewModel.View;

namespace Tickinator.UI.Wpf
{
    public partial class TicketDetailsView : Window, ITicketDetailsView
    {
        public TicketDetailsView()
        {
            InitializeComponent();
        }
    }
}