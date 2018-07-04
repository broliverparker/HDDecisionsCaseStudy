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

namespace HDDecisionsCaseStudy
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

        private void btn_apply_Click(object sender, RoutedEventArgs e)
        {
            Apply apply = new Apply();
            apply.Show();
        }

        private void btn_previous_Click(object sender, RoutedEventArgs e)
        {
            PreviousResults previousResults = new PreviousResults();
            previousResults.Show();
        }
    }
}
