﻿//  --------------------------------------------------------------------------------------
// Tickinator.UI.Wpf.MainWindow.xaml.cs
// 2016/11/23
//  --------------------------------------------------------------------------------------

using System.Windows;
using Tickinator.ViewModel.View;

namespace Tickinator.UI.Wpf
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}