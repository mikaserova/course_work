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
    /// Interaction logic for AddNewEmployee.xaml
    /// </summary>
    public partial class AddNewEmployee : UserControl
    {
        public AddNewEmployee()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Add addw = new Add();
            addw.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            employee t = (employee)emp_list.SelectedValue;
            employee temp = GL.db.employee.Where(w => w.employee_id == t.employee_id).FirstOrDefault();
            GL.db.employee.Remove(temp);
            GL.db.SaveChanges();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            employee t = (employee)emp_list.SelectedValue;
            if (t != null) {
                Update updw = new Update(t);
                updw.Show();
            }
            else
            {
                MessageBox.Show("You haven`t chosen any row!");
            }
            
        }
    }
}
