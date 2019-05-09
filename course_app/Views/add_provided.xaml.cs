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
    /// Interaction logic for add_provided.xaml
    /// </summary>
    public partial class add_provided : Window
    {
        public add_provided()
        {
            InitializeComponent();
            DataContext = new ViewModel.AddProvidedModel();
            t1.SelectedValue = GL.R;
          
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            service_request sr = new service_request();
            sr.reservation_id = ((reservation)t1.SelectedValue).reservation_id;
            sr.employee_id = ((employee)emp_list.SelectedValue).employee_id;
            sr.additional_service_id = ((additional_service)t2.SelectedValue).additional_service_id;
            sr.amount =(int) amou.Value;
            sr.service_provided_time = pay_time.Value;
            GL.db.service_request.Add(sr);
            GL.db.SaveChanges();
            GL.main.DataContext = new ViewModel.ProvidedServices(GL.R);
            this.Close();

        }
    }
}
