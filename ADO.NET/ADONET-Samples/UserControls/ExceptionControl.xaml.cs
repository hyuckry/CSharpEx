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
    /// ExceptionControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ExceptionControl : UserControl
    {
        public ExceptionControl()
        {
            InitializeComponent();

            _viewModel = (ExceptionViewModel)this.Resources["viewModel"];
        }

        private readonly ExceptionViewModel _viewModel;

        private void SimpleExceptionHandling_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.SimpleExceptionHandling();
        }

        private void CatchSqlException_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.CatchSqlException();
        }

        private void GatherExceptionInfo_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.GatherExceptionInformation();
        }
    }
}
