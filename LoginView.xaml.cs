using System.Windows;
using Tickinator.ViewModel.View;

namespace Tickinator.UI.Wpf
{
    /// <summary>
    ///     Interaction logic for LoginDialog.xaml
    /// </summary>
    public partial class LoginView : Window, ILoginView
    {
        public LoginView()
        {
            InitializeComponent();
        }
    }
}