﻿using ADONET_Samples.UserControls;
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

namespace ADONET_Samples
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ExitMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ConnectionsMenu_Click(object sender, RoutedEventArgs e)
        {
            contentArea.Children.Clear();
            contentArea.Children.Add(new ConnectionControl());
        }

        private void CommandsMenu_Click(object sender, RoutedEventArgs e)
        {
            contentArea.Children.Clear();
            contentArea.Children.Add(new CommandControl());
        }

        private void DataReaderMenu_Click(object sender, RoutedEventArgs e)
        {
            contentArea.Children.Clear();
            contentArea.Children.Add(new DataReaderControl());
        }

        private void ExceptionHandlingMenu_Click(object sender, RoutedEventArgs e)
        {
            contentArea.Children.Clear();
            contentArea.Children.Add(new ExceptionControl());
        }
        private void DataTableMenu_Click(object sender, RoutedEventArgs e)
        {
            contentArea.Children.Clear();
            contentArea.Children.Add(new DataTableControl());
        }

        private void DataViewMenu_Click(object sender, RoutedEventArgs e)
        {
            contentArea.Children.Clear();
            contentArea.Children.Add(new DataViewControl());
        }

        private void DataRowColumnMenu_Click(object sender, RoutedEventArgs e)
        {
            contentArea.Children.Clear();
            contentArea.Children.Add(new DataRowColumnControl());
        }

        private void BuilderMenu_Click(object sender, RoutedEventArgs e)
        {
            contentArea.Children.Clear();
            contentArea.Children.Add(new BuilderControl());
        }
        
    }
}