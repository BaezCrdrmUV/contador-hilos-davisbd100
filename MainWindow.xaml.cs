﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace contador_hilos_davisbd100
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

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            int.TryParse(tblManual.Text, out int result);
            result = result+1;
            tblManual.Text = result.ToString();
        }

        private void btStart_Click(object sender, RoutedEventArgs e)
        {
            if (cbThread.IsChecked.HasValue && cbThread.IsChecked.Value)
            {
                Thread thread = new Thread(CounterAutomatic);
                thread.Start();
            }
            else
            {
                CounterAutomatic();
            }
        }
        void CounterAutomatic()
        {
            for (int i = 0; i < 101; i++)
            {
                this.Dispatcher.Invoke(() =>
                {
                    tblAutomatic.Text = i.ToString();
                });
                Thread.Sleep(50);
            }
        }
    }
}
