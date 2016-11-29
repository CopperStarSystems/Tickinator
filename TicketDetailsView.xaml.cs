using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Tickinator.ViewModel.Core;
using Tickinator.ViewModel.TicketList;

namespace Tickinator.UI.Wpf
{
    /// <summary>
    /// Interaction logic for TicketDetailsView.xaml
    /// </summary>
    public partial class TicketDetailsView : Window, ITicketDetailsView
    {
        public TicketDetailsView()
        {
            InitializeComponent();
        }
    }
}
