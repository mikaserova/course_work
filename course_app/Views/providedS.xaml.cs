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
    /// Interaction logic for providedS.xaml
    /// </summary>
    public partial class providedS : UserControl
    {
        public providedS()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                reservation r = ((service_request)serv_list.SelectedValue).reservation;
                GL.db.service_request.Remove((service_request)serv_list.SelectedValue);
                GL.db.SaveChanges();
                GL.main.DataContext = new ViewModel.ProvidedServices(r);
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GL.main.DataContext = new ViewModel.ReservationModel();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
               
                add_provided w = new add_provided();
                w.ShowDialog();
                GL.main.DataContext = new ViewModel.ProvidedServices(GL.R);
            }catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                update_provided w = new update_provided((service_request)serv_list.SelectedValue);
                w.ShowDialog();
                GL.main.DataContext = new ViewModel.ProvidedServices(GL.R);
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
    }
}
