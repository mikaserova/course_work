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


namespace course_app.Views
{
    /// <summary>
    /// Interaction logic for personal_schedule.xaml
    /// </summary>
    public partial class personal_schedule : UserControl
    {
        public personal_schedule()
        {
            InitializeComponent();

           
        }

        void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GL.main.MenuItem_Click_1(sender, e);
        }
    }
}
