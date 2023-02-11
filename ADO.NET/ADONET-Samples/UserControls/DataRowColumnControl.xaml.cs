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
    /// DataRowColumnControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DataRowColumnControl : UserControl
    {
        public DataRowColumnControl()
        {
            InitializeComponent();

            _viewModel = (DataRowColumnViewModel)this.Resources["viewModel"];
        }

        private readonly DataRowColumnViewModel _viewModel;

        private void BuildDataTable_Click(object sender, RoutedEventArgs e)
        {
            grdProducts.DataContext = _viewModel.BuildDataTable().DefaultView;
        }

        private void CloneDataTable_Click(object sender, RoutedEventArgs e)
        {
            grdProducts.DataContext = _viewModel.CloneDataTable().DefaultView;
        }

        private void CopyDataTable_Click(object sender, RoutedEventArgs e)
        {
            grdProducts.DataContext = _viewModel.CopyDataTable().DefaultView;
        }

        private void SelectUsingRowByRow_Click(object sender, RoutedEventArgs e)
        {
            grdProducts.DataContext = _viewModel.SelectCopyRowByRow().DefaultView;
        }

        private void SelectUsingCopyToDataTable_Click(object sender, RoutedEventArgs e)
        {
            grdProducts.DataContext = _viewModel.SelectUsingCopyToDataTable().DefaultView;
        }
    }

}