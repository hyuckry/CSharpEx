using ADONET_Samples.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ADONET_Samples.UserControls
{
    /// <summary>
    /// BuilderControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class BuilderControl : UserControl
    {
        public BuilderControl()
        {
            InitializeComponent();

            _viewModel = (BuilderViewModel)this.Resources["viewModel"];
        }

        private readonly BuilderViewModel _viewModel;

        private void BreakApartConnectionString_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.BreakApartConnectionString();
        }

        private void CreateConnectionString_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.CreateConnectionString();
        }

        private void CreateDataModificationCommands_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.CreateDataModificationCommands();
        }

        private void InsertUsingDataModificationCommand_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.InsertUsingDataModificationCommand();
        }
    }
}
