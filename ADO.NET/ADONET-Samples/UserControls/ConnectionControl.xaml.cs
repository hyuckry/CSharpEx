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
    /// ConnectionControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ConnectionControl : UserControl
    {
        public ConnectionControl()
        {
            InitializeComponent();

            _viewModel = (ConnectionViewModel)this.Resources["viewModel"];
        }

        private readonly ConnectionViewModel _viewModel;

        private void OpenConnectionWindowsAuth_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Connect(_viewModel.ConnectionString);
        }

        private void OpenConnectionSQLServerAuth_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Connect("Server=Localhost;Database=ADONETSamples;User ID=sa;Password=0811lee!;");
        }

        private void ConnectionUsingBlock_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.ConnectUsingBlock();
        }

        private void ConnectionWithErrors_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.ConnectWithErrors();
        }

        private void ConnectionStringsDotCom_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.connectionstrings.com");
        }
    }
}
