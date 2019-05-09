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
    /// Interaction logic for AllPayments.xaml
    /// </summary>
    public partial class AllPayments : UserControl
    {
        public AllPayments()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            add_payment w = new add_payment();
            w.Show();
            GL.main.MenuItem_Click_91(sender, e);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            add_payment w = new add_payment((payment)pay_list.SelectedValue);
            w.Show();
            GL.main.MenuItem_Click_91(sender, e);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            GL.db.payment.Remove((payment)pay_list.SelectedValue);
            GL.db.SaveChanges();
            GL.main.MenuItem_Click_91(sender, e);
        }
    }
}
