﻿using Lab3.WpfApplication.ViewModels;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab3.WpfApplication
{
    public partial class Window2 : Window
    {
        private MainWindowViewModel _viewModel;

        public Window2()
        {
            InitializeComponent();
            InitModel();
        }

        private void InitModel()
        {
            _viewModel = new MainWindowViewModel();
            _viewModel.Load();
            this.DataContext = _viewModel;
        }

        private void LstAuthors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}