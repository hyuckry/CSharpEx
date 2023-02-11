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
    /// DataReaderControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DataReaderControl : UserControl
    {
        public DataReaderControl()
        {
            InitializeComponent();

            _viewModel = (DataReaderViewModel)this.Resources["viewModel"];
        }

        private readonly DataReaderViewModel _viewModel;

        private void DataReader_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.GetProductsAsDataReader();
        }

        private void GenericList_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.GetProductsAsGenericList();
        }

        private void UsingFieldValue_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.GetProductsUsingFieldValue();
        }

        private void ExtensionMethods_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.GetProductsUsingExtensionMethods();
        }

        private void MultipleResultSets_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.GetMultipleResultSets();
        }
    }
}
