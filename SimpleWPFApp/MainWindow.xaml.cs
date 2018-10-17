﻿using System;
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

namespace SimpleWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private delegate void ProgressBarDelegate(System.Windows.DependencyProperty dp, Object value);

        public MainWindow()
        {
            InitializeComponent();
                    }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double progress = 0;

            ProgressBarDelegate updatePbDelegate =
                new ProgressBarDelegate(pgbProgress.SetValue);

            do
            {
                progress++;

                Dispatcher.Invoke(updatePbDelegate,
                    System.Windows.Threading.DispatcherPriority.Background,
                    new object[] { ProgressBar.ValueProperty, progress });
                pgbProgress.Value = progress;
            }
            while (pgbProgress.Value != pgbProgress.Maximum);

            chkCheckbox.IsEnabled = true;
        }
    }
}
