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
    /// Interaction logic for client_data.xaml
    /// </summary>
    public partial class client_data : UserControl
    {
        public client_data(client c)
        {
         
            DataContext = new course_app.ViewModel.ClientDataModel(c);
            InitializeComponent();
            f_n.Text = c.client_first_name;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
