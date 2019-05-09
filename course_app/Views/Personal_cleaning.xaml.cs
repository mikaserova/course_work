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

namespace course_app.Views
{
    /// <summary>
    /// Interaction logic for Personal_cleaning.xaml
    /// </summary>
    public partial class Personal_cleaning : UserControl
    {
        public Personal_cleaning()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GL.main.MenuItem_Click_1(sender, e);
        }
    }
}
