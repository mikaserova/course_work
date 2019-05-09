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
    /// Interaction logic for CurrPayment.xaml
    /// </summary>
    public partial class CurrPayment : UserControl
    {
        public CurrPayment()
        {
            InitializeComponent();
           
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GL.main.MenuItem_Click_8(sender, e);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            payment p =(payment) res_list.Items[0];

            add_payment w = new add_payment(p.reservation);
            w.Show();
            DataContext = new ViewModel.currPaymentModel(p.reservation);
        }
    }
}
