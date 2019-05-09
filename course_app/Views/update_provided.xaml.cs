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
    /// Interaction logic for update_provided.xaml
    /// </summary>
    public partial class update_provided : Window
    { service_request t;
        public update_provided(service_request s)
        {
            InitializeComponent();
            DataContext = new ViewModel.AddProvidedModel();
            t1.SelectedValue = s.reservation;
            t2.SelectedValue = s.additional_service;
            emp_list.SelectedValue = s.employee;
            pay_time.Value = s.service_provided_time;
            amou.Value = (byte)s.amount;
            t = s;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            t.reservation = (reservation)t1.SelectedValue;
            t.additional_service = (additional_service)t2.SelectedValue;
            t.employee = (employee)emp_list.SelectedValue;
            t.service_provided_time = pay_time.Value;
            t.amount = (int)amou.Value;
            GL.db.Entry(t).State = System.Data.Entity.EntityState.Modified;
            GL.db.SaveChanges();
            this.Close();

        }
    }
}
