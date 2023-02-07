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
    /// CommandControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CommandControl : UserControl
    {
        public CommandControl()
        {
            InitializeComponent();

            _viewModel = (CommandViewModel)this.Resources["viewModel"];
        }

        private readonly CommandViewModel _viewModel;

        private void Scalar_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.GetProductsCountScalar();
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.InsertProduct();
        }

        private void ScalarParameters_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.GetProductsCountScalarUsingParameters();
        }

        private void InsertParameters_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.InsertProductUsingParameters();
        }

        private void OutputParameters_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.InsertProductOutputParameters();
        }

        private void Transaction_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.TransactionProcessing();
        }
    }
}
