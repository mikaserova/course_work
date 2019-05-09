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
using System.Windows.Shapes;

namespace course_app.Views
{
    /// <summary>
    /// Interaction logic for position_info.xaml
    /// </summary>
    public partial class position_info : Window
    {
        public position_info()
        {
            InitializeComponent();
        }
        public position_info( employee_position p)
        {
            InitializeComponent();
            l11.Content = p.position_name;
            l212.Content = p.wage_lower_bound;
            l222.Content = p.wage_upper_bound;
            desc.Text = p.position_description;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
